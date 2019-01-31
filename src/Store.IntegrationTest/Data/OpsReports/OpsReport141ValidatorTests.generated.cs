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

namespace PDS.WITSMLstudio.Store.Data.OpsReports
{
    [TestClass]
    public partial class OpsReport141ValidatorTests : OpsReport141TestBase
    {
        #region Error -401

        public static readonly string QueryInvalidPluralRoot =
            "<opsReport xmlns=\"http://www.witsml.org/schemas/1series\" version=\"1.4.1.1\">" + Environment.NewLine +
            "  <opsReport>" + Environment.NewLine +
            "    <name>Test Plural Root Element</name>" + Environment.NewLine +
            "  </opsReport>" + Environment.NewLine +
            "</opsReport>";

        [TestMethod]
        public void OpsReport141Validator_GetFromStore_Error_401_No_Plural_Root_Element()
        {
            var response = DevKit.GetFromStore(ObjectTypes.OpsReport, QueryInvalidPluralRoot, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingPluralRootElement, response.Result);
        }

        [TestMethod]
        public void OpsReport141Validator_AddToStore_Error_401_No_Plural_Root_Element()
        {
            var response = DevKit.AddToStore(ObjectTypes.OpsReport, QueryInvalidPluralRoot, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingPluralRootElement, response?.Result);
        }

        [TestMethod]
        public void OpsReport141Validator_UpdateInStore_Error_401_No_Plural_Root_Element()
        {
            var response = DevKit.UpdateInStore(ObjectTypes.OpsReport, QueryInvalidPluralRoot, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingPluralRootElement, response?.Result);
        }

        [TestMethod]
        public void OpsReport141Validator_DeleteFromStore_Error_401_No_Plural_Root_Element()
        {
            var response = DevKit.DeleteFromStore(ObjectTypes.OpsReport, QueryInvalidPluralRoot, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingPluralRootElement, response?.Result);
        }

        #endregion Error -401

        #region Error -402

        #endregion Error -402

        #region Error -403

        [TestMethod]
        public void OpsReport141Validator_GetFromStore_Error_403_RequestObjectSelectionCapability_True_MissingNamespace()
        {
            var response = DevKit.GetFromStore(ObjectTypes.OpsReport, QueryMissingNamespace, null, optionsIn: OptionsIn.RequestObjectSelectionCapability.True);
            Assert.AreEqual((short)ErrorCodes.MissingDefaultWitsmlNamespace, response.Result);
        }

        [TestMethod]
        public void OpsReport141Validator_GetFromStore_Error_403_RequestObjectSelectionCapability_True_BadNamespace()
        {
            var response = DevKit.GetFromStore(ObjectTypes.OpsReport, QueryInvalidNamespace, null, optionsIn: OptionsIn.RequestObjectSelectionCapability.True);
            Assert.AreEqual((short)ErrorCodes.MissingDefaultWitsmlNamespace, response.Result);
        }

        [TestMethod]
        public void OpsReport141Validator_GetFromStore_Error_403_RequestObjectSelectionCapability_None_BadNamespace()
        {
            var response = DevKit.GetFromStore(ObjectTypes.OpsReport, QueryInvalidNamespace, null, optionsIn: OptionsIn.RequestObjectSelectionCapability.None);
            Assert.AreEqual((short)ErrorCodes.MissingDefaultWitsmlNamespace, response.Result);
        }

        #endregion Error -403

        #region Error -405

        [TestMethod]
        public void OpsReport141Validator_AddToStore_Error_405_OpsReport_Already_Exists()
        {
            AddParents();
            DevKit.AddAndAssert<OpsReportList, OpsReport>(OpsReport);
            DevKit.AddAndAssert<OpsReportList, OpsReport>(OpsReport, ErrorCodes.DataObjectUidAlreadyExists);
        }

        #endregion Error -405

        #region Error -406

        [TestMethod]
        public void OpsReport141Validator_AddToStore_Error_406_OpsReport_Missing_Parent_Uid()
        {
            AddParents();
            OpsReport.UidWellbore = null;
            DevKit.AddAndAssert(OpsReport, ErrorCodes.MissingElementUidForAdd);
        }

        #endregion Error -406

        #region Error -407

        [TestMethod]
        public void OpsReport141Validator_UpdateInStore_Error_407_OpsReport_Missing_Witsml_Object_Type()
        {
            AddParents();
            DevKit.AddAndAssert<OpsReportList, OpsReport>(OpsReport);
            var response = DevKit.Update<OpsReportList, OpsReport>(OpsReport, string.Empty);
            Assert.IsNotNull(response);
            Assert.AreEqual((short)ErrorCodes.MissingWmlTypeIn, response.Result);
        }

        #endregion Error -407

        #region Error -408

        [TestMethod]
        public void OpsReport141Validator_UpdateInStore_Error_408_OpsReport_Empty_QueryIn()
        {
            var response = DevKit.UpdateInStore(ObjectTypes.OpsReport, string.Empty, null, null);
            Assert.IsNotNull(response);
            Assert.AreEqual((short)ErrorCodes.MissingInputTemplate, response.Result);
        }

        #endregion Error -408

        #region Error -409

        [TestMethod]
        public void OpsReport141Validator_AddToStore_Error_409_OpsReport_XmlIn_Must_Conform_To_Schema()
        {
            AddParents();

            var nonConformingXml = string.Format(BasicXMLTemplate, OpsReport.UidWell, OpsReport.UidWellbore, OpsReport.Uid,
                $"<name>{OpsReport.Name}</name><name>{OpsReport.Name}</name>");

            var response = DevKit.AddToStore(ObjectTypes.OpsReport, nonConformingXml, null, null);
            Assert.AreEqual((short)ErrorCodes.InputTemplateNonConforming, response.Result);
        }

        [TestMethod]
        public void OpsReport141Validator_UpdateInStore_Error_409_OpsReport_XmlIn_Must_Conform_To_Schema()
        {
            AddParents();
            DevKit.AddAndAssert<OpsReportList, OpsReport>(OpsReport);

            var nonConformingXml = string.Format(BasicXMLTemplate, OpsReport.UidWell, OpsReport.UidWellbore, OpsReport.Uid,
                $"<name>{OpsReport.Name}</name><name>{OpsReport.Name}</name>");

            var response = DevKit.UpdateInStore(ObjectTypes.OpsReport, nonConformingXml, null, null);
            Assert.AreEqual((short)ErrorCodes.InputTemplateNonConforming, response.Result);
        }

        [TestMethod]
        public void OpsReport141Validator_GetFromStore_Error_409_OpsReport_QueryIn_Must_Conform_To_Schema()
        {
            AddParents();
            DevKit.AddAndAssert<OpsReportList, OpsReport>(OpsReport);

            var nonConformingXml = string.Format(BasicXMLTemplate, OpsReport.UidWell, OpsReport.UidWellbore, OpsReport.Uid,
                $"<name>{OpsReport.Name}</name><name>{OpsReport.Name}</name>");

            var response = DevKit.GetFromStore(ObjectTypes.OpsReport, nonConformingXml, null, null);
            Assert.AreEqual((short)ErrorCodes.InputTemplateNonConforming, response.Result);
        }

        [TestMethod]
        public void OpsReport141Validator_DeleteFromStore_Error_409_OpsReport_QueryIn_Must_Conform_To_Schema()
        {
            AddParents();
            DevKit.AddAndAssert<OpsReportList, OpsReport>(OpsReport);

            var nonConformingXml = string.Format(BasicXMLTemplate, OpsReport.UidWell, OpsReport.UidWellbore, OpsReport.Uid,
                $"<name>{OpsReport.Name}</name><name>{OpsReport.Name}</name>");

            var response = DevKit.DeleteFromStore(ObjectTypes.OpsReport, nonConformingXml, null, null);
            Assert.AreEqual((short)ErrorCodes.InputTemplateNonConforming, response.Result);
        }

        #endregion Error -409

        #region Error -415

        [TestMethod]
        public void OpsReport141Validator_UpdateInStore_Error_415_OpsReport_Update_Without_Specifing_UID()
        {
            AddParents();
            DevKit.AddAndAssert<OpsReportList, OpsReport>(OpsReport);
            OpsReport.Uid = string.Empty;
            DevKit.UpdateAndAssert<OpsReportList, OpsReport>(OpsReport, ErrorCodes.DataObjectUidMissing);
        }

        #endregion Error -415
        #region Error -416

        [TestMethod]
        public void OpsReport141Validator_DeleteFromStore_Error_416_OpsReport_Delete_With_Empty_UID()
        {
            AddParents();
            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");
            OpsReport.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1
                }
            };

            DevKit.AddAndAssert(OpsReport);

            var deleteXml = string.Format(BasicXMLTemplate,OpsReport.UidWell, OpsReport.UidWellbore,OpsReport.Uid,
                "<commonData><extensionNameValue uid=\"\" /></commonData>");

            var results = DevKit.DeleteFromStore(ObjectTypes.OpsReport, deleteXml, null, null);

            Assert.IsNotNull(results);
            Assert.AreEqual((short)ErrorCodes.EmptyUidSpecified, results.Result);
        }

        #endregion Error -416

        #region Error -418

        [TestMethod]
        public void OpsReport141Validator_DeleteFromStore_Error_418_OpsReport_Delete_With_Missing_Uid()
        {
            AddParents();
            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");
            OpsReport.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1
                }
            };

            DevKit.AddAndAssert(OpsReport);

            var deleteXml = string.Format(BasicXMLTemplate,OpsReport.UidWell, OpsReport.UidWellbore,OpsReport.Uid,
                "<commonData><extensionNameValue  uid=\"\" /></commonData>");

            var results = DevKit.DeleteFromStore(ObjectTypes.OpsReport, deleteXml, null, null);

            Assert.IsNotNull(results);
            Assert.AreEqual((short)ErrorCodes.EmptyUidSpecified, results.Result);
        }

        #endregion Error -418

        #region Error -419

        [TestMethod]
        public void OpsReport141Validator_DeleteFromStore_Error_419_OpsReport_Deleting_Empty_NonRecurring_Container_Element()
        {
            AddParents();
            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");
            OpsReport.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1
                }
            };

            DevKit.AddAndAssert(OpsReport);

            var deleteXml = string.Format(BasicXMLTemplate,OpsReport.UidWell, OpsReport.UidWellbore,OpsReport.Uid,
                "<commonData />");

            var results = DevKit.DeleteFromStore(ObjectTypes.OpsReport, deleteXml, null, null);

            Assert.IsNotNull(results);
            Assert.AreEqual((short)ErrorCodes.EmptyNonRecurringElementSpecified, results.Result);
        }

        #endregion Error -419
        #region Error -420

        [TestMethod]
        public void OpsReport141Validator_DeleteFromStore_Error_420_OpsReport_Specifying_A_Non_Recuring_Element_That_Is_Required()
        {
            AddParents();

            DevKit.AddAndAssert(OpsReport);

            var deleteXml = string.Format(BasicXMLTemplate,OpsReport.UidWell, OpsReport.UidWellbore,OpsReport.Uid,
                "<name />");
            var results = DevKit.DeleteFromStore(ObjectTypes.OpsReport, deleteXml, null, null);

            Assert.IsNotNull(results);
            Assert.AreEqual((short)ErrorCodes.EmptyMandatoryNodeSpecified, results.Result);
        }

        #endregion Error -420

        #region Error -426

        [TestMethod]
        public void OpsReport141Validator_AddToStore_Error_426_OpsReport_Compressed_XmlIn_Must_Conform_To_Schema()
        {
            AddParents();

            var nonConformingXml = string.Format(BasicXMLTemplate, OpsReport.UidWell, OpsReport.UidWellbore, OpsReport.Uid,
                $"<name>{OpsReport.Name}</name><name>{OpsReport.Name}</name>");

            var optionsIn = string.Empty;
            ClientCompression.Compress(ref nonConformingXml, ref optionsIn);

            var response = DevKit.AddToStore(ObjectTypes.OpsReport, nonConformingXml, null, optionsIn);
            Assert.AreEqual((short)ErrorCodes.CompressedInputNonConforming, response.Result);
        }

        [TestMethod]
        public void OpsReport141Validator_UpdateInStore_Error_426_OpsReport_Compressed_XmlIn_Must_Conform_To_Schema()
        {
            AddParents();
            DevKit.AddAndAssert<OpsReportList, OpsReport>(OpsReport);

            var nonConformingXml = string.Format(BasicXMLTemplate, OpsReport.UidWell, OpsReport.UidWellbore, OpsReport.Uid,
                $"<name>{OpsReport.Name}</name><name>{OpsReport.Name}</name>");

            var optionsIn = string.Empty;
            ClientCompression.Compress(ref nonConformingXml, ref optionsIn);

            var response = DevKit.UpdateInStore(ObjectTypes.OpsReport, nonConformingXml, null, optionsIn);
            Assert.AreEqual((short)ErrorCodes.CompressedInputNonConforming, response.Result);
        }

        [TestMethod]
        public void OpsReport141Validator_GetFromStore_Error_426_OpsReport_Compressed_QueryIn_Must_Conform_To_Schema()
        {
            AddParents();
            DevKit.AddAndAssert<OpsReportList, OpsReport>(OpsReport);

            var nonConformingXml = string.Format(BasicXMLTemplate, OpsReport.UidWell, OpsReport.UidWellbore, OpsReport.Uid,
                $"<name>{OpsReport.Name}</name><name>{OpsReport.Name}</name>");

            var optionsIn = string.Empty;
            ClientCompression.Compress(ref nonConformingXml, ref optionsIn);

            var response = DevKit.GetFromStore(ObjectTypes.OpsReport, nonConformingXml, null, optionsIn);
            Assert.AreEqual((short)ErrorCodes.CompressedInputNonConforming, response.Result);
        }

        #endregion Error -426

        #region Error -433

        [TestMethod]
        public void OpsReport141Validator_UpdateInStore_Error_433_OpsReport_Does_Not_Exist()
        {
            AddParents();
            DevKit.UpdateAndAssert<OpsReportList, OpsReport>(OpsReport, ErrorCodes.DataObjectNotExist);
        }

        #endregion Error -433

        #region Error -438

        [TestMethod]
        public void OpsReport141Validator_GetFromStore_Error_438_OpsReport_Recurring_Elements_Have_Inconsistent_Selection()
        {
            AddParents();
            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");
            var ext2 = DevKit.ExtensionNameValue("Ext-2", "1.0", "m");

            OpsReport.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1, ext2
                }
            };

            DevKit.AddAndAssert(OpsReport);

            var queryXml = string.Format(BasicXMLTemplate,OpsReport.UidWell, OpsReport.UidWellbore,OpsReport.Uid,
                "<commonData>" +
                $"<extensionNameValue uid=\"\"><name>Ext-1</name></extensionNameValue>" +
                "<extensionNameValue uid=\"\"><value uom=\"\">1.0</value></extensionNameValue>" +
                "</commonData>");

            var results = DevKit.GetFromStore(ObjectTypes.OpsReport, queryXml, null, null);

            Assert.IsNotNull(results);
            Assert.AreEqual((short)ErrorCodes.RecurringItemsInconsistentSelection, results.Result);
        }

        #endregion Error -438

        #region Error -439

        [TestMethod]
        public void OpsReport141Validator_GetFromStore_Error_439_OpsReport_Recurring_Elements_Has_Empty_Selection_Value()
        {
            AddParents();
            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");
            var ext2 = DevKit.ExtensionNameValue("Ext-2", "1.0", "m");

            OpsReport.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1, ext2
                }
            };

            DevKit.AddAndAssert(OpsReport);

            var queryXml = string.Format(BasicXMLTemplate,OpsReport.UidWell, OpsReport.UidWellbore,OpsReport.Uid,
                "<commonData>" +
                $"<extensionNameValue uid=\"\"><name>Ext-1</name></extensionNameValue>" +
                "<extensionNameValue uid=\"\"><name></name></extensionNameValue>" +
                "</commonData>");

            var results = DevKit.GetFromStore(ObjectTypes.OpsReport, queryXml, null, null);

            Assert.IsNotNull(results);
            Assert.AreEqual((short)ErrorCodes.RecurringItemsEmptySelection, results.Result);
        }

        #endregion Error -439
        #region Error -444

        [TestMethod]
        public void OpsReport141Validator_UpdateInStore_Error_444_OpsReport_Updating_More_Than_One_Data_Object()
        {
            AddParents();
            DevKit.AddAndAssert<OpsReportList, OpsReport>(OpsReport);
            var updateXml = "<opsReports xmlns=\"http://www.witsml.org/schemas/1series\" version=\"1.4.1.1\"><opsReport uidWell=\"{0}\" uidWellbore=\"{1}\" uid=\"{2}\"></opsReport><opsReport uidWell=\"{0}\" uidWellbore=\"{1}\" uid=\"{2}\"></opsReport></opsReports>";
            updateXml = string.Format(updateXml, OpsReport.UidWell, OpsReport.UidWellbore, OpsReport.Uid);

            var response = DevKit.UpdateInStore(ObjectTypes.OpsReport, updateXml, null, null);
            Assert.AreEqual((short)ErrorCodes.InputTemplateMultipleDataObjects, response.Result);
        }

        #endregion Error -444

        #region Error -445

        [TestMethod]
        public void OpsReport141Validator_UpdateInStore_Error_445_OpsReport_Empty_New_Element()
        {
            AddParents();
            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");

            OpsReport.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1
                }
            };

            DevKit.AddAndAssert(OpsReport);

            ext1 = DevKit.ExtensionNameValue("Ext-1", string.Empty, string.Empty, PrimitiveType.@double, string.Empty);
            OpsReport.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1
                }
            };

            DevKit.UpdateAndAssert(OpsReport, ErrorCodes.EmptyNewElementsOrAttributes);
        }

        #endregion Error -445

        #region Error -448

        [TestMethod]
        public void OpsReport141Validator_UpdateInStore_Error_448_OpsReport_Missing_Uid()
        {
            AddParents();
            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");

            OpsReport.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1
                }
            };

            DevKit.AddAndAssert(OpsReport);

            var updateXml = string.Format(BasicXMLTemplate,OpsReport.UidWell, OpsReport.UidWellbore,OpsReport.Uid,
                "<commonData>" +
                $"<extensionNameValue uid=\"\"><value uom=\"ft\" /></extensionNameValue>" +
                "</commonData>");

            var response = DevKit.UpdateInStore(ObjectTypes.OpsReport, updateXml, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingElementUidForUpdate, response.Result);
        }

        #endregion Error -448

        #region Error -464

        [TestMethod]
        public void OpsReport141Validator_AddToStore_Error_464_OpsReport_Uid_Not_Unique()
        {
            AddParents();
            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");
            var ext2 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");

            OpsReport.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1, ext2
                }
            };

            DevKit.AddAndAssert(OpsReport, ErrorCodes.ChildUidNotUnique);
        }

        [TestMethod]
        public void OpsReport141Validator_UpdateInStore_Error_464_OpsReport_Uid_Not_Unique()
        {
            AddParents();
            var ext1 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");

            OpsReport.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1
                }
            };

            DevKit.AddAndAssert(OpsReport);

            var ext2 = DevKit.ExtensionNameValue("Ext-1", "1.0", "m");

            OpsReport.CommonData = new CommonData
            {
                ExtensionNameValue = new List<ExtensionNameValue>
                {
                    ext1, ext2
                }
            };

            DevKit.UpdateAndAssert(OpsReport, ErrorCodes.ChildUidNotUnique);
        }

        #endregion Error -464
        #region Error -468

        [TestMethod]
        public void OpsReport141Validator_UpdateInStore_Error_468_OpsReport_No_Schema_Version_Declared()
        {
            AddParents();
            DevKit.AddAndAssert<OpsReportList, OpsReport>(OpsReport);
            var response = DevKit.UpdateInStore(ObjectTypes.OpsReport, QueryMissingVersion, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingDataSchemaVersion, response.Result);
        }

        #endregion Error -468

        #region Error -478

        [TestMethod]
        public void OpsReport141Validator_AddToStore_Error_478_OpsReport_Parent_Uid_Case_Not_Matching()
        {
            Well.Uid = Well.Uid.ToUpper();
            Wellbore.Uid = Wellbore.Uid.ToUpper();
            Wellbore.UidWell = Well.Uid.ToUpper();
            AddParents();

            OpsReport.UidWell = Well.Uid.ToLower();

            DevKit.AddAndAssert(OpsReport, ErrorCodes.IncorrectCaseParentUid);
        }

        #endregion Error -478

        #region Error -479

        [TestMethod]
        public void OpsReport141Validator_AddToStore_Error_479_OpsReport_Cannot_Decompress_XmlIn()
        {
            AddParents();

            var uncompressedXml = "abcd1234";
            var compressedXml = uncompressedXml;

            var optionsIn = string.Empty;
            ClientCompression.Compress(ref compressedXml, ref optionsIn);

            var response = DevKit.AddToStore(ObjectTypes.OpsReport, uncompressedXml, null, optionsIn);
            Assert.AreEqual((short)ErrorCodes.CannotDecompressQuery, response.Result);
        }

        [TestMethod]
        public void OpsReport141Validator_UpdateInStore_Error_479_OpsReport_Cannot_Decompress_XmlIn()
        {
            AddParents();
            DevKit.AddAndAssert<OpsReportList, OpsReport>(OpsReport);

            var uncompressedXml = "abcd1234";
            var compressedXml = uncompressedXml;

            var optionsIn = string.Empty;
            ClientCompression.Compress(ref compressedXml, ref optionsIn);

            var response = DevKit.UpdateInStore(ObjectTypes.OpsReport, uncompressedXml, null, optionsIn);
            Assert.AreEqual((short)ErrorCodes.CannotDecompressQuery, response.Result);
        }

        [TestMethod]
        public void OpsReport141Validator_GetFromStore_Error_479_OpsReport_Cannot_Decompress_XmlIn()
        {
            AddParents();
            DevKit.AddAndAssert<OpsReportList, OpsReport>(OpsReport);

            var uncompressedXml = "abcd1234";
            var compressedXml = uncompressedXml;

            var optionsIn = string.Empty;
            ClientCompression.Compress(ref compressedXml, ref optionsIn);

            var response = DevKit.GetFromStore(ObjectTypes.OpsReport, uncompressedXml, null, optionsIn);
            Assert.AreEqual((short)ErrorCodes.CannotDecompressQuery, response.Result);
        }

        #endregion Error -479

        #region Error -481

        [TestMethod]
        public void OpsReport141Validator_AddToStore_Error_481_OpsReport_Parent_Does_Not_Exist()
        {
            DevKit.AddAndAssert(OpsReport, ErrorCodes.MissingParentDataObject);
        }

        #endregion Error -481

        #region Error -483

        [TestMethod]
        public void OpsReport141Validator_UpdateInStore_Error_483_OpsReport_Update_With_Non_Conforming_Template()
        {
            AddParents();
            DevKit.AddAndAssert<OpsReportList, OpsReport>(OpsReport);
            var response = DevKit.UpdateInStore(ObjectTypes.OpsReport, QueryEmptyRoot, null, null);
            Assert.AreEqual((short)ErrorCodes.UpdateTemplateNonConforming, response.Result);
        }

        #endregion Error -483

        #region Error -484

        [TestMethod]
        public void OpsReport141Validator_UpdateInStore_Error_484_OpsReport_Update_Will_Delete_Required_Element()
        {
            AddParents();
            DevKit.AddAndAssert<OpsReportList, OpsReport>(OpsReport);
            var nonConformingXml = string.Format(BasicXMLTemplate, OpsReport.UidWell, OpsReport.UidWellbore, OpsReport.Uid,
                $"<name></name>");

            var response = DevKit.UpdateInStore(ObjectTypes.OpsReport, nonConformingXml, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingRequiredData, response.Result);
        }

        #endregion Error -484

        #region Error -486

        [TestMethod]
        public void OpsReport141Validator_AddToStore_Error_486_OpsReport_Data_Object_Types_Dont_Match()
        {
            AddParents();

            var xmlIn = string.Format(BasicXMLTemplate, OpsReport.UidWell, OpsReport.UidWellbore, OpsReport.Uid,
                string.Empty);

            var response = DevKit.AddToStore(ObjectTypes.Well, xmlIn, null, null);
            Assert.AreEqual((short)ErrorCodes.DataObjectTypesDontMatch, response.Result);
        }

        #endregion Error -486
    }
}