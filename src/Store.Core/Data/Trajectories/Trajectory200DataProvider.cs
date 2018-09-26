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

using Energistics.DataAccess.WITSML200;
using Energistics.DataAccess.WITSML200.ReferenceData;
using Energistics.Etp.Common.Datatypes;

namespace PDS.WITSMLstudio.Store.Data.Trajectories
{
    /// <summary>
    /// Data provider that implements support for ETP API functions for <see cref="Trajectory"/>.
    /// </summary>
    public partial class Trajectory200DataProvider
    {
        /// <summary>
        /// Sets the additional default values.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        partial void SetAdditionalDefaultValues(Trajectory dataObject)
        {
            dataObject.GrowingStatus = dataObject.GrowingStatus ?? ChannelStatus.inactive;
        }

        /// <summary>
        /// Sets the additional default values.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        /// <param name="uri">The URI.</param>
        partial void SetAdditionalDefaultValues(Trajectory dataObject, EtpUri uri)
        {
            dataObject.GrowingStatus = dataObject.GrowingStatus ?? ChannelStatus.inactive;
        }
    }
}
