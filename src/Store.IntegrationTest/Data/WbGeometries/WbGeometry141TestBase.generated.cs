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
using Energistics.DataAccess.WITSML141;
using Energistics.DataAccess.WITSML141.ComponentSchemas;
using Energistics.DataAccess.WITSML141.ReferenceData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WbGeometry = Energistics.DataAccess.WITSML141.StandAloneWellboreGeometry;
using WbGeometryList = Energistics.DataAccess.WITSML141.WellboreGeometryList;

namespace PDS.WITSMLstudio.Store.Data.WbGeometries
{
    public abstract partial class WbGeometry141TestBase : IntegrationTestFixtureBase<DevKit141Aspect>
    {
        public const string QueryMissingNamespace = "<wbGeometrys version=\"1.4.1.1\"><wbGeometry /></wbGeometrys>";
        public const string QueryInvalidNamespace = "<wbGeometrys xmlns=\"www.witsml.org/schemas/123\" version=\"1.4.1.1\"></wbGeometrys>";
        public const string QueryMissingVersion = "<wbGeometrys xmlns=\"http://www.witsml.org/schemas/1series\"></wbGeometrys>";
        public const string QueryEmptyRoot = "<wbGeometrys xmlns=\"http://www.witsml.org/schemas/1series\" version=\"1.4.1.1\"></wbGeometrys>";
        public const string QueryEmptyObject = "<wbGeometrys xmlns=\"http://www.witsml.org/schemas/1series\" version=\"1.4.1.1\"><wbGeometry /></wbGeometrys>";
        public const string BasicXMLTemplate = "<wbGeometrys xmlns=\"http://www.witsml.org/schemas/1series\" version=\"1.4.1.1\"><wbGeometry uidWell=\"{0}\" uidWellbore=\"{1}\" uid=\"{2}\">{3}</wbGeometry></wbGeometrys>";

        protected WbGeometry141TestBase(bool isEtpTest = false)
            : base(isEtpTest)
        {
        }

        public Well Well { get; set; }
        public Wellbore Wellbore { get; set; }
        public WbGeometry WbGeometry { get; set; }
        public List<WbGeometry> QueryEmptyList { get; set; }

        protected override void PrepareData()
        {

            DevKit.Store.CapServerProviders = DevKit.Store.CapServerProviders
                .Where(x => x.DataSchemaVersion == OptionsIn.DataVersion.Version141.Value)
                .ToArray();

            Well = new Well
            {
                Uid = DevKit.Uid(),
                Name = DevKit.Name("Well"),
                TimeZone = DevKit.TimeZone
            };
            Wellbore = new Wellbore
            {
                Uid = DevKit.Uid(),
                Name = DevKit.Name("Wellbore"),
                UidWell = Well.Uid,
                NameWell = Well.Name,
                MD = new MeasuredDepthCoord(0, MeasuredDepthUom.ft)
            };
            WbGeometry = new WbGeometry
            {
                Uid = DevKit.Uid(),
                Name = DevKit.Name("WbGeometry"),
                UidWell = Well.Uid,
                NameWell = Well.Name,
                UidWellbore = Wellbore.Uid,
                NameWellbore = Wellbore.Name
            };

            QueryEmptyList = DevKit.List(new WbGeometry());

        }

        protected virtual void AddParents()
        {
            DevKit.AddAndAssert<WellList, Well>(Well);
            DevKit.AddAndAssert<WellboreList, Wellbore>(Wellbore);
        }
    }
}