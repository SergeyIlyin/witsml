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

using Energistics.DataAccess.WITSML131.ComponentSchemas;
using Energistics.DataAccess.WITSML131.ReferenceData;
using PDS.WITSMLstudio.Compatibility;
using PDS.WITSMLstudio.Store.Configuration;

namespace PDS.WITSMLstudio.Store.Data.Logs
{
    /// <summary>
    /// Log131TestBase
    /// </summary>
    public partial class Log131TestBase
    {
        partial void BeforeEachTest()
        {
            Log.IndexType = LogIndexType.measureddepth;
            Log.IndexCurve = new IndexCurve
            {
                ColumnIndex = 0,
                Value = "MD"
            };
        }

        partial void AfterEachTest()
        {
            CompatibilitySettings.AllowDuplicateNonRecurringElements = DevKitAspect.DefaultAllowDuplicateNonRecurringElements;
            CompatibilitySettings.LogAllowPutObjectWithData = DevKitAspect.DefaultLogAllowPutObjectWithData;
            CompatibilitySettings.InvalidDataRowSetting = DevKitAspect.DefaultInvalidDataRowSetting;
            CompatibilitySettings.UnknownElementSetting = DevKitAspect.DefaultUnknownElementSetting;

            WitsmlSettings.DepthRangeSize = DevKitAspect.DefaultDepthChunkRange;
            WitsmlSettings.TimeRangeSize = DevKitAspect.DefaultTimeChunkRange;
            WitsmlSettings.LogMaxDataPointsGet = DevKitAspect.DefaultLogMaxDataPointsGet;
            WitsmlSettings.LogMaxDataPointsUpdate = DevKitAspect.DefaultLogMaxDataPointsAdd;
            WitsmlSettings.LogMaxDataPointsAdd = DevKitAspect.DefaultLogMaxDataPointsUpdate;
            WitsmlSettings.LogMaxDataPointsDelete = DevKitAspect.DefaultLogMaxDataPointsDelete;
            WitsmlSettings.LogMaxDataNodesGet = DevKitAspect.DefaultLogMaxDataNodesGet;
            WitsmlSettings.LogMaxDataNodesAdd = DevKitAspect.DefaultLogMaxDataNodesAdd;
            WitsmlSettings.LogMaxDataNodesUpdate = DevKitAspect.DefaultLogMaxDataNodesUpdate;
            WitsmlSettings.LogMaxDataNodesDelete = DevKitAspect.DefaultLogMaxDataNodesDelete;
            WitsmlSettings.LogGrowingTimeoutPeriod = DevKitAspect.DefaultLogGrowingTimeoutPeriod;
            WitsmlSettings.MaxDataLength = DevKitAspect.DefaultMaxDataLength;
            WitsmlOperationContext.Current = null;
        }
    }
}
