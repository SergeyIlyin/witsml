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
using System;
using System.Collections.Generic;
using System.Linq;
using Energistics.DataAccess;
using Energistics.DataAccess.WITSML200;
using Energistics.DataAccess.WITSML200.ComponentSchemas;
using Energistics.DataAccess.WITSML200.ReferenceData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PDS.WITSMLstudio.Store.Data.FluidsReports
{
    public abstract partial class FluidsReport200TestBase : IntegrationTestFixtureBase<DevKit200Aspect>
    {

        protected FluidsReport200TestBase(bool isEtpTest = false)
            : base(isEtpTest)
        {
        }

        public Well Well { get; set; }
        public Wellbore Wellbore { get; set; }
        public FluidsReport FluidsReport { get; set; }

        protected override void PrepareData()
        {

            Well = new Well
            {
                Uuid = DevKit.Uid(),
                Citation = DevKit.Citation("Well"),
                GeographicLocationWGS84 = DevKit.Location(),
                SchemaVersion = "2.0",
                TimeZone = DevKit.TimeZone
            };
            Wellbore = new Wellbore
            {
                Uuid = DevKit.Uid(),
                Citation = DevKit.Citation("Wellbore"),
                Well = DevKit.DataObjectReference(Well),
                SchemaVersion = "2.0"
            };
            FluidsReport = new FluidsReport
            {
                Uuid = DevKit.Uid(),
                Citation = DevKit.Citation("FluidsReport"),
                Wellbore = DevKit.DataObjectReference(Wellbore),
                SchemaVersion = EtpUris.GetUriFamily(typeof(FluidsReport)).Version,
            };

        }

        protected virtual void AddParents()
        {
            DevKit.AddAndAssert(Well);
            DevKit.AddAndAssert(Wellbore);
        }
    }
}