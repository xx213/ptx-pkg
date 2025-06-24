using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
//using PTX.AI;


namespace PTXClassLibrary
{

    /*Create new function named PTXFieldMapping							
This function loop through the Original filenames and maps to matrix of known and similar aliases and when one is found assigns the Original field name to the PTX FieldName.  The PTXFieldname is a system variable used in pension calculations.							
Create a matrix to collate the results with as below, I have put some samples in it.							
OriginalFieldName is from the collResult							
OriginalStringDataTypeName is the corresponding type in FieldTypeList.							
"Search should be done on the  all the known names in ptxFieldDictionaryAndMapMatrix  which  contains (PTXSuggestedCalcName ; PTXDataTypeName =; PensionDataType ; PTXClassName ; Description =; KnownNames ;
KNown names is a KnownNames= new List<String>();, of string that indicate the Original fieldname can be mapped to the PTXSuggestedCalcName."							
This search is not case dependent and spaces and special characters should be ignored							
If a match is not found then perform another search usign fizzy logic, and return then best match.  Add the best match and bestscore to the object above							

        Sample table  :
        OriginalFieldName	OriginalStringDataTypeName	PTXSuggestedCalcName 	PTXSuggestedDataTypeName	UseOriginal or PTX	bestScore	bestFuzzyMatch	Additional Info
Paid Up To date	Date	MemPaidUpToDate	Date	No	20	MemPaidUpToDate	Fuzzy search completed
Current Status	String	MemCurrStat	String	No	25	MemCurrStat	Exact match found 
Current Status Date	Date	MemCurrStatDate	Date	No	25	MemCurrStatDate	Exact match found 
    */


    public class PTXMappingRow
    {
        private string _originalDataTypeName;

        private string _ptxSuggestedDataTypeName;
        private string _userSuggestedDataTypeName;
        private string _calcTypeName;
        private FieldTypesUtility _fieldTypesUtility = new FieldTypesUtility();
        private Boolean bMatchingCompleted;


        /// <summary>
        /// Gets or sets the original field name.
        /// </summary>
        [JsonProperty("OriginalFieldName")]
        [Description("The original field name.")]
        public string OriginalFieldName { get; set; }

        /// <summary>
        /// Gets or sets the original data type name.
        /// </summary>
        [JsonProperty("OriginalStringDataTypeName")]
        [Description("The original data type name.")]
        public string OriginalStringDataTypeName
        {
            get => _originalDataTypeName;
            set
            {
                _originalDataTypeName = value;
                //OriginalDataSystemType = _fieldTypesUtility.GetTypeFromString(value);
                OriginalDataSystemType = FieldTypesUtility.GetTypeFromString(value);
            }
        }

        /// <summary>
        /// Gets or sets the original data type name.
        /// </summary>
        [JsonProperty("OriginalStringDataTypeName")]
        [Description("The original data type name.")]
        public string OriginalDataTypeName
        {
            get => _originalDataTypeName;
            set
            {
                _originalDataTypeName = value;
                //OriginalDataSystemType = _fieldTypesUtility.GetTypeFromString(value);
                OriginalDataSystemType = FieldTypesUtility.GetTypeFromString(value);
            }
        }


        /// <summary>
        /// Gets or sets the OriginalDataSystemType.
        /// </summary>
        [JsonIgnore] // Exclude from JSON serialization
        public Type OriginalDataSystemType { get; private set; }
        public Type OriginalStringDataSystemType { get; private set; }






        //From Dictionary *****************
        /// <summary>
        /// Gets or sets the PTX suggested calculation name.
        /// </summary>
        [JsonProperty("PTXSuggestedCalcName")]
        [Description("The PTX suggested calculation name.")]
        public string PTXSuggestedCalcName { get; set; }

        /// <summary>
        /// Gets or sets the PTX suggested data type name.
        /// </summary>
        [JsonProperty("PTXSuggestedDataTypeName")]
        [Description("The PTX suggested data type name.")]
        public string PTXSuggestedDataTypeName
        {
            get => _ptxSuggestedDataTypeName;
            set
            {
                _ptxSuggestedDataTypeName = value;
                PTXSuggestedDataSystemType = FieldTypesUtility.GetTypeFromString(value);
            }
        }

        /// <summary>
        /// Gets or sets the PTX suggested data system type.
        /// </summary>
        [JsonIgnore] // Exclude from JSON serialization
        public Type PTXSuggestedDataSystemType { get; private set; }

        //Best of matching
        /// <summary>
        /// Gets or sets the best score.
        /// </summary>
        [JsonProperty("BestScore")]
        [Description("The best matching score.")]
        public int BestScore { get; set; }

        //CalcResultsDataS of AI matching
        /// <summary>
        /// Gets or sets the best AI score.
        /// </summary>
        [JsonProperty("AIBestScore")]
        [Description("The best AI matching score.")]
        public int AIBestScore { get; set; }


        //CalcResultsDataS of Fuzzy matching
        /// <summary>
        /// Gets or sets the best Fuzzy score.
        /// </summary>
        [JsonProperty("FuzzyBestScore")]
        [Description("The best Fuzzy matching score.")]
        public int FuzzyBestScore { get; set; }


        //CalcResultsDataS of KnownNames matching
        /// <summary>
        /// Gets or sets the best KnownNames score.
        /// </summary>
        [JsonProperty("KnownNamesBestScore")]
        [Description("The best KnownNames matching score.")]
        public int KnownNamesBestScore { get; set; }


        /// <summary>
        /// Gets or sets the best match Process.
        /// </summary>
        [JsonProperty("BestMatchProcess")]
        [Description("Process that found the best match [KnownName, AI or Fuzzy.")]
        public string BestMatchProcess { get; set; }


        /// <summary>
        /// Information about the source of the Known Source variable
        /// </summary>
        [JsonProperty("BestMatchKnownSource")]
        [Description("If known, source of original fieldname in KnownSources.")]
        public string BestMatchKnownSource { get; set; }



        //User Input *********************
        /// <summary>
        /// Gets or sets whether to use the original or PTX.
        /// </summary>
        [JsonProperty("UseOriginalOrPTX")]
        [Description("Indicates whether to use the original or PTX.")]
        public string UseOriginalOrPTX { get; set; }

        /// <summary>
        /// Gets or sets the user-suggested calculation name.
        /// </summary>
        [JsonProperty("UserSuggestedCalcName")]
        [Description("The user-suggested calculation name.")]
        public string UserSuggestedCalcName { get; set; }

        /// <summary>
        /// Gets or sets the user-suggested data type name.
        /// </summary>
        [JsonProperty("UserSuggestedDataTypeName")]
        [Description("The user-suggested data type name.")]
        public string UserSuggestedDataTypeName
        {
            get => _userSuggestedDataTypeName;
            set
            {
                _userSuggestedDataTypeName = value;
                UserSuggestedSystemType = FieldTypesUtility.GetTypeFromString(value);
            }
        }

        /// <summary>
        /// Gets or sets the user-suggested system type.
        /// </summary>
        [JsonIgnore] // Exclude from JSON serialization
        public Type UserSuggestedSystemType { get; private set; }

        /// <summary>
        /// Gets or sets the user-suggested description.
        /// </summary>
        [JsonProperty("UserSuggestedDescription")]
        [Description("The user-suggested description.")]
        public string UserSuggestedDescription { get; set; }

        //Used in calculations going forward *********************
        /// <summary>
        /// Gets or sets the calculation name.
        /// </summary>
        [JsonProperty("CalcName")]
        [Description("The calculation name.")]
        public string CalcName { get; set; }

        /// <summary>
        /// Gets or sets the calculation type.
        /// </summary>
        [JsonProperty("CalcType")]
        [Description("The calculation type.")]
        public string CalcTypeName
        {
            get => _calcTypeName;
            set
            {
                _calcTypeName = value;
                CalcSystemType = FieldTypesUtility.GetTypeFromString(value);
            }
        }


        /// <summary>
        /// Gets or sets the calculation data system type.
        /// </summary>
        [JsonIgnore] // Exclude from JSON serialization
        public Type CalcSystemType { get; private set; }

        /// <summary>
        /// Gets or sets additional information.
        /// </summary>
        [JsonProperty("AdditionalInfo")]
        [Description("Additional information about the matching.")]
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Default constructor for PTXMappingRow.
        /// </summary>

        public PTXMappingRow()
        {
            //Apply defaults
            OriginalFieldName = "OR.originalFieldName";
            OriginalDataTypeName = "string";

            //After Matching
            PTXSuggestedCalcName = "PTXSuggestedCalcName";
            PTXSuggestedDataTypeName = "string";
            BestScore = 0;
            BestMatchProcess = "MatchingNotStarted";
            BestMatchKnownSource = "";

            //User
            UseOriginalOrPTX = "Original";
            UserSuggestedCalcName = OriginalFieldName;
            UserSuggestedDataTypeName = OriginalDataTypeName;
            UserSuggestedDescription = "Defaults";

            //Final Decision Defaults
            CalcName = OriginalFieldName;
            CalcTypeName = OriginalDataTypeName;

            //Notes
            AdditionalInfo = "MatchingNotStarted";
            bMatchingCompleted = false;
        }
    }


    public class PTXFieldMappingUtility : FieldTypesUtility
    {
        public PTXFieldDictionaryAndMap ptxFieldDictionaryAndMapMatrix { get; set; }
        public List<PTXMappingRow> ptxFieldMappingResults { get; set; }

        private string globalErrorMessage = "";


        //private DataStreamManager dataStreamManager;

        // Default Constructor
        public PTXFieldMappingUtility()
        {
            //Get Field and Mapping Data
            ptxFieldDictionaryAndMapMatrix = new PTXFieldDictionaryAndMap();

            //Set Up Mapping results, used to map from original fieldnames to PTXDictionary
            ptxFieldMappingResults = new List<PTXMappingRow>();

            //  dataStreamManager = new DataStreamManager();
        }

        //For info:
        //List<string> originalFieldNames, ptxFieldDictionaryAndMapMatrix ptxFieldDictionaryAndMapMatrix, List<Dictionary<string, string>> FieldTypeList
        //public void MapFieldNames(string dataStream)  << If using a csv then apply the CSV bits below, but it is cleaner to is the list

        public void MapFieldNames(List<string[]> listOrigCleanedData)
        {
            // USE IF CSV INPUT   string[] OriginalFieldNames;
            //USE IF CSV INPUT IEnumerable<string[]> dataRows;

            //Use if Liststring<> input
            string[] OriginalFieldNames = null;
            IEnumerable<string[]> dataRows = listOrigCleanedData.Skip(1); // Skip the header row

            if (listOrigCleanedData.Count > 0)
            {
                OriginalFieldNames = listOrigCleanedData[0];
            }

            SetupOriginalFieldNamesAndTypes(OriginalFieldNames, dataRows);

            //Get First row for source analysis
            var ptxFieldDictionaryAndMapMatrixFirstRow = ptxFieldDictionaryAndMapMatrix.FieldData.FirstOrDefault();

            //dataStreamManager.ParseDataStream(dataStream, out OriginalFieldNames, out dataRows);

            //File format
            //ptxFieldMappingResults.LIST().PTXMappingRow(..,..,..,..,..)
            //Create a full matrix based on OriginalFieldName

            //DataTable Format
            //ptxFieldMappingResults[0] : |OriginalFieldName  | OriginalStringDataTypeName | PTXSuggestedCalcName    | PTXSuggestedDataTypeName | UseOriginal | bestScore | bestFuzzyMatch       | Additional Info           | 
            //ptxFieldMappingResults[1] : |Paid Up To date    | Date             | MemPaidUpToDate | Date         | No          | 20        | MemPaidUpToDate |  Fuzzy search completed
            //ptxFieldMappingResults[2] : |etc


            //Setup Mapping results
            //            SetupOriginalFieldNamesAndTypes(OriginalFieldNames, dataRows);
            //PTXMappingRow myAdPTXFieldMappingRow = new PTXMappingRow();       //ErrMessage of Row
            //List<PTXMappingRow> myPtxFieldMappingResults = new List<PTXMappingRow>();     //Main List To Return
            //SetupOriginalFieldNamesAndTypes(myPtxFieldMappingResults, OriginalFieldNames, dataRows, myAdPTXFieldMappingRow);

            //listOrigCleanedData.

            try
            {
                //Loop over each OriginalName and check against each PTXName
                for (int i = 0; i < ptxFieldMappingResults.Count; i++)
                {
                    // for (int iPTXFieldName = 0; iPTXFieldName < ptxFieldDictionaryAndMapMatrix.TypeData.Count; i++)
                    //{
                    //Define Search Term
                    string originalFieldNameToFindPreNormalisation = ptxFieldMappingResults[i].OriginalFieldName;
                    string originalFieldNameToFind = NormalizeSearchTerm(originalFieldNameToFindPreNormalisation);


                    //Matched row, if this is populated a match is found
                    var matchingDataRow = new PTXFieldMappingDataRow();
                    int myBestScore = 0;
                    int myAIBestScore = 0;
                    int myFuzzyFinalBestScore = 0;
                    int myKnownNamesBestScore = 0;
                    string myKnownNamesBestMatchProcess = ErrorMessages.ewmNotFound;
                    string myAIBestMatchProcess = ErrorMessages.ewmNotFound;
                    string myFuzzyBestMatchProcess = ErrorMessages.ewmNotFound;
                    string myKnownNamesBestMatchSource = "";
                    string myAIBestMatchSource = "";
                    string myKnownNamesFuzzyBestMatchSource = "";
                    int myKnownNameIndex = 0;
                    int myKnownNameFuzzyIndex = 0;
                    string myKnownNamesAdditionalInfo = "";
                    string myAIAdditionalInfo = "";
                    string myFuzzyAdditionalInfo = "";
                    bool matchFound = false;

                    //PTXSuggestedCalcName | PTXSuggestedDataTypeName | UseOriginal | bestScore | bestFuzzyMatch | Additional Info |
                    // Search known names , all same case and no spaces
                    //Returns the first one it find
                    //Could be refined

                    #region Search 1 - Match on known names and Normalise search on known names
                    //First test exact match
                    if (matchFound == false)
                    {
                        //matchingDataRow = ptxFieldDictionaryAndMapMatrix.FieldData.FirstOrDefault(dataRow => dataRow.KnownNames.Any(knownName =>
                        //     (knownName) == originalFieldNameToFindPreNormalisation));

                        matchingDataRow = ptxFieldDictionaryAndMapMatrix.FieldData.FirstOrDefault(dataRow =>
         dataRow.KnownNames
             .Select((knownName, index) => new { KnownName = knownName, myKnownNameIndex = index })
             .Any(item => item.KnownName == originalFieldNameToFindPreNormalisation));


                        if (matchingDataRow != null)
                        {
                            myKnownNamesBestMatchProcess = "ExactKnownNames"; //Add in Source type from row 1?
                            myKnownNamesBestScore = 100;
                            myKnownNamesAdditionalInfo = $"Found as exact match Known Names. {matchingDataRow.PensionDataType}. {matchingDataRow.PTXClassName}" + globalErrorMessage;
                            myKnownNamesBestMatchSource = ptxFieldDictionaryAndMapMatrixFirstRow.KnownNames[myKnownNameIndex];
                            matchFound = true;
                        }
                    }

                    //Second test Normalized Match
                    if (matchFound == false)
                    {
                        matchingDataRow = ptxFieldDictionaryAndMapMatrix.FieldData.FirstOrDefault(dataRow => dataRow.KnownNames.Any(knownName =>
                                NormalizeSearchTerm(knownName) == originalFieldNameToFind));
                        if (matchingDataRow != null)
                        {
                            myKnownNamesBestMatchProcess = "NormalisedKnownNames";
                            myKnownNamesBestScore = 90;
                            myKnownNamesAdditionalInfo = $"Found in Normalised Known Names. {matchingDataRow.PensionDataType}. {matchingDataRow.PTXClassName}" + globalErrorMessage;
                            //myBestMatchSource = ptxFieldDictionaryAndMapMatrixFirstRow.KnownNames[myKnownNameIndex];
                            matchFound = true;
                        }
                    }
                    #endregion //Search 1 - Match on known names

                    #region Search 2 - Fuzzy Logic
                    // If no exact match is found, perform fuzzy search
                    if (matchFound == false || matchFound == true)
                    {
                        var bestFuzzyMatch = FuzzySearch(originalFieldNameToFind);
                        var bestFuzzyScore = 00;
                        myFuzzyFinalBestScore = 00;

                        if (bestFuzzyMatch != null)
                        {
                            // Add the best match and best score to the object above
                            // (you need to define where to store this information in your data structure)
                            // Fuzzy logic search
                            /* var fuzzyMatch = FindBestFuzzyMatch(originalFieldName, ptxFieldDictionaryAndMapMatrix.TypeData);

                             if (fuzzyMatch != null)
                             {
                                 result.PTXSuggestedCalcName = fuzzyMatch.PTXSuggestedCalcName;
                                 result.PTXSuggestedDataTypeName = fuzzyMatch.PTXDataTypeName;
                                 result.BestScore = fuzzyMatch.Score;
                                 result.BestMatchProcess = "Fuzzy search completed";
                             }
                            */

                            myFuzzyBestMatchProcess = "Fuzzy";
                            myFuzzyFinalBestScore = bestFuzzyScore;
                            myFuzzyAdditionalInfo = $"Found in Fuzzy Match Known Names. {matchingDataRow.PensionDataType}. {matchingDataRow.PTXClassName}" + globalErrorMessage;
                            myFuzzyAdditionalInfo = $"Found in Fuzzy Match Known Names. {matchingDataRow.PensionDataType}. {matchingDataRow.PTXClassName}" + globalErrorMessage;
                            matchFound = false;
                        }
                    }
                    #endregion //Search 2 - Fuzzy Logic


                    #region Search 3 AI 
                    //Search and match on Components eg GMRP, Pre88, 78to90 etc
                    if (matchFound == false || matchFound == true)
                    {
                        //DO Search 3
                        //TBD   AIFieldMapAnalysis(originalFieldNameToFind, )

                        var mybestAIScore = 0;

                        myAIBestMatchProcess = "AI";
                        myAIBestScore = mybestAIScore;
                        //myAIAdditionalInfo = $"Found in AI Match. {matchingDataRow.PensionDataType}. {matchingDataRow.PTXClassName}" + globalErrorMessage;
                        myAIAdditionalInfo = $"AI Match Not Done. ";
                        
                        //matchFound = false;
                    }
                    #endregion Search 3 AI and Intelligent 



                    //CalcResultsDataS

                    //Calculate Best Score and where it was from
                    if ((myAIBestScore + myFuzzyFinalBestScore + myKnownNamesBestScore) > 0)
                    {
                        if (myKnownNamesBestScore > Math.Max(myFuzzyFinalBestScore, myAIBestScore))
                        {
                            ptxFieldMappingResults[i].BestScore = myKnownNamesBestScore;
                            ptxFieldMappingResults[i].BestMatchProcess = myKnownNamesBestMatchProcess;
                            ptxFieldMappingResults[i].AdditionalInfo = myKnownNamesAdditionalInfo;
                            ptxFieldMappingResults[i].BestMatchKnownSource = myKnownNamesBestMatchSource;
                            ptxFieldMappingResults[i].PTXSuggestedCalcName = matchingDataRow.PTXCalcName;
                            ptxFieldMappingResults[i].PTXSuggestedDataTypeName = matchingDataRow.PTXDataTypeName;
                            ptxFieldMappingResults[i].UseOriginalOrPTX = "PTX";
                            //Set to CalcName and CalcTypeName
                            ptxFieldMappingResults[i].CalcName = ptxFieldMappingResults[i].PTXSuggestedCalcName;
                            ptxFieldMappingResults[i].CalcTypeName = ptxFieldMappingResults[i].CalcName;


                        }
                        else if (myFuzzyFinalBestScore > myAIBestScore)
                        {
                            ptxFieldMappingResults[i].BestScore = myFuzzyFinalBestScore;
                            ptxFieldMappingResults[i].BestMatchProcess = myFuzzyBestMatchProcess;
                            ptxFieldMappingResults[i].AdditionalInfo = myFuzzyAdditionalInfo;
                            ptxFieldMappingResults[i].BestMatchKnownSource = myKnownNamesFuzzyBestMatchSource;
                            ptxFieldMappingResults[i].PTXSuggestedCalcName = matchingDataRow.PTXCalcName;
                            ptxFieldMappingResults[i].PTXSuggestedDataTypeName = matchingDataRow.PTXDataTypeName;

                            ptxFieldMappingResults[i].UseOriginalOrPTX = "PTX";
                            //Set to CalcName and CalcTypeName
                            ptxFieldMappingResults[i].CalcName = ptxFieldMappingResults[i].PTXSuggestedCalcName;
                            ptxFieldMappingResults[i].CalcTypeName = ptxFieldMappingResults[i].CalcName;


                        }
                        else
                        {
                            ptxFieldMappingResults[i].BestScore = myFuzzyFinalBestScore;
                            ptxFieldMappingResults[i].BestMatchProcess = myFuzzyBestMatchProcess;
                            ptxFieldMappingResults[i].AdditionalInfo = myAIAdditionalInfo;
                            ptxFieldMappingResults[i].BestMatchKnownSource = ErrorMessages.ewmNA;
                            ptxFieldMappingResults[i].PTXSuggestedCalcName = matchingDataRow.PTXCalcName;
                            ptxFieldMappingResults[i].PTXSuggestedDataTypeName = matchingDataRow.PTXDataTypeName;
                            ptxFieldMappingResults[i].CalcName = ptxFieldMappingResults[i].PTXSuggestedCalcName;

                            ptxFieldMappingResults[i].UseOriginalOrPTX = "PTX";
                            //Set to CalcName and CalcTypeName
                            ptxFieldMappingResults[i].CalcName = ptxFieldMappingResults[i].PTXSuggestedCalcName;
                            ptxFieldMappingResults[i].CalcTypeName = ptxFieldMappingResults[i].CalcName;

                        }

                    }
                    #region 4 Admit Defeat
                    //AllMatches Fail
                    else //ptxFieldMappingResults[i].BestScore == 0
                    {
                        var OrigRow = ptxFieldMappingResults.Skip(0).FirstOrDefault(row => row.OriginalFieldName.Equals(originalFieldNameToFindPreNormalisation, StringComparison.OrdinalIgnoreCase));

                        ptxFieldMappingResults[i].BestScore = 0; 
                        ptxFieldMappingResults[i].AdditionalInfo = $"{ErrorMessages.ewmNotMatched}, use PTX adjusted CalcName and OrigDataType. {globalErrorMessage}"; 
                        ptxFieldMappingResults[i].PTXSuggestedCalcName = PTXCalcFieldReady(OrigRow.OriginalFieldName, ErrorMessages.dataSrc);
                        ptxFieldMappingResults[i].PTXSuggestedDataTypeName = OrigRow.OriginalDataTypeName;
                        ptxFieldMappingResults[i].BestMatchProcess = ErrorMessages.ewmNotMatched;
                        ptxFieldMappingResults[i].UseOriginalOrPTX = "Original";
                        ptxFieldMappingResults[i].CalcName = ptxFieldMappingResults[i].PTXSuggestedCalcName;
                        
                        //Set to CalcName and CalcTypeName
                        ptxFieldMappingResults[i].CalcName = ptxFieldMappingResults[i].PTXSuggestedCalcName;
                        ptxFieldMappingResults[i].CalcTypeName= OrigRow.OriginalDataTypeName;
                    }
                    #endregion // 4 Admit Defeat

                }  //End loop
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"An error occurred: {ex.Message}");
                // You can log the exception or perform other error handling actions as needed
            }

        }//End MapFieldNames

        /// <summary>
        /// Sets up PTX field mappings based on original field names and associated data rows.
        /// </summary>
        /// <param name="OriginalFieldNames">Array of original field names.</param>
        /// <param name="dataRows">Collection of data rows for each field.</param>
        private void SetupOriginalFieldNamesAndTypes(string[] OriginalFieldNames, IEnumerable<string[]> dataRows)
        {
            // Loop through each original field name, creating corresponding PTXMappingRows
            for (int i = 0; i < OriginalFieldNames.Length; i++)
            {
                // Reset the globalErrorMessage for each iteration
                globalErrorMessage = "";

                // Create a new PTXMappingRow and add it to the ptxFieldMappingResults list
                var adPTXFieldMappingRow = new PTXMappingRow();
                ptxFieldMappingResults.Add(adPTXFieldMappingRow);

                // If OriginalFieldName is missing or empty, use a default name and update globalErrorMessage
                if (string.IsNullOrWhiteSpace(OriginalFieldNames[i]))
                {
                    OriginalFieldNames[i] = "OriginalFieldNameMissing";
                    globalErrorMessage = "OriginalFieldNameMissing";
                }

                // Set OriginalFieldName for the PTXMappingRow
                ptxFieldMappingResults[i].OriginalFieldName = OriginalFieldNames[i];

                // Flags to track whether a non-null, non-blank value is found for the current column
                var foundValue = false;

                // Placeholder for the found data value
                var testDataValue = string.Empty;

                // Loop over each data row to find the first non-null, non-blank value for the current column
                foreach (var dataRow in dataRows)
                {
                    // Check if the current row has enough elements and the element at the current column is not null or blank
                    if (dataRow.Length > i && !string.IsNullOrWhiteSpace(dataRow[i]))
                    {
                        // Set testDataValue to the found value
                        testDataValue = dataRow[i];
                        foundValue = true;

                        // Break out of the loop once a non-null, non-blank value is found
                        break;
                    }
                }

                // If a non-null, non-blank value is found, populate OriginalStringDataTypeName
                if (foundValue)
                {
                    // Use foreach dataRow as the original value (placeholder logic, replace as needed)
                    foreach (var originalDataRow in dataRows)
                    {
                        // Additional logic using originalDataRow if needed...

                        // For now, just a placeholder action
                        Console.WriteLine(originalDataRow);
                    }

                    // Set OriginalStringDataTypeName based on the determined field type
                    ptxFieldMappingResults[i].OriginalDataTypeName = DetermineFieldTypeFromValue(testDataValue).typeName;
                    // Additional logic if needed...
                }
                else
                {
                    // If no non-null, non-blank value is found, handle accordingly (set a default value or perform additional logic)
                    ptxFieldMappingResults[i].OriginalDataTypeName = "DefaultValue"; // Replace with your default value or logic
                }
            }
        }

        private PTXFieldMappingDataRow FuzzySearch(string searchTerm)
        {
            // Implement your fuzzy search logic here
            // ...

            // For now, return null as a placeholder
            return null;
        }

        #region helper functions

        //Assume first row is header or fieldnames
        //Assume first column is dataUID
        //This function is intended to be used in the WebPage
        public async Task<List<string[]>> RemapDataFromOrigFieldNameToPTXCalcNameAsync(
            List<string[]> origDataListStringArr,
            List<PTXMappingRow> dataPTXFieldMappings)
        {
            return await Task.Run(() =>
            {
                List<string[]> remappedDataListStringArr = new List<string[]>();
                RemapDataFromOrigFieldNameToPTXCalcName(origDataListStringArr, ref remappedDataListStringArr, dataPTXFieldMappings);
                return remappedDataListStringArr;
            });
        }

        public void RemapDataFromOrigFieldNameToPTXCalcName(
        in List<string[]> origDataListStringArr,
        ref List<string[]> remappedDataListStringArr,
        in List<PTXMappingRow> dataPTXFieldMappings)
        {
            // Make a copy of origDataListStringArr to remappedDataListStringArr
            remappedDataListStringArr = origDataListStringArr.ToList();

            if (origDataListStringArr != null && origDataListStringArr.Any() && dataPTXFieldMappings != null && dataPTXFieldMappings.Any())
            {
                // Copy the original header to the remapped list
                var workRemappedFieldNames = new List<string[]> { origDataListStringArr.First().ToArray() };

                // Iterate over the header columns and update with PTXSuggestedCalcName
                for (int i = 0; i < workRemappedFieldNames[0].Length; i++)
                {
                    // Find the corresponding PTXMappingRow
                    var mappingRow = dataPTXFieldMappings.FirstOrDefault(row => row.OriginalFieldName == workRemappedFieldNames[0][i]);

                    // If found, update the header with PTXSuggestedCalcName
                    if (mappingRow != null)
                    {
                        workRemappedFieldNames[0][i] = mappingRow.PTXSuggestedCalcName;
                        remappedDataListStringArr[0][i] = workRemappedFieldNames[0][i];
                    }
                }
            }
        }



        [Description("Normalizes the search term by converting to lowercase, removing spaces, double quotes, and periods, and keeping only letters and digits.")]
        public string NormalizeSearchTerm(string term)
        {
            // Step 1: Convert to lowercase
            string lowercaseTerm = term.ToLower();

            // Step 2: Remove spaces, double quotes, and periods
            string noSpacesTerm = lowercaseTerm.Replace(" ", "").Replace("\"", "").Replace(".", "");

            // Step 3: Keep only letters and digits
            string validCharsTerm = new string(noSpacesTerm.Where(char.IsLetterOrDigit).ToArray());

            // Return the final result
            return validCharsTerm;
        }

        public string PTXCalcFieldReady(string term, string prefix)
        {
            // Step 1: Convert to lowercase
            //string lowercaseTerm = term.ToLower();

            // Step 2: Remove spaces
            string noSpacesTerm = term.Replace(" ", "");

            // Step 3: Keep only letters and digits
            string validCharsTerm = new string(noSpacesTerm.Where(char.IsLetterOrDigit).ToArray());

            // Return the final result
            return prefix + "." + validCharsTerm;
        }

        private async Task<string> AIFieldMapAnalysis(string fieldName, string inputData)
        {
            string initialAINotes = "AI Assistant is not available at this time.";

            try
            {

                string myAIQuery = $"Given the fieldName {fieldName}, and the data below"; // First command
                myAIQuery += "Determine the data type from the string list [string, double, date, datetime, integer]. "; // Second command
                myAIQuery += "ONLY return a fixed format response consisting of two strings in [DataType, pcCertainty]."; // Third command
                myAIQuery += "[DataType] is type you have determined.[pcCertainty] is an integer value between 0 and 100 on certainy that teh DataTypis correct. "; // Fourth command
                myAIQuery += inputData;

                //var aiConnect = new AIConnect();
                //await aiConnect.GenerateResponse(myAIQuery); // Await here
                //initialAINotes = aiConnect.msgReturn;


                return initialAINotes;
            }
            catch
            {
                return initialAINotes;
            }


            //return await PTXHelperFunctions.FormatDataAsync(initialAINotes);
            
        }


        /// <summary>
        /// Gets the field names from the specified object.
        /// </summary>
        /// <param name="objectToGetFieldNamesFrom">The object from which to extract field names.</param>
        /// <returns>A list of field names.</returns>
        public static List<string> GenerateFieldnames(dynamic objectToGetFieldNamesFrom)
        {
            if (objectToGetFieldNamesFrom == null)
            {
                throw new ArgumentNullException(nameof(objectToGetFieldNamesFrom), "Input object cannot be null.");
            }

            var fieldNames = new List<string>();

            if (objectToGetFieldNamesFrom is List<dynamic[]> dataListDynArr && dataListDynArr.Any())
            {
                // Extract field names from the first row (assuming it contains field names)
                foreach (var fieldName in dataListDynArr.First())
                {
                    if (fieldName is KeyValuePair<string, dynamic> kvp)
                    {
                        fieldNames.Add(kvp.Key);
                    }
                }
            }
            else if (objectToGetFieldNamesFrom is List<Dictionary<string, dynamic>> dictionaryList && dictionaryList.Any())
            {
                fieldNames = dictionaryList.First().Keys.ToList();
            }
            else if (objectToGetFieldNamesFrom is List<string[]> stringArrayList && stringArrayList.Any())
            {
                fieldNames = stringArrayList.First().ToList();
            }
            else if (objectToGetFieldNamesFrom is List<string> stringList && stringList.Any())
            {
                // If it's a list of strings, assume each string represents a field name
                fieldNames = stringList;
            }
            else
            {
                throw new ArgumentException("Unsupported format for extracting field names.", nameof(objectToGetFieldNamesFrom));
            }

            return fieldNames;
        }



        #endregion //helper functions
    }
}
