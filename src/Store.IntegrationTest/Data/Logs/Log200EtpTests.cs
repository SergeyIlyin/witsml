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

using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PDS.WITSMLstudio.Store.Data.Logs
{
    /// <summary>
    /// Log200EtpTests
    /// </summary>
    public partial class Log200EtpTests
    {
        [TestMethod]
        public async Task Log200_GetResources_Can_Get_Log_Folder_Resources()
        {
            AddParents();
            DevKit.AddAndAssert(Log);

            await RequestSessionAndAssert();

            var uri = Log.GetUri();
            var folderUri = uri.Parent.Append(ObjectTypes.Log);
            await GetResourcesAndAssert(folderUri);
        }
    }
}
