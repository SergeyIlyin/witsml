﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PDS.Witsml.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PDS.Witsml.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The capClient apiVers value must match the API schema version..
        /// </summary>
        internal static string ApiVersionNotMatch {
            get {
                return ResourceManager.GetString("ApiVersionNotMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The server does not support the API Version provided by the client..
        /// </summary>
        internal static string ApiVersionNotSupported {
            get {
                return ResourceManager.GetString("ApiVersionNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to For systematically growing data-objects, the column-identifier (mnemonic) values must not contain one of the following special characters: single-quote, double-quote, less than, greater than, forward slash, backward slash, ampersand, comma..
        /// </summary>
        internal static string BadColumnIdentifier {
            get {
                return ResourceManager.GetString("BadColumnIdentifier", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The CapabilitiesIn XML MUST conform to the API capClient schema..
        /// </summary>
        internal static string CapabilitiesInNonConforming {
            get {
                return ResourceManager.GetString("CapabilitiesInNonConforming", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Each lower level child uid value must be unique within the context of its nearest recurring parent node..
        /// </summary>
        internal static string ChildUidNotUnique {
            get {
                return ResourceManager.GetString("ChildUidNotUnique", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to In WMLS_AddToStore, the objectType being added in WMLtypeIn must be an objectType supported by the server. The server does not support the object type trying to be added..
        /// </summary>
        internal static string DataObjectTypeNotSupported {
            get {
                return ResourceManager.GetString("DataObjectTypeNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to In WMLS_AddToStore, the WMLtypeIn objectType must match the XMLin objectType. Currently, they do not match..
        /// </summary>
        internal static string DataObjectTypesDontMatch {
            get {
                return ResourceManager.GetString("DataObjectTypesDontMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to For WMLS_AddToStore, a data-object with the same type and unique identifier(s) must NOT already exist in the persistent store.
        /// </summary>
        internal static string DataObjectUidAlreadyExists {
            get {
                return ResourceManager.GetString("DataObjectUidAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to For WMLS_GetCap, the OptionsIn keyword ‘dataVersion’ must specify a Data Schema Version that is supported by the server as defined by WMLS_GetVersion..
        /// </summary>
        internal static string DataVersionNotSupported {
            get {
                return ResourceManager.GetString("DataVersionNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to When adding or updating curves, column-identifiers must be unique..
        /// </summary>
        internal static string DuplicateColumnIdentifiers {
            get {
                return ResourceManager.GetString("DuplicateColumnIdentifiers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error adding to data store.
        /// </summary>
        internal static string ErrorAddingToDataStore {
            get {
                return ResourceManager.GetString("ErrorAddingToDataStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error deleting from data store.
        /// </summary>
        internal static string ErrorDeletingFromDataStore {
            get {
                return ResourceManager.GetString("ErrorDeletingFromDataStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error reading from data store.
        /// </summary>
        internal static string ErrorReadingFromDataStore {
            get {
                return ResourceManager.GetString("ErrorReadingFromDataStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error updating in data store.
        /// </summary>
        internal static string ErrorUpdatingInDataStore {
            get {
                return ResourceManager.GetString("ErrorUpdatingInDataStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect case on parent uid..
        /// </summary>
        internal static string IncorrectCaseParentUid {
            get {
                return ResourceManager.GetString("IncorrectCaseParentUid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to When updating data in a systematically growing data-object the indexCurve must be specified in the mnemonicList..
        /// </summary>
        internal static string IndexCurveNotFound {
            get {
                return ResourceManager.GetString("IndexCurveNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to If a column-identifier representing the index column is specified then it must be specified first in the data-column-list..
        /// </summary>
        internal static string IndexNotFirstInDataColumnList {
            get {
                return ResourceManager.GetString("IndexNotFirstInDataColumnList", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The result of an add, update, or delete operation must be compliant with the derived write schema after performing a retrieval of the complete data-object.
        /// </summary>
        internal static string InputDataObjectNotCompliant {
            get {
                return ResourceManager.GetString("InputDataObjectNotCompliant", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The input template must not specify more than one data-object..
        /// </summary>
        internal static string InputTemplateMultipleDataObjects {
            get {
                return ResourceManager.GetString("InputTemplateMultipleDataObjects", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The input template must conform to the appropriate derived schema..
        /// </summary>
        internal static string InputTemplateNonConforming {
            get {
                return ResourceManager.GetString("InputTemplateNonConforming", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to In the value of the capClient schemaVersion, the oldest Data Schema Version must be listed first, followed by the next oldest, etc..
        /// </summary>
        internal static string InvalidClientSchemaVersion {
            get {
                return ResourceManager.GetString("InvalidClientSchemaVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value specified with an OptionsIn keyword must be a recognized value for that keyword..
        /// </summary>
        internal static string InvalidKeywordValue {
            get {
                return ResourceManager.GetString("InvalidKeywordValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of the OptionsIn keyword of ‘maxReturnNodes’ MUST be greater than zero..
        /// </summary>
        internal static string InvalidMaxReturnNodes {
            get {
                return ResourceManager.GetString("InvalidMaxReturnNodes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to If the OptionsIn keyword ‘requestObjectSelectionCapability’ is specified with a value other than ‘none’ then QueryIn must be the Minimum Query Template.
        /// </summary>
        internal static string InvalidMinimumQueryTemplate {
            get {
                return ResourceManager.GetString("InvalidMinimumQueryTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OptionsIn keyword returnsElements=latest-change-only can only be used for a changeLog object..
        /// </summary>
        internal static string InvalidOptionForChangeLogOnly {
            get {
                return ResourceManager.GetString("InvalidOptionForChangeLogOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The OptionsIn keyword ‘returnElements’ must not specify a value of “headeronly” or “data-only” for a non-growing data-object..
        /// </summary>
        internal static string InvalidOptionForGrowingObjectOnly {
            get {
                return ResourceManager.GetString("InvalidOptionForGrowingObjectOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The OptionsIn keyword ‘requestObjectSelectionCapability’ with a value other than ‘none’ must not be specified with any other OptionsIn keyword..
        /// </summary>
        internal static string InvalidOptionsInCombination {
            get {
                return ResourceManager.GetString("InvalidOptionsInCombination", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of the uom attribute is must match an ‘annotation’ attribute from the WITSML Units Dictionary XML file..
        /// </summary>
        internal static string InvalidUnitOfMeasure {
            get {
                return ResourceManager.GetString("InvalidUnitOfMeasure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The OptionsIn value must be a recognized keyword for that function..
        /// </summary>
        internal static string KeywordNotSupportedByFunction {
            get {
                return ResourceManager.GetString("KeywordNotSupportedByFunction", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A client must not specify an OptionsIn keyword that is not supported by the server..
        /// </summary>
        internal static string KeywordNotSupportedByServer {
            get {
                return ResourceManager.GetString("KeywordNotSupportedByServer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The client must not attempt to add or update more data than is allowed by the server’s maxDataNodes and maxDataPoints values..
        /// </summary>
        internal static string MaxDataExceeded {
            get {
                return ResourceManager.GetString("MaxDataExceeded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The client product name and/or product version number are missing in the HTTP user-agent field..
        /// </summary>
        internal static string MissingClientUserAgent {
            get {
                return ResourceManager.GetString("MissingClientUserAgent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A QueryIn template must include a version attribute in the plural data-object that defines the Data Schema Version of the data-object..
        /// </summary>
        internal static string MissingDataSchemaVersion {
            get {
                return ResourceManager.GetString("MissingDataSchemaVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to For WMLS_GetCap, the OptionsIn keyword ‘dataVersion’ must be specified..
        /// </summary>
        internal static string MissingDataVersion {
            get {
                return ResourceManager.GetString("MissingDataVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A template must include a default namespace declaration for the WITSML namespace..
        /// </summary>
        internal static string MissingDefaultWitsmlNamespace {
            get {
                return ResourceManager.GetString("MissingDefaultWitsmlNamespace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A non-empty value must be defined for the input template..
        /// </summary>
        internal static string MissingInputTemplate {
            get {
                return ResourceManager.GetString("MissingInputTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parent does not exist.
        /// </summary>
        internal static string MissingParentDataObject {
            get {
                return ResourceManager.GetString("MissingParentDataObject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to For WMLS_AddToStore, all parentage-pointers and lower level(child) uid values must be defined in the XMLin file..
        /// </summary>
        internal static string MissingParentUid {
            get {
                return ResourceManager.GetString("MissingParentUid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The input template MUST contain a plural root element..
        /// </summary>
        internal static string MissingPluralRootElement {
            get {
                return ResourceManager.GetString("MissingPluralRootElement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A mandatory write schema item is missing..
        /// </summary>
        internal static string MissingRequiredData {
            get {
                return ResourceManager.GetString("MissingRequiredData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to For WMLS_AddToStore and WMLS_UpdateInStore, the client must always specify the unit for all measure data..
        /// </summary>
        internal static string MissingUnitForMeasureData {
            get {
                return ResourceManager.GetString("MissingUnitForMeasureData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A QueryIn template must include a version attribute in the plural data-object that defines the Data Schema Version of the data-object..
        /// </summary>
        internal static string MissingVersionAttribute {
            get {
                return ResourceManager.GetString("MissingVersionAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A non-empty value must be defined for WMLtypeIn..
        /// </summary>
        internal static string MissingWMLtypeIn {
            get {
                return ResourceManager.GetString("MissingWMLtypeIn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to For growing data-objects, a combination of depth and date-time structural-range indices must not be specified..
        /// </summary>
        internal static string MixedStructuralRangeIndices {
            get {
                return ResourceManager.GetString("MixedStructuralRangeIndices", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to For updating systematically growing data, the update data must not contain multiple nodes with the same index..
        /// </summary>
        internal static string NodesWithSameIndex {
            get {
                return ResourceManager.GetString("NodesWithSameIndex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The OptionsIn parameter string must be encoded utilizing a subset (semicolon separators and no
        /// whitespace) of the encoding rules for HTML form content type application/x-www-form-urlencoded..
        /// </summary>
        internal static string ParametersNotEncodedByRules {
            get {
                return ResourceManager.GetString("ParametersNotEncodedByRules", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Partial success: Function completed successfully but some growing data-object data-nodes were not returned..
        /// </summary>
        internal static string ParialSuccess {
            get {
                return ResourceManager.GetString("ParialSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Query not supported..
        /// </summary>
        internal static string QueryNotSupported {
            get {
                return ResourceManager.GetString("QueryNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The query template is does not conform to the data schema for this data-object..
        /// </summary>
        internal static string QueryTemplateNonConforming {
            get {
                return ResourceManager.GetString("QueryTemplateNonConforming", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to When multiple selection criteria is are included in a recurring pattern, an empty value must not be specified..
        /// </summary>
        internal static string RecurringItemsEmptySelection {
            get {
                return ResourceManager.GetString("RecurringItemsEmptySelection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to When multiple selection criteria is are included in a recurring element, the same selection items must exist in each recurring node..
        /// </summary>
        internal static string RecurringItemsInconsistentSelection {
            get {
                return ResourceManager.GetString("RecurringItemsInconsistentSelection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to For the capClient object, the values of schemaVersion must match the version attribute used in the plural data-objects..
        /// </summary>
        internal static string SchemaVersionNotMatch {
            get {
                return ResourceManager.GetString("SchemaVersionNotMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Function completed successfully.
        /// </summary>
        internal static string Success {
            get {
                return ResourceManager.GetString("Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The XMLin document does not comply with the update schema..
        /// </summary>
        internal static string UpdateTemplateNonConforming {
            get {
                return ResourceManager.GetString("UpdateTemplateNonConforming", resourceCulture);
            }
        }
    }
}
