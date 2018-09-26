﻿//----------------------------------------------------------------------- 
// PDS WITSMLstudio Store, 2018.3
//
// Copyright 2018 PDS Americas LLC
// 
// Licensed under the PDS Open Source WITSML Product License Agreement (the
// "License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   
//     http://www.pds.group/WITSMLstudio/OpenSource/ProductLicenseAgreement
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Energistics.Etp.Common;
using Energistics.Etp.Common.Datatypes;
using Energistics.Etp.Common.Datatypes.Object;
using Energistics.Etp.v12.Protocol.GrowingObject;
using PDS.WITSMLstudio.Framework;
using PDS.WITSMLstudio.Store.Data.GrowingObjects;

namespace PDS.WITSMLstudio.Store.Providers.GrowingObject
{
    /// <summary>
    /// Process messages received for the Store role of the GrowingObject protocol.
    /// </summary>
    /// <seealso cref="GrowingObjectStoreHandler" />
    [Export(typeof(IGrowingObjectStore))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GrowingObject12StoreProvider : GrowingObjectStoreHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GrowingObject12StoreProvider" /> class.
        /// </summary>
        /// <param name="container">The composition container.</param>
        [ImportingConstructor]
        public GrowingObject12StoreProvider(IContainer container)
        {
            Container = container;
        }

        /// <summary>
        /// Gets the composition container.
        /// </summary>
        /// <value>The container.</value>
        public IContainer Container { get; }

        /// <summary>
        /// Handles the GetPart message from a customer.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <param name="message">The message.</param>
        protected override void HandleGetPart(IMessageHeader header, GetPart message)
        {
            base.HandleGetPart(header, message);

            EtpUri uri;
            var dataAdapter = GetDataAdapterAndValidateUri(header.MessageId, message.Uri, out uri);
            if (dataAdapter == null) return;

            IDataObject dataObject;

            try
            {
                dataObject = dataAdapter.GetGrowingPart(Session.Adapter, uri, message.Uid);
            }
            catch (NotImplementedException)
            {
                this.NotSupported(header.MessageId);
                return;
            }

            if (dataObject == null)
            {
                NotFound(header.MessageId, message.Uri);
                return;
            }

            SendObjectParts(header.MessageId, message.Uri, new[] { dataObject });
        }

        /// <summary>
        /// Handles the GetPartsByRange message from a customer.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <param name="message">The message.</param>
        protected override void HandleGetPartsByRange(IMessageHeader header, GetPartsByRange message)
        {
            base.HandleGetPartsByRange(header, message);

            EtpUri uri;
            var dataAdapter = GetDataAdapterAndValidateUri(header.MessageId, message.Uri, out uri);
            if (dataAdapter == null) return;

            IList<IDataObject> dataObjects;

            try
            {
                dataObjects = dataAdapter.GetGrowingParts(Session.Adapter, uri, message.IndexInterval.StartIndex.Item, message.IndexInterval.EndIndex.Item);
            }
            catch (NotImplementedException)
            {
                this.NotSupported(header.MessageId);
                return;
            }

            if (!dataObjects.Any())
            {
                NotFound(header.MessageId, message.Uri);
                return;
            }

            SendObjectParts(header.MessageId, message.Uri, dataObjects);
        }

        /// <summary>
        /// Handles the PutPart message from a customer.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <param name="message">The message.</param>
        protected override void HandlePutPart(IMessageHeader header, PutPart message)
        {
            base.HandlePutPart(header, message);

            EtpUri uri;
            var dataAdapter = GetDataAdapterAndValidateUri(header.MessageId, message.Uri, out uri);
            if (dataAdapter == null) return;

            try
            {
                dataAdapter.PutGrowingPart(Session.Adapter, uri, message.ContentType, message.Data);
            }
            catch (NotImplementedException)
            {
                this.NotSupported(header.MessageId);
            }
        }

        /// <summary>
        /// Handles the DeletePart message from a customer.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <param name="message">The message.</param>
        protected override void HandleDeletePart(IMessageHeader header, DeletePart message)
        {
            base.HandleDeletePart(header, message);

            EtpUri uri;
            var dataAdapter = GetDataAdapterAndValidateUri(header.MessageId, message.Uri, out uri);
            if (dataAdapter == null) return;

            try
            {
                dataAdapter.DeleteGrowingPart(uri, message.Uid);
            }
            catch (NotImplementedException)
            {
                this.NotSupported(header.MessageId);
            }
        }

        /// <summary>
        /// Handles the DeletePartsByRange message from a customer.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <param name="message">The message.</param>
        protected override void HandleDeletePartsByRange(IMessageHeader header, DeletePartsByRange message)
        {
            base.HandleDeletePartsByRange(header, message);

            EtpUri uri;
            var dataAdapter = GetDataAdapterAndValidateUri(header.MessageId, message.Uri, out uri);
            if (dataAdapter == null) return;

            try
            {
                dataAdapter.DeleteGrowingParts(uri, message.DeleteInterval.StartIndex.Item, message.DeleteInterval.EndIndex.Item);
            }
            catch (NotImplementedException)
            {
                this.NotSupported(header.MessageId);
            }
        }

        private IGrowingObjectDataAdapter GetDataAdapterAndValidateUri(long messageId, string uri, out EtpUri etpUri)
        {
            etpUri = this.CreateAndValidateUri(uri, messageId);

            if (!etpUri.IsValid || !this.ValidateUriObjectType(etpUri, messageId))
            {
                return null;
            }

            if (!ObjectTypes.IsGrowingDataObject(etpUri.ObjectType))
            {
                this.UnsupportedObject(null, uri, messageId);
                return null;
            }

            try
            {
                return Container.Resolve<IGrowingObjectDataAdapter>(new ObjectName(etpUri.ObjectType, etpUri.GetDataSchemaVersion()));
            }
            catch (ContainerException ex)
            {
                this.UnsupportedObject(ex, uri, messageId);
                return null;
            }
        }

        private void SendObjectParts(long messageId, string uri, ICollection<IDataObject> dataObjects)
        {
            dataObjects.ForEach((dataObject, i) =>
            {
                var flag = i >= dataObjects.Count - 1
                    ? MessageFlags.FinalPart
                    : MessageFlags.MultiPart;

                var etpUri = new EtpUri(dataObject.Resource.Uri);
                var uid = etpUri.ObjectId;

                ObjectPart(uri, uid, dataObject.Resource.ContentType, dataObject.Data, messageId, flag);
            });
        }

        private void NotFound(long messageId, string uri)
        {
            ProtocolException(11, "Not Found: " + uri, messageId);
        }
    }
}
