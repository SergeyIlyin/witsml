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
using Energistics.DataAccess.WITSML131;
using Energistics.DataAccess.WITSML131.ComponentSchemas;
using Energistics.DataAccess.WITSML131.ReferenceData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PDS.WITSMLstudio.Store.Data.BhaRuns
{
    [TestClass]
    public partial class BhaRun131ValidatorTests : BhaRun131TestBase
    {
        #region Error -401

        public static readonly string QueryInvalidPluralRoot =
            "<bhaRun xmlns=\"http://www.witsml.org/schemas/131\" version=\"1.3.1.1\">" + Environment.NewLine +
            "  <bhaRun>" + Environment.NewLine +
            "    <name>Test Plural Root Element</name>" + Environment.NewLine +
            "  </bhaRun>" + Environment.NewLine +
            "</bhaRun>";

        [TestMethod]
        public void BhaRun131Validator_GetFromStore_Error_401_No_Plural_Root_Element()
        {
            var response = DevKit.GetFromStore(ObjectTypes.BhaRun, QueryInvalidPluralRoot, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingPluralRootElement, response.Result);
        }

        [TestMethod]
        public void BhaRun131Validator_AddToStore_Error_401_No_Plural_Root_Element()
        {
            var response = DevKit.AddToStore(ObjectTypes.BhaRun, QueryInvalidPluralRoot, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingPluralRootElement, response?.Result);
        }

        [TestMethod]
        public void BhaRun131Validator_UpdateInStore_Error_401_No_Plural_Root_Element()
        {
            var response = DevKit.UpdateInStore(ObjectTypes.BhaRun, QueryInvalidPluralRoot, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingPluralRootElement, response?.Result);
        }

        [TestMethod]
        public void BhaRun131Validator_DeleteFromStore_Error_401_No_Plural_Root_Element()
        {
            var response = DevKit.DeleteFromStore(ObjectTypes.BhaRun, QueryInvalidPluralRoot, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingPluralRootElement, response?.Result);
        }

        #endregion Error -401

        #region Error -402

        #endregion Error -402

        #region Error -403

        [TestMethod]
        public void BhaRun131Validator_GetFromStore_Error_403_RequestObjectSelectionCapability_True_MissingNamespace()
        {
            var response = DevKit.GetFromStore(ObjectTypes.BhaRun, QueryMissingNamespace, null, optionsIn: OptionsIn.RequestObjectSelectionCapability.True);
            Assert.AreEqual((short)ErrorCodes.MissingDefaultWitsmlNamespace, response.Result);
        }

        [TestMethod]
        public void BhaRun131Validator_GetFromStore_Error_403_RequestObjectSelectionCapability_True_BadNamespace()
        {
            var response = DevKit.GetFromStore(ObjectTypes.BhaRun, QueryInvalidNamespace, null, optionsIn: OptionsIn.RequestObjectSelectionCapability.True);
            Assert.AreEqual((short)ErrorCodes.MissingDefaultWitsmlNamespace, response.Result);
        }

        [TestMethod]
        public void BhaRun131Validator_GetFromStore_Error_403_RequestObjectSelectionCapability_None_BadNamespace()
        {
            var response = DevKit.GetFromStore(ObjectTypes.BhaRun, QueryInvalidNamespace, null, optionsIn: OptionsIn.RequestObjectSelectionCapability.None);
            Assert.AreEqual((short)ErrorCodes.MissingDefaultWitsmlNamespace, response.Result);
        }

        #endregion Error -403

        #region Error -405

        [TestMethod]
        public void BhaRun131Validator_AddToStore_Error_405_BhaRun_Already_Exists()
        {
            AddParents();
            DevKit.AddAndAssert<BhaRunList, BhaRun>(BhaRun);
            DevKit.AddAndAssert<BhaRunList, BhaRun>(BhaRun, ErrorCodes.DataObjectUidAlreadyExists);
        }

        #endregion Error -405

        #region Error -406

        [TestMethod]
        public void BhaRun131Validator_AddToStore_Error_406_BhaRun_Missing_Parent_Uid()
        {
            AddParents();
            BhaRun.UidWellbore = null;
            DevKit.AddAndAssert(BhaRun, ErrorCodes.MissingElementUidForAdd);
        }

        #endregion Error -406

        #region Error -407

        [TestMethod]
        public void BhaRun131Validator_UpdateInStore_Error_407_BhaRun_Missing_Witsml_Object_Type()
        {
            AddParents();
            DevKit.AddAndAssert<BhaRunList, BhaRun>(BhaRun);
            var response = DevKit.Update<BhaRunList, BhaRun>(BhaRun, string.Empty);
            Assert.IsNotNull(response);
            Assert.AreEqual((short)ErrorCodes.MissingWmlTypeIn, response.Result);
        }

        #endregion Error -407

        #region Error -408

        [TestMethod]
        public void BhaRun131Validator_UpdateInStore_Error_408_BhaRun_Empty_QueryIn()
        {
            var response = DevKit.UpdateInStore(ObjectTypes.BhaRun, string.Empty, null, null);
            Assert.IsNotNull(response);
            Assert.AreEqual((short)ErrorCodes.MissingInputTemplate, response.Result);
        }

        #endregion Error -408

        #region Error -409

        [TestMethod]
        public void BhaRun131Validator_AddToStore_Error_409_BhaRun_XmlIn_Must_Conform_To_Schema()
        {
            AddParents();

            var nonConformingXml = string.Format(BasicXMLTemplate, BhaRun.UidWell, BhaRun.UidWellbore, BhaRun.Uid,
                $"<name>{BhaRun.Name}</name><name>{BhaRun.Name}</name>");

            var response = DevKit.AddToStore(ObjectTypes.BhaRun, nonConformingXml, null, null);
            Assert.AreEqual((short)ErrorCodes.InputTemplateNonConforming, response.Result);
        }

        [TestMethod]
        public void BhaRun131Validator_UpdateInStore_Error_409_BhaRun_XmlIn_Must_Conform_To_Schema()
        {
            AddParents();
            DevKit.AddAndAssert<BhaRunList, BhaRun>(BhaRun);

            var nonConformingXml = string.Format(BasicXMLTemplate, BhaRun.UidWell, BhaRun.UidWellbore, BhaRun.Uid,
                $"<name>{BhaRun.Name}</name><name>{BhaRun.Name}</name>");

            var response = DevKit.UpdateInStore(ObjectTypes.BhaRun, nonConformingXml, null, null);
            Assert.AreEqual((short)ErrorCodes.InputTemplateNonConforming, response.Result);
        }

        [TestMethod]
        public void BhaRun131Validator_GetFromStore_Error_409_BhaRun_QueryIn_Must_Conform_To_Schema()
        {
            AddParents();
            DevKit.AddAndAssert<BhaRunList, BhaRun>(BhaRun);

            var nonConformingXml = string.Format(BasicXMLTemplate, BhaRun.UidWell, BhaRun.UidWellbore, BhaRun.Uid,
                $"<name>{BhaRun.Name}</name><name>{BhaRun.Name}</name>");

            var response = DevKit.GetFromStore(ObjectTypes.BhaRun, nonConformingXml, null, null);
            Assert.AreEqual((short)ErrorCodes.InputTemplateNonConforming, response.Result);
        }

        [TestMethod]
        public void BhaRun131Validator_DeleteFromStore_Error_409_BhaRun_QueryIn_Must_Conform_To_Schema()
        {
            AddParents();
            DevKit.AddAndAssert<BhaRunList, BhaRun>(BhaRun);

            var nonConformingXml = string.Format(BasicXMLTemplate, BhaRun.UidWell, BhaRun.UidWellbore, BhaRun.Uid,
                $"<name>{BhaRun.Name}</name><name>{BhaRun.Name}</name>");

            var response = DevKit.DeleteFromStore(ObjectTypes.BhaRun, nonConformingXml, null, null);
            Assert.AreEqual((short)ErrorCodes.InputTemplateNonConforming, response.Result);
        }

        #endregion Error -409

        #region Error -415

        [TestMethod]
        public void BhaRun131Validator_UpdateInStore_Error_415_BhaRun_Update_Without_Specifing_UID()
        {
            AddParents();
            DevKit.AddAndAssert<BhaRunList, BhaRun>(BhaRun);
            BhaRun.Uid = string.Empty;
            DevKit.UpdateAndAssert<BhaRunList, BhaRun>(BhaRun, ErrorCodes.DataObjectUidMissing);
        }

        #endregion Error -415
        #region Error -420

        [TestMethod]
        public void BhaRun131Validator_DeleteFromStore_Error_420_BhaRun_Specifying_A_Non_Recuring_Element_That_Is_Required()
        {
            AddParents();

            DevKit.AddAndAssert(BhaRun);

            var deleteXml = string.Format(BasicXMLTemplate,BhaRun.UidWell, BhaRun.UidWellbore,BhaRun.Uid,
                "<name />");
            var results = DevKit.DeleteFromStore(ObjectTypes.BhaRun, deleteXml, null, null);

            Assert.IsNotNull(results);
            Assert.AreEqual((short)ErrorCodes.EmptyMandatoryNodeSpecified, results.Result);
        }

        #endregion Error -420

        #region Error -426

        [TestMethod]
        public void BhaRun131Validator_AddToStore_Error_426_BhaRun_Compressed_XmlIn_Must_Conform_To_Schema()
        {
            AddParents();

            var nonConformingXml = string.Format(BasicXMLTemplate, BhaRun.UidWell, BhaRun.UidWellbore, BhaRun.Uid,
                $"<name>{BhaRun.Name}</name><name>{BhaRun.Name}</name>");

            var optionsIn = string.Empty;
            ClientCompression.Compress(ref nonConformingXml, ref optionsIn);

            var response = DevKit.AddToStore(ObjectTypes.BhaRun, nonConformingXml, null, optionsIn);
            Assert.AreEqual((short)ErrorCodes.CompressedInputNonConforming, response.Result);
        }

        [TestMethod]
        public void BhaRun131Validator_UpdateInStore_Error_426_BhaRun_Compressed_XmlIn_Must_Conform_To_Schema()
        {
            AddParents();
            DevKit.AddAndAssert<BhaRunList, BhaRun>(BhaRun);

            var nonConformingXml = string.Format(BasicXMLTemplate, BhaRun.UidWell, BhaRun.UidWellbore, BhaRun.Uid,
                $"<name>{BhaRun.Name}</name><name>{BhaRun.Name}</name>");

            var optionsIn = string.Empty;
            ClientCompression.Compress(ref nonConformingXml, ref optionsIn);

            var response = DevKit.UpdateInStore(ObjectTypes.BhaRun, nonConformingXml, null, optionsIn);
            Assert.AreEqual((short)ErrorCodes.CompressedInputNonConforming, response.Result);
        }

        [TestMethod]
        public void BhaRun131Validator_GetFromStore_Error_426_BhaRun_Compressed_QueryIn_Must_Conform_To_Schema()
        {
            AddParents();
            DevKit.AddAndAssert<BhaRunList, BhaRun>(BhaRun);

            var nonConformingXml = string.Format(BasicXMLTemplate, BhaRun.UidWell, BhaRun.UidWellbore, BhaRun.Uid,
                $"<name>{BhaRun.Name}</name><name>{BhaRun.Name}</name>");

            var optionsIn = string.Empty;
            ClientCompression.Compress(ref nonConformingXml, ref optionsIn);

            var response = DevKit.GetFromStore(ObjectTypes.BhaRun, nonConformingXml, null, optionsIn);
            Assert.AreEqual((short)ErrorCodes.CompressedInputNonConforming, response.Result);
        }

        #endregion Error -426

        #region Error -433

        [TestMethod]
        public void BhaRun131Validator_UpdateInStore_Error_433_BhaRun_Does_Not_Exist()
        {
            AddParents();
            DevKit.UpdateAndAssert<BhaRunList, BhaRun>(BhaRun, ErrorCodes.DataObjectNotExist);
        }

        #endregion Error -433
        #region Error -444

        [TestMethod]
        public void BhaRun131Validator_UpdateInStore_Error_444_BhaRun_Updating_More_Than_One_Data_Object()
        {
            AddParents();
            DevKit.AddAndAssert<BhaRunList, BhaRun>(BhaRun);
            var updateXml = "<bhaRuns xmlns=\"http://www.witsml.org/schemas/131\" version=\"1.3.1.1\"><bhaRun uidWell=\"{0}\" uidWellbore=\"{1}\" uid=\"{2}\"></bhaRun><bhaRun uidWell=\"{0}\" uidWellbore=\"{1}\" uid=\"{2}\"></bhaRun></bhaRuns>";
            updateXml = string.Format(updateXml, BhaRun.UidWell, BhaRun.UidWellbore, BhaRun.Uid);

            var response = DevKit.UpdateInStore(ObjectTypes.BhaRun, updateXml, null, null);
            Assert.AreEqual((short)ErrorCodes.InputTemplateMultipleDataObjects, response.Result);
        }

        #endregion Error -444
        #region Error -468

        [TestMethod]
        public void BhaRun131Validator_UpdateInStore_Error_468_BhaRun_No_Schema_Version_Declared()
        {
            AddParents();
            DevKit.AddAndAssert<BhaRunList, BhaRun>(BhaRun);
            var response = DevKit.UpdateInStore(ObjectTypes.BhaRun, QueryMissingVersion, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingDataSchemaVersion, response.Result);
        }

        #endregion Error -468

        #region Error -478

        [TestMethod]
        public void BhaRun131Validator_AddToStore_Error_478_BhaRun_Parent_Uid_Case_Not_Matching()
        {
            Well.Uid = Well.Uid.ToUpper();
            Wellbore.Uid = Wellbore.Uid.ToUpper();
            Wellbore.UidWell = Well.Uid.ToUpper();
            AddParents();

            BhaRun.UidWell = Well.Uid.ToLower();

            DevKit.AddAndAssert(BhaRun, ErrorCodes.IncorrectCaseParentUid);
        }

        #endregion Error -478

        #region Error -479

        [TestMethod]
        public void BhaRun131Validator_AddToStore_Error_479_BhaRun_Cannot_Decompress_XmlIn()
        {
            AddParents();

            var uncompressedXml = "abcd1234";
            var compressedXml = uncompressedXml;

            var optionsIn = string.Empty;
            ClientCompression.Compress(ref compressedXml, ref optionsIn);

            var response = DevKit.AddToStore(ObjectTypes.BhaRun, uncompressedXml, null, optionsIn);
            Assert.AreEqual((short)ErrorCodes.CannotDecompressQuery, response.Result);
        }

        [TestMethod]
        public void BhaRun131Validator_UpdateInStore_Error_479_BhaRun_Cannot_Decompress_XmlIn()
        {
            AddParents();
            DevKit.AddAndAssert<BhaRunList, BhaRun>(BhaRun);

            var uncompressedXml = "abcd1234";
            var compressedXml = uncompressedXml;

            var optionsIn = string.Empty;
            ClientCompression.Compress(ref compressedXml, ref optionsIn);

            var response = DevKit.UpdateInStore(ObjectTypes.BhaRun, uncompressedXml, null, optionsIn);
            Assert.AreEqual((short)ErrorCodes.CannotDecompressQuery, response.Result);
        }

        [TestMethod]
        public void BhaRun131Validator_GetFromStore_Error_479_BhaRun_Cannot_Decompress_XmlIn()
        {
            AddParents();
            DevKit.AddAndAssert<BhaRunList, BhaRun>(BhaRun);

            var uncompressedXml = "abcd1234";
            var compressedXml = uncompressedXml;

            var optionsIn = string.Empty;
            ClientCompression.Compress(ref compressedXml, ref optionsIn);

            var response = DevKit.GetFromStore(ObjectTypes.BhaRun, uncompressedXml, null, optionsIn);
            Assert.AreEqual((short)ErrorCodes.CannotDecompressQuery, response.Result);
        }

        #endregion Error -479

        #region Error -481

        [TestMethod]
        public void BhaRun131Validator_AddToStore_Error_481_BhaRun_Parent_Does_Not_Exist()
        {
            DevKit.AddAndAssert(BhaRun, ErrorCodes.MissingParentDataObject);
        }

        #endregion Error -481

        #region Error -483

        [TestMethod]
        public void BhaRun131Validator_UpdateInStore_Error_483_BhaRun_Update_With_Non_Conforming_Template()
        {
            AddParents();
            DevKit.AddAndAssert<BhaRunList, BhaRun>(BhaRun);
            var response = DevKit.UpdateInStore(ObjectTypes.BhaRun, QueryEmptyRoot, null, null);
            Assert.AreEqual((short)ErrorCodes.UpdateTemplateNonConforming, response.Result);
        }

        #endregion Error -483

        #region Error -484

        [TestMethod]
        public void BhaRun131Validator_UpdateInStore_Error_484_BhaRun_Update_Will_Delete_Required_Element()
        {
            AddParents();
            DevKit.AddAndAssert<BhaRunList, BhaRun>(BhaRun);
            var nonConformingXml = string.Format(BasicXMLTemplate, BhaRun.UidWell, BhaRun.UidWellbore, BhaRun.Uid,
                $"<name></name>");

            var response = DevKit.UpdateInStore(ObjectTypes.BhaRun, nonConformingXml, null, null);
            Assert.AreEqual((short)ErrorCodes.MissingRequiredData, response.Result);
        }

        #endregion Error -484

        #region Error -486

        [TestMethod]
        public void BhaRun131Validator_AddToStore_Error_486_BhaRun_Data_Object_Types_Dont_Match()
        {
            AddParents();

            var xmlIn = string.Format(BasicXMLTemplate, BhaRun.UidWell, BhaRun.UidWellbore, BhaRun.Uid,
                string.Empty);

            var response = DevKit.AddToStore(ObjectTypes.Well, xmlIn, null, null);
            Assert.AreEqual((short)ErrorCodes.DataObjectTypesDontMatch, response.Result);
        }

        #endregion Error -486
    }
}