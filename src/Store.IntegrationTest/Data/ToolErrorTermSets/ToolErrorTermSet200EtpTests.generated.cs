//----------------------------------------------------------------------- 
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

// ----------------------------------------------------------------------
// <auto-generated>
//     Changes to this file may cause incorrect behavior and will be lost
//     if the code is regenerated.
// </auto-generated>
// ----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Energistics.DataAccess;
using Energistics.DataAccess.WITSML200;
using Energistics.DataAccess.WITSML200.ComponentSchemas;
using Energistics.DataAccess.WITSML200.ReferenceData;
using Energistics.Etp;
using Energistics.Etp.Common;
using Energistics.Etp.v11.Protocol;
using Energistics.Etp.v11.Protocol.Core;
using Energistics.Etp.v11.Protocol.Discovery;
using Energistics.Etp.v11.Protocol.Store;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PDS.WITSMLstudio.Store.Data.ToolErrorTermSets
{
    [TestClass]
    public partial class ToolErrorTermSet200EtpTests : ToolErrorTermSet200TestBase
    {
        partial void BeforeEachTest();

        partial void AfterEachTest();

        protected override void OnTestSetUp()
        {
            EtpSetUp(DevKit.Container);
            BeforeEachTest();
            _server.Start();
        }

        protected override void OnTestCleanUp()
        {
            _server?.Stop();
            EtpCleanUp();
            AfterEachTest();
        }

        [TestMethod]
        public void ToolErrorTermSet200_Ensure_Creates_ToolErrorTermSet_With_Default_Values()
        {
            DevKit.EnsureAndAssert(ToolErrorTermSet);
        }

        [TestMethod]
        public async Task ToolErrorTermSet200_GetResources_Can_Get_All_ToolErrorTermSet_Resources()
        {
            AddParents();
            DevKit.AddAndAssert(ToolErrorTermSet);
            await RequestSessionAndAssert();

            var uri = ToolErrorTermSet.GetUri();
            var parentUri = uri.Parent;

            var folderUri = parentUri.Append(uri.ObjectType);
            await GetResourcesAndAssert(folderUri);
        }

        [TestMethod]
        public async Task ToolErrorTermSet200_PutObject_Can_Add_ToolErrorTermSet()
        {
            AddParents();
            await RequestSessionAndAssert();

            var handler = _client.Handler<IStoreCustomer>();
            var uri = ToolErrorTermSet.GetUri();

            var dataObject = CreateDataObject(uri, ToolErrorTermSet);

            // Get Object Expecting it Not to Exist
            await GetAndAssert(handler, uri, Energistics.Etp.EtpErrorCodes.NotFound);

            // Put Object
            await PutAndAssert(handler, dataObject);

            // Get Object
            var args = await GetAndAssert(handler, uri);

            // Check Data Object XML
            Assert.IsNotNull(args?.Message.DataObject);
            var xml = args.Message.DataObject.GetString();

            var result = Parse<ToolErrorTermSet>(xml);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task ToolErrorTermSet200_PutObject_Can_Update_ToolErrorTermSet()
        {
            AddParents();
            await RequestSessionAndAssert();

            var handler = _client.Handler<IStoreCustomer>();
            var uri = ToolErrorTermSet.GetUri();

            // Add a ExtensionNameValue to Data Object
            var envName = "TestPutObject";
            var env = DevKit.ExtensionNameValue(envName, envName);
            ToolErrorTermSet.ExtensionNameValue = new List<ExtensionNameValue>() {env};

            var dataObject = CreateDataObject(uri, ToolErrorTermSet);

            // Get Object Expecting it Not to Exist
            await GetAndAssert(handler, uri, Energistics.Etp.EtpErrorCodes.NotFound);

            // Put Object for Add
            await PutAndAssert(handler, dataObject);

            // Get Added Object
            var args =await GetAndAssert(handler, uri);

            // Check Added Data Object XML
            Assert.IsNotNull(args?.Message.DataObject);
            var xml = args.Message.DataObject.GetString();

            var result = Parse<ToolErrorTermSet>(xml);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ExtensionNameValue.FirstOrDefault(e => e.Name.Equals(envName)));

            // Remove Comment from Data Object
            result.ExtensionNameValue.Clear();

            var updateDataObject = CreateDataObject(uri, result);

            // Put Object for Update
            await PutAndAssert(handler, updateDataObject);

            // Get Updated Object
            args = await GetAndAssert(handler, uri);

            // Check Added Data Object XML
            Assert.IsNotNull(args?.Message.DataObject);
            var updateXml = args.Message.DataObject.GetString();

            result = Parse<ToolErrorTermSet>(updateXml);
            Assert.IsNotNull(result);

            // Test Data Object overwrite
            Assert.IsNull(result.ExtensionNameValue.FirstOrDefault(e => e.Name.Equals(envName)));
        }

        [TestMethod]
        public async Task ToolErrorTermSet200_DeleteObject_Can_Delete_ToolErrorTermSet()
        {
            AddParents();
            await RequestSessionAndAssert();

            var handler = _client.Handler<IStoreCustomer>();
            var uri = ToolErrorTermSet.GetUri();

            var dataObject = CreateDataObject(uri, ToolErrorTermSet);

            // Get Object Expecting it Not to Exist
            await GetAndAssert(handler, uri, Energistics.Etp.EtpErrorCodes.NotFound);

            // Put Object
            await PutAndAssert(handler, dataObject);

            // Get Object
            var args = await GetAndAssert(handler, uri);

            // Check Data Object XML
            Assert.IsNotNull(args?.Message.DataObject);
            var xml = args.Message.DataObject.GetString();

            var result = Parse<ToolErrorTermSet>(xml);
            Assert.IsNotNull(result);

            // Delete Object
            await DeleteAndAssert(handler, uri);

            // Get Object Expecting it Not to Exist
            await GetAndAssert(handler, uri, Energistics.Etp.EtpErrorCodes.NotFound);
        }
    }
}