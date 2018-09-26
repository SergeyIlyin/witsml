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

using System.Collections.Generic;
using System.Linq;
using Energistics.DataAccess.WITSML141.ComponentSchemas;
using Energistics.DataAccess.WITSML141.ReferenceData;
using PDS.WITSMLstudio.Compatibility;
using PDS.WITSMLstudio.Store.Configuration;

namespace PDS.WITSMLstudio.Store.Data.Logs
{
    /// <summary>
    /// Log141TestBase
    /// </summary>
    public partial class Log141TestBase
    {
        partial void BeforeEachTest()
        {
            Log.IndexType = LogIndexType.measureddepth;
            Log.IndexCurve = "MD";
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

        public static List<LogData> GenerateSparseLogData(double indexValue, string indexCurve, List<LogCurveInfo> logCurveInfos)
        {
            return logCurveInfos.Select((t, i) => new LogData()
            {
                MnemonicList = $"{indexCurve},{t.Mnemonic.Value}",
                UnitList = $"m,{t.Unit}",
                Data = new List<string>()
                {
                    $"{indexValue - i},{i}"
                }
            }).ToList();
        }
    }
}
