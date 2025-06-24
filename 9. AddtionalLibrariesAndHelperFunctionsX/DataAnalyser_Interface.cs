using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PTXClassLibrary
{
    public static class DataAnalyser_Interface

    {
        //BUG : If a \n is between delims and not a string eg 0.00\n23 then code splits as if end of row.


        //(initialAnalysisData,initialAnalysisNotes, cleanedDataForProcessing, cleanedAnalysis, cleanedNotes) = DataAnalyser_Interface.ProcessTextAndAnalyzeAndClean(OriginalData);
        //Al in one function to analysis data
        public static async Task<(string inputDataMarkedUp, string inputDataAnalysisNotes,
                             string cleanedData, string cleanedDataMarkedUp, string cleanedDataAnalysisNotes,
                             string origDataSetType)> ProcessTextAndAnalyzeAndCleanAsync(string originalInputData)
        {
            return await Task.Run(() => ProcessTextAndAnalyzeAndClean(originalInputData));
        }

        public static (string inputDataMarkedUp, string inputDataAnalysisNotes,
                        string cleanedData, string cleanedDataMarkedUp, string cleanedDataAnalysisNotes,
                        string origDataSetType)
            ProcessTextAndAnalyzeAndClean(string originalInputData)
        {
            //Set up returns
            //New string with OrigMarkUp aspects.
            StringBuilder originalInputDataMarkedUp = new StringBuilder(); originalInputDataMarkedUp.Append("No Data.  ");
            StringBuilder originalInputDataAnalysisNotes = new StringBuilder(); originalInputDataAnalysisNotes.Append("No Data.  ");

            //Clean as you go
            StringBuilder originalCleanedDataMarkedUp = new StringBuilder(); originalCleanedDataMarkedUp.Append("Cleaning not done.  ");
            StringBuilder originalCleanedDataAnalysisNotes = new StringBuilder(); originalCleanedDataAnalysisNotes.Append("Cleaning not done.  ");
            StringBuilder originalCleanedDataForProcessing = new StringBuilder(); originalCleanedDataForProcessing.Append("Cleaning not done.  ");
            String originalDataSetType = "Scheme Or Member";
            List<String> CleaningJobs = new List<String>();

            //Check exists
            if (originalInputData == null)
            {
                return (originalInputDataMarkedUp.ToString(), originalInputDataAnalysisNotes.ToString(),
                    originalCleanedDataForProcessing.ToString(), originalCleanedDataMarkedUp.ToString(), originalCleanedDataAnalysisNotes.ToString(),
                    originalDataSetType.ToString());
            }

            originalInputDataAnalysisNotes.AppendLine($"Start Initial Data Check : ");


            //Clean up 
            originalCleanedDataMarkedUp.Clear();
            originalCleanedDataAnalysisNotes.Clear();
            originalInputDataMarkedUp.Clear();
            originalInputDataAnalysisNotes.Clear();
            originalCleanedDataForProcessing.Clear();
            originalDataSetType = "";


            //Determine the ErrMessage of data being provided
            string inputDataFormat = GetInputDataFormat(originalInputData);
            originalInputDataAnalysisNotes.Append($"<div style='background-color: {ErrorMessages.GetBackgroundColourEWMCode("#Info")};'> Data Format : We have assumed the format of the data is {inputDataFormat} + .");


            //Carry out origCharacter by origCharacter search, add notes, correct and clean.
            DataAnalysisCleanAndMarkUp(originalInputData, inputDataFormat,
                originalInputDataMarkedUp, originalInputDataAnalysisNotes,
                originalCleanedDataForProcessing, originalCleanedDataMarkedUp, originalCleanedDataAnalysisNotes,
                originalDataSetType);

            //TO DO 
            //Clean Header Row if empty or has spaces - add check to analysis and clean
            //



            //Finally HighIghlight analysis data after clean (Second Check)
            StringBuilder cleanedData2 = new StringBuilder(); cleanedData2.Clear();
            StringBuilder cleanedDataNotes2 = new StringBuilder(); cleanedDataNotes2.Clear();  //Not Used in outputs
            StringBuilder cleanedDataNotes3 = new StringBuilder(); cleanedDataNotes3.Clear();  //Not Used in outputs
            StringBuilder cleanedAnalysis2 = new StringBuilder(); cleanedAnalysis2.Clear();

            //            DataAnalysisCleanAndMarkUp(originalCleanedDataMarkedUp.ToString(),inputDataFormat,

            //                        cleanedAnalysis2, cleanedDataNotes2, 
            //                              cleanedData2 , cleanedDataNotes3);

            //After this it should be ready to be tabulated.

            //(string originalInputDataMarkedUp, string originalInputDataAnalysisNotes, string CleanedData, string cleanedAnalysis, string CleanedDataNotes)
            return (originalInputDataMarkedUp.ToString(), originalInputDataAnalysisNotes.ToString(),
                                                    originalCleanedDataForProcessing.ToString(), originalCleanedDataMarkedUp.ToString(), originalCleanedDataAnalysisNotes.ToString(),
                                                    inputDataFormat);
            //(origDataMarkedUp, origDataAnalysisNotes, origCleanedData, origCleanedDataAnalysisNotes, origCleanedDataAnalysisNotes) 
            //(string inputDataMarkedUp, string inputDataAnalysisNotes, string cleanedDataForProcessing, string cleanedDataMarkedUp, string cleanedDataAnalysisNotes)

        }  //


        private static void DataAnalysisCleanAndMarkUp(string inputData, string inputDataFormat,
                                                    StringBuilder inputDataMarkedUp, StringBuilder inputDataAnalysisNotes,
                                                    StringBuilder cleanedDataForProcessing, StringBuilder cleanedDataMarkedUp, StringBuilder cleanedDataNotes,
                                                    string DataSetType)
        {
            //Setup
            bool quoteOpen = false;
            bool delimOpen = false;


            bool isCSV = inputDataFormat == "TSV" || inputDataFormat == "Tab-Separated" ? false : true;
            char delimChar = inputDataFormat == "TSV" || inputDataFormat == "Tab-Separated" ? '\t' : ',';
            string prevOrigMarkUp = string.Empty;

            //loop over every origCharacter and identify how it is used and errors
            for (Int32 i = 0; i < inputData.Length; i++)
            {
                //Add check for int length
                Int32 iOrig = i;

                string encodedCharacter = string.Empty;
                string encodedPrevCharacter = string.Empty;
                string encodedNextCharacter = string.Empty;

                string OrigMarkUpSpan = string.Empty;
                string CleanMarkUpSpan = string.Empty;
                string OrigMarkUp = string.Empty;

                string CleanMarkUp = string.Empty;

                string OrigCheckEWM = string.Empty;
                string OrigCheckNotes = string.Empty;
                ulong checkPos = 0;
                string CleanEWM = string.Empty;
                string cleanNotes = string.Empty;


                char origCharacter = inputData[i];
                char prevCharacter = (i > 0) ? prevCharacter = inputData[i - 1] : inputData[i];
                char nextCharacter = (i + 1 < inputData.Length) ? inputData[i + 1] : inputData[i];
                char cleanCharacter = origCharacter;


                //Setup
                encodedCharacter = WebUtility.HtmlEncode(origCharacter.ToString());
                encodedPrevCharacter = WebUtility.HtmlEncode(prevCharacter.ToString());
                encodedNextCharacter = WebUtility.HtmlEncode(nextCharacter.ToString());

                //Not used, don't need these.
                if (char.IsWhiteSpace(origCharacter))
                {
                    // Highlight space characters in yellow
                    //string encodedCharacter = WebUtility.HtmlEncode(origCharacter.ToString());
                    //string OrigMarkUpSpan = $"<span style='background-color: yellow;'>{encodedCharacter}</span>";
                    //originalInputDataMarkedUp.Append(OrigMarkUpSpan);
                }


                if (char.IsControl(origCharacter) && !char.IsWhiteSpace(origCharacter))  // Check for control characters and not whitespace
                {
                    // Highlight control characters in blue
                    OrigMarkUp = "Control";
                    CleanMarkUp = OrigMarkUp;
                    //OrigMarkUpSpan = $"<span style='background-color: red; color: white;'>[{OrigMarkUp}]{""}</span>";
                    OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                    CleanMarkUpSpan = OrigMarkUpSpan;
                    //Updates for UI 
                    OrigCheckEWM = ErrorMessages.ewmError; OrigCheckNotes = "Control origCharacter must be removed. ";
                    CleanEWM = ErrorMessages.ewmUpdate; cleanNotes = "Control origCharacter removed. ";
                    cleanCharacter = '\0';  //Empty
                }

                //If Pasted from excel \r\n is the new line split TBD
                //CR=\r, LF = \n
                //IsExcelFormat is CRLF == CRNL
                if (origCharacter == '\r' && nextCharacter == '\n')
                {
                    if (quoteOpen) //if NL is in open quotes then assumes its text
                    {
                        OrigMarkUp = "CRNL";
                        //OrigMarkUpSpan = $"<span style='background-color:orange;'>[{OrigMarkUp}]{""}</span>";
                        OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                        OrigCheckEWM = ErrorMessages.ewmWarning; OrigCheckNotes = "Excel Eol in quotations.  ";

                    }
                    else //Actual Eol Excel
                    {
                        OrigMarkUp = "Eol";
                        delimOpen = false;
                        //OrigMarkUpSpan = $"<span style='background-color: DarkOliveGreen;'>[{OrigMarkUp}]</span>";
                        OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                        //OrigCheckEWM = "#Info"; OrigCheckNotes = "Looks like this is from Excel.  ";

                    }

                    // Highlight the '\r\n' sequence
                    CleanMarkUp = OrigMarkUp;
                    CleanMarkUpSpan = OrigMarkUpSpan;

                    //originalInputDataMarkedUp.Append(OrigMarkUpSpan);
                    i += 2;  // Skip the next origCharacter
                }



                if (origCharacter == '\n' && nextCharacter != '\r')  // Check for newline or carriage return characters
                {
                    if (quoteOpen) //if NL is in open quotes then assumes its text
                    {
                        OrigMarkUp = "NL";
                        //OrigMarkUpSpan = $"<span style='background-color:orange;'>[{OrigMarkUp}]{""}</span>";
                        OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                        OrigCheckEWM = ErrorMessages.ewmError; OrigCheckNotes = "NewLine in quotations, this will be removed.  ";

                        //Clean up,remove NL
                        CleanMarkUp = "";
                        CleanMarkUpSpan = "";
                        cleanCharacter = ' ';
                        CleanEWM = ErrorMessages.ewmUpdate; cleanNotes = "NewLine in quotations removed.  ";
                    }
                    else //quoteCLOSED  , Actual [Eol NL]
                    {
                        OrigMarkUp = "Eol";
                        delimOpen = false;
                        //OrigMarkUpSpan = $"<span style='background-color:lightslategrey;'>[{OrigMarkUp}]{""}</span>";
                        OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                        CleanMarkUp = OrigMarkUp;
                        CleanMarkUpSpan = OrigMarkUpSpan;
                    }


                }


                if (origCharacter == '\r' && nextCharacter != '\n')  // Check for newline or carriage return characters
                {
                    // Highlight newline or carriage return characters in green
                    // Highlight newline or carriage return characters in green\r
                    if (quoteOpen || delimOpen) //if NL is in open quotes then assumes its text
                    {
                        OrigMarkUp = "CR";
                        //OrigMarkUpSpan = $"<span style='background-color:orange;'>[{OrigMarkUp}]{""}</span>";
                        OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                        OrigCheckEWM = ErrorMessages.ewmError; OrigCheckNotes = "CR in quotations.  ";

                        //Clean up,remove CR
                        CleanMarkUp = "";
                        CleanMarkUpSpan = "";
                        cleanCharacter = ' ';
                        CleanEWM = ErrorMessages.ewmUpdate; cleanNotes = "CR in quotations removed.  ";
                    }
                    else //Actual [CR] NL
                    {
                        OrigMarkUp = "Eol";
                        delimOpen = false;
                        //OrigMarkUpSpan = $"<span style='background-color:green;'>[{OrigMarkUp}]{""}</span>";
                        OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                        CleanMarkUp = OrigMarkUp;
                        CleanMarkUpSpan = OrigMarkUpSpan;
                    }


                }

                if (origCharacter == '\t')  // Check for tab origCharacter
                {
                    // Highlight tab characters in red
                    //Column Tabs
                    if (isCSV)  //if CSV
                    {
                        OrigMarkUp = "Tab";
                        //OrigMarkUpSpan = $"<span style='background-color: palevioletred;'>[{OrigMarkUp}]{""}</span>";
                        OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                        CleanMarkUp = OrigMarkUp;
                    }
                    else//assumed to be tab sep
                    {
                        if (quoteOpen == false)
                        {
                            //Tab as column
                            OrigMarkUp = "delimTab";
                            delimOpen = (delimOpen == true) ? false : true;
                            //OrigMarkUpSpan = $"<span style='background-color: teal;'>[{OrigMarkUp}]{""}</span>";
                            OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                            CleanMarkUp = "";
                        }
                        else
                        {
                            //Tab in text :
                            OrigMarkUp = "Tab";
                            //OrigMarkUpSpan = $"<span style='background-color: palevioletred;'>[{OrigMarkUp}]{""}</span>";
                            OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                            CleanMarkUp = OrigMarkUp;
                        }
                    }

                    CleanMarkUpSpan = OrigMarkUpSpan;
                }

                //For CSVs
                if (origCharacter == ',')  // Check for ,
                {
                    // Highlight tab characters in red
                    //Column Tabs
                    if (isCSV)  //if CSV
                    {
                        //Normal Comma in text
                        if (quoteOpen == true)
                        {
                            OrigMarkUp = "Comma";
                            //OrigMarkUpSpan = $"<span style='background-color: palevioletred;'>[{OrigMarkUp}]{""}</span>";
                            OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                            //OrigCheckEWM = ErrorMessages.ewmWarning; OrigCheckNotes = "Comma in quotations, cleaned data will be comma.    ";
                            //Clean up -use actual;comma in cleaned data

                            //Clean up
                            CleanMarkUp = OrigMarkUp;
                            CleanMarkUpSpan = OrigMarkUpSpan;
                            //cleanCharacter = ' ';
                            //CleanEWM = ErrorMessages.ewmUpdate; cleanNotes = "CR in quotations removed.  ";

                        }
                        else
                        {
                            OrigMarkUp = "delimComma";
                            delimOpen = (delimOpen == true) ? false : true;
                            //OrigMarkUpSpan = $"<span style='background-color: teal;'>[{OrigMarkUp}]{""}</span>";
                            OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                            //OrigCheckEWM = ErrorMessages.ewmWarning; OrigCheckNotes = "Comma not in quotations treat as delim,clean up treated as comma.  ";
                            CleanMarkUp = "delim";
                            CleanMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(CleanMarkUp)};'>[{CleanMarkUp}]</span>";
                            //CleanEWM = ErrorMessages.ewmUpdate; cleanNotes = "delimComma changed to delim. ";
                        }
                    }
                    else//assumed to be tab sep format
                    {
                        if (quoteOpen == true)
                        {
                            OrigMarkUp = "Comma";
                            //OrigMarkUpSpan = $"<span style='background-color: palevioletred;'>[{OrigMarkUp}]{""}</span>";
                            OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                            //   OrigCheckEWM = ErrorMessages.ewmWarning; OrigCheckNotes = "Comma in quotations.  ";
                            //Clean up -use actual;comma in cleaned data
                            CleanMarkUp = ",";
                            CleanMarkUpSpan = OrigMarkUpSpan;
                        }
                        else
                        {
                            //Comma outside quotes is fine in tsv
                            OrigMarkUp = "Comma";
                            //OrigMarkUpSpan = $"<span style='background-color: red;'>[{OrigMarkUp}{""}</span>";
                            OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                            //Updates for UI 
                            OrigCheckEWM = ErrorMessages.ewmWarning; OrigCheckNotes = "Comma outside quotations, this is OK in TSV. ";

                            //
                            CleanMarkUp = ",";
                            CleanMarkUpSpan = OrigMarkUpSpan;
                            cleanCharacter = origCharacter;
                            CleanEWM = ""; cleanNotes = "";

                        }
                    }
                    //CleanMarkUpSpan = OrigMarkUpSpan;


                }


                // Remove Trailing currency symbols if at the start or end, or after minus sign
                if (CurrencyDictionary.IsCurrencySymbol(origCharacter) &&
                     (prevCharacter == delimChar || nextCharacter == delimChar  || nextCharacter == '-' || prevCharacter == '-'))
                {
                    // Highlight currency
                    OrigMarkUp = "Curr";
                    //OrigMarkUpSpan = $"<span style='background-color: yellow;'>[{OrigMarkUp}]{""}</span>";
                    OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                    OrigCheckEWM = ErrorMessages.ewmError; OrigCheckNotes = "Currency symbol at start/end or after '-'. ";

                    //Clean up,remove Currency symbol
                    CleanMarkUp = "";
                    CleanMarkUpSpan = "";
                    cleanCharacter = '\0';  //Empty
                    CleanEWM = ErrorMessages.ewmUpdate; cleanNotes = "Currency Symbol " + origCharacter + " removed.  ";

                }





                if (origCharacter == '\"')  // Check for double quote origCharacter
                {
                    // Highlight double quote characters in light blue

                    if (isCSV)

                    {
                        if (quoteOpen == false)
                        {
                            if (prevCharacter == delimChar || i == 0 || prevOrigMarkUp == "Eol")
                            {
                                OrigMarkUp = "StQTE";
                                //OrigMarkUpSpan = $"<span style='background-color: aqua;'>[{OrigMarkUp}]{""}</span>";
                                OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                                quoteOpen = true;


                            }

                            else //if (prevCharacter !=delimChar)
                            {
                                OrigMarkUp = "QTE";
                                OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                                OrigCheckEWM = ErrorMessages.ewmError; OrigCheckNotes = "Quotation marks do not denote string. ";
                                quoteOpen = false; // Not a Proper quote

                                //Clean up,remove QTE
                                CleanMarkUp = "";
                                CleanMarkUpSpan = "";
                                cleanCharacter = '\0';  //Empty
                                CleanEWM = ErrorMessages.ewmUpdate; cleanNotes = "Quotation quote removed.  ";

                            }
                        }
                        else if (quoteOpen == true)
                        {
                            if (nextCharacter == delimChar || nextCharacter == '\n' || nextCharacter == '\r')
                            {
                                OrigMarkUp = "EndQTE";
                                //OrigMarkUpSpan = $"<span style='background-color: cornflowerblue;'>[{OrigMarkUp}]{""}</span>";
                                OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                                OrigCheckEWM = ErrorMessages.ewmError; OrigCheckNotes = "Quotation marks found, these will be removed.  ";
                                quoteOpen = false;
                                //Clean up,remove EndQTE
                                CleanMarkUp = "";
                                CleanMarkUpSpan = "";
                                cleanCharacter = '\0';  //Empty
                                CleanEWM = ErrorMessages.ewmUpdate; cleanNotes = "EndQuotation quotation marks removed.  ";
                            }

                            else // if (nextCharacter != delimChar)
                            {
                                OrigMarkUp = "QTE";
                                OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                                //OrigMarkUpSpan = $"<span style='background-color: blueviolet;'>[{OrigMarkUp}]{""}</span>";
                                OrigCheckEWM = ErrorMessages.ewmError; OrigCheckNotes = "Quotation marks found, these will be removed.  ";
                                quoteOpen = true;

                                //Clean up,remove QTE
                                CleanMarkUp = "";
                                CleanMarkUpSpan = "";
                                cleanCharacter = '\0';  //Empty
                                CleanEWM = ErrorMessages.ewmUpdate; cleanNotes = "Quotationx quote removed.  ";

                            }
                        }

                    }
                    else //Not CSV
                    {
                        if (quoteOpen == false)
                        {
                            if (prevCharacter == delimChar || i == 0)
                            {
                                OrigMarkUp = "QTE";
                                //OrigMarkUpSpan = $"<span style='background-color: aqua;'>[{OrigMarkUp}]{""}</span>";
                                OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                                OrigCheckEWM = ErrorMessages.ewmError; OrigCheckNotes = "Quotation marks found, these will be removed.  ";
                                quoteOpen = true;

                                //Clean up,remove QTE
                                CleanMarkUp = "";
                                CleanMarkUpSpan = "";
                                cleanCharacter = '\0';  //Empty
                                CleanEWM = ErrorMessages.ewmUpdate; cleanNotes = "Quotation marks removed.  ";
                            }

                            if (prevCharacter != delimChar)
                            {
                                OrigMarkUp = "QTE";
                                //OrigMarkUpSpan = $"<span style='background-color: blueviolet;'>[{OrigMarkUp}]{""}</span>";
                                OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                                OrigCheckEWM = ErrorMessages.ewmError; OrigCheckNotes = "Quotation marks found, these will be removed. ";

                                //Clean up,remove quote
                                CleanMarkUp = "";
                                CleanMarkUpSpan = OrigMarkUpSpan;
                                cleanCharacter = ' ';
                                CleanEWM = ErrorMessages.ewmUpdate; cleanNotes = "Quotation marks removed.  ";

                            }
                        }

                        else //if (quoteOpen == true)
                        {
                            if (nextCharacter == delimChar)
                            {
                                OrigMarkUp = "EndQTE";
                                //OrigMarkUpSpan = $"<span style='background-color: cornflowerblue;'>[EndQTE]{""}</span>";
                                OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                                quoteOpen = false;
                                OrigCheckEWM = ErrorMessages.ewmError; OrigCheckNotes = "Quotation marks found, these will be removed. ";

                                //Clean up,remove quote
                                CleanMarkUp = "";
                                CleanMarkUpSpan = OrigMarkUpSpan;
                                cleanCharacter = ' ';
                                CleanEWM = ErrorMessages.ewmUpdate; cleanNotes = "End Quotation marks removed.  ";
                            }

                            if (nextCharacter != delimChar)
                            {
                                OrigMarkUp = "QTE";
                                //OrigMarkUpSpan = $"<span style='background-color: blueviolet;'>[QTE]{""}</span>";
                                OrigMarkUpSpan = $"<span style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigMarkUp)};'>[{OrigMarkUp}]</span>";
                                OrigCheckEWM = ErrorMessages.ewmError; OrigCheckNotes = "Quotation marks found, these will be removed. ";

                                //Clean up,remove quote
                                CleanMarkUp = "";
                                CleanMarkUpSpan = OrigMarkUpSpan;
                                cleanCharacter = ' ';
                                CleanEWM = ErrorMessages.ewmUpdate; cleanNotes = "Quotation marks removed.  ";

                            }
                        }


                    }
                    //CleanMarkUpSpan = OrigMarkUpSpan;
                }
                //else
                //{
                // Your existing logic for non-control, non-whitespace characters
                //string encodedCharacter = WebUtility.HtmlEncode(origCharacter.ToString());


                //EWM and Note for output
                if (OrigCheckEWM != String.Empty)
                {
                    inputDataAnalysisNotes.AppendLine
                          ($"<div style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(OrigCheckEWM)};'>" +
                                    $"{OrigCheckEWM} - {OrigCheckNotes} : [{origCharacter}] ({iOrig.ToString()}).  </div>");
                }
                if (CleanEWM != String.Empty)
                {
                    cleanedDataNotes.AppendLine
                      ($"<div style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(CleanEWM)};'>" +
                                $"{CleanEWM} - {cleanNotes} : [{origCharacter}] ({iOrig.ToString()}).  </div>");

                }

                //Marked Up Data
                prevOrigMarkUp = OrigMarkUp;

                if (OrigMarkUp == string.Empty)
                {
                    inputDataMarkedUp.Append(origCharacter);
                    cleanedDataMarkedUp.Append(cleanCharacter);
                    cleanedDataForProcessing.Append(cleanCharacter);

                }
                //If there was an non std character
                else
                {
                    inputDataMarkedUp.Append(OrigMarkUpSpan);
                    cleanedDataMarkedUp.Append(CleanMarkUpSpan);
                    //cleanedDataForProcessing.Append("[" + OrigMarkUp + "]");
                    //cleanedDataForProcessing.Append(' ');


                    //Second Character
                    if (OrigMarkUp == "delimComma")
                    {
                        inputDataMarkedUp.Append(",");
                        cleanedDataMarkedUp.Append("");
                        cleanedDataForProcessing.Append("[delim]");
                    }
                    else if (OrigMarkUp == "delimTab")
                    {
                        inputDataMarkedUp.Append('\t');
                        cleanedDataMarkedUp.Append("");
                        cleanedDataForProcessing.Append("[delim]");
                    }
                    else if (OrigMarkUp == "Eol")
                    {
                        inputDataMarkedUp.Append('\n');
                        cleanedDataMarkedUp.Append('\n');
                        cleanedDataForProcessing.Append("[Eol]");
                    }
                    else
                    {
                        inputDataMarkedUp.Append(origCharacter);
                        if (cleanCharacter == '\0')
                        {
                            //Do Nothing
                        }
                        else
                        {
                            cleanedDataMarkedUp.Append(cleanCharacter);
                            cleanedDataForProcessing.Append(cleanCharacter);
                        }
                    }

                }


            }

            //Determine if Member or Scheme
            //If Headers contain Nino Then Member Data else Scheme
            DataSetType = DetermineDataSetType(inputDataMarkedUp);

            //End OF Char loop
            if (cleanedDataNotes.Length==0)
            {
                cleanedDataNotes.AppendLine
                  ($"<div style='background-color: {ErrorMessages.GetBackgroundColourEWMCode(ErrorMessages.ewmOK)};'>" +
                            $"{ErrorMessages.ewmOK} - No cleaning required.  </div>");

            }
                              
                


        }



        //Special Character Count in header row
        private static (int newlineCount, int carriageReturnCount, int otherSpecialCharacterCount, int newlinesBeforeFirstCR)
            CountSpecialCharactersInHeader(string headerRow)
        {
            if (string.IsNullOrEmpty(headerRow))
                return (0, 0, 0, 0);

            int newlineCount = 0;
            int carriageReturnCount = 0;
            int otherSpecialCharacterCount = 0;
            int newlinesBeforeFirstCR = 0;

            bool foundCR = false;

            foreach (char c in headerRow)
            {
                if (c == '\n')
                {
                    newlineCount++;
                    if (!foundCR)
                    {
                        newlinesBeforeFirstCR++;
                    }
                }
                else if (c == '\r')
                {
                    carriageReturnCount++;
                    foundCR = true;
                }
                else if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                {
                    otherSpecialCharacterCount++;
                }
            }

            return (newlineCount, carriageReturnCount, otherSpecialCharacterCount, newlinesBeforeFirstCR);
        }




        



        private static string GetInputDataFormat(string input)
        {
            if (IsCSVFormat(input))
            {
                return "CSV";
            }
            else if (IsTabSeparatedFormat(input))
            {
                return "Tab-Separated";
            }
            else if (IsTSVFormat(input))
            {
                return "TSV";
            }
            else if (IsExcelFormat(input))
            {
                return "Excel";
            }
            // Add more conditions for other common formats if needed
            // ...

            // If none of the known formats match, consider it as an unknown format
            return "Unknown";
        }

        private static bool IsCSVFormat(string input)
        {
            // Check if the inputData contains common CSV indicators
            // For example, presence of commas and newlines
            bool containsComma = input.Contains(",");
            bool containsNewline = input.Contains("\n");

            int countComma = input.Count(c => c == ',');
            int countTabs = input.Count(c => c == '\t');

            // Check for additional CSV-like characteristics
            bool hasHeaderRow = input.IndexOf("\n") < input.IndexOf(",");
            bool hasQuotes = input.Contains("\"");
            bool hasTabs = input.Contains("\t");

            // Evaluate the likelihood of CSV format based on multiple criteria
            //return containsComma && containsNewline &&
            //       (hasHeaderRow || hasQuotes || hasTabs);


            return (countComma > countTabs) ? true : false;
        }

        private static bool IsTabSeparatedFormat(string input)
        {
            // Check if the inputData contains common tab-separated indicators
            // For example, presence of tabs and newlines
            bool containsTab = input.Contains("\t");
            bool containsNewline = input.Contains("\n");

            int countComma = input.Count(c => c == ',');
            int countTabs = input.Count(c => c == '\t');


            // Check for additional tab-separated characteristics
            bool hasHeaderRow = input.IndexOf("\n") < input.IndexOf("\t");
            bool hasQuotes = input.Contains("\"");
            bool hasCommas = input.Contains(",");

            // Evaluate the likelihood of tab-separated format based on multiple criteria
            //            return containsTab && containsNewline &&
            //    (hasHeaderRow || hasQuotes || hasCommas);


            return (countComma > countTabs) ? false : true;
        }

        private static bool IsTSVFormat(string input)
        {
            // More detailed TSV check:
            // Presence of tabs without commas, and each line having the same number of columns
            string[] lines = input.Split('\n');

            if (lines.Length > 1)
            {
                int expectedColumnCount = lines[0].Split('\t').Length;

                foreach (var line in lines.Skip(1))
                {
                    // Use StringSplitOptions.None since you want to keep empty entries
                    string[] columns = line.Split('\t', (char)StringSplitOptions.None);

                    if (columns.Length != expectedColumnCount)
                    {
                        //return false;
                    }
                }

                //return true;
            }

            //return false;

            int countComma = input.Count(c => c == ',');
            int countTabs = input.Count(c => c == '\t');
            return (countComma > countTabs) ? false : true;


        }

        private static bool IsExcelFormat(string input)
        {
            // Check if the inputData contains common Excel indicators
            // For example, presence of Excel-specific characters or patterns
            // Adjust this check based on the characteristics of Excel data
            return input.Contains("xls") || input.Contains("xlsx");
            /* Add more Excel checks if needed */
        }


        public static (string headerRow, string cleanedData, string headerRowChange)
            ProcessHeaderRowAndCleanData(StringBuilder initialAnalysisData)
        {

            //string inheaderRowChange = headerRowChange;

            if (initialAnalysisData == null || initialAnalysisData.Length == 0)
            {
                return (string.Empty, string.Empty, "#OK No data.  ");
            }

            // Convert the StringBuilder to a string
            string initialAnalysisDataString = initialAnalysisData.ToString();
            string inputDataFormat = GetInputDataFormat(initialAnalysisData.ToString()); ;

            // Find the true end of the line for header 
            int trueEndOfLineIndex = initialAnalysisDataString.IndexOf(Environment.NewLine);
            if (trueEndOfLineIndex == -1)
            {
                // If no newline characters are found, use the length of the string as the end of the line
                trueEndOfLineIndex = initialAnalysisDataString.Length;
            }

            //First remove all new line et from between quote
            bool withinQuotes = false;


            string[] fields = inputDataFormat == "TSV" || inputDataFormat == "Tab-Separated" ?
                    initialAnalysisData.ToString().Split('\t') :
                    initialAnalysisData.ToString().Split(',');

            for (long i = 0; i < fields.Length; i++)
            {
                string field = fields[i];

                if (field.Contains("\""))
                {
                    withinQuotes = !withinQuotes;
                }
                else if (withinQuotes)
                {
                    // Replace newline characters within the field
                    fields[i] = field.Replace("\r", "[SmNL]").Replace("\n", "[SmNL]");
                }
            }


            // Find the true end of each line
            string input = initialAnalysisData.ToString();
            string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);



            // Process the header row
            string cleanedHeaderRow = lines.FirstOrDefault() ?? string.Empty;
            if (!string.IsNullOrEmpty(cleanedHeaderRow))
            {

                for (long i = 0; i < fields.Length - 1; i++)
                {
                    fields[i] = fields[i].Replace("\r", "[RemovedCR]").Replace("\n", "[RemovedNL]");


                    fields[i] = ReplaceNewLineWithinQuotes(fields[i]);


                    // New rule: Replace newline characters within quotes with [SmNL]
                    // fields[i] = Regex.Replace(fields[i], @"(?<="")\r\n|\n\r|\r|\n(?="")", "[SmNL]");
                }

                //  cleanedHeaderRow = string.Join(inputDataFormat == "TSV" || inputDataFormat == "Tab-Separated" ? "\t" : ",", fields);
                cleanedHeaderRow = string.Join("\t", fields);
            }


            cleanedHeaderRow = string.Join("\t", fields);

            //else
            //{
            //    if (inputDataFormat == "TSV" || inputDataFormat == "Tab-Separated")
            //    {
            //        if (!string.IsNullOrEmpty(cleanedHeaderRow))
            //        {
            //            // Split the header row into fields
            //            string[] fields = cleanedHeaderRow.Split('\t');

            //            // Replace newline characters in the middle of the header row
            //            for (int i = 0; i < fields.Length - 1; i++)
            //            {
            //                fields[i] = fields[i].Replace("\r", "[RemovedCR]").Replace("\n", "[RemovedNL]");
            //                // headerRowChange+=$"#War - Change from '{i}' to '{i}'");
            //            }

            //            // Join the fields to get the cleaned header row
            //            cleanedHeaderRow = string.Join("\t", fields);
            //        }
            //    }
            //    //assume csv-x
            //    else
            //    {
            //        // Split the header row into fields
            //        string[] fields = cleanedHeaderRow.Split((','));

            //        // Replace newline characters in the middle of the header row
            //        for (int i = 0; i < fields.Length - 1; i++)
            //        {
            //            fields[i] = fields[i].Replace("\r", "[RemovedCR]").Replace("\n", "[RemovedNL]");
            //        }

            //        // Join the fields to get the cleaned header row
            //        cleanedHeaderRow = string.Join("'", fields);
            //    }

            //    // Split the inputData into lines
            //    //string[] lines = initialAnalysisDataString.Split('\n');

            //    // Count the total number of tabs in the entire string
            //    //int totalTabCount = initialAnalysisDataString.Count(c => c == '\t');

            //    // Estimate the number of tabs per row
            //    //int tabsPerRow = totalTabCount / lines.Length;

            //    //// Identify the actual end of the header row
            //    //int actualHeaderEndIndex = -1;
            //    //foreach (var line in lines.Skip(1)) // Skip the first line as it's part of the header
            //    //{
            //    //    int tabCount = line.Count(c => c == '\t');
            //    //    if (tabCount == tabsPerRow)
            //    //    {
            //    //        actualHeaderEndIndex = initialAnalysisDataString.IndexOf(line) + line.Length + Environment.NewLine.Length;
            //    //        break;
            //    //    }
            //    //}

            //    // Extract the actual header row including newline characters
            //    //    // cleanedHeaderRow = initialAnalysisDataString.Substring(0, cleanedHeaderRow);

            //}

            //        // Process each line (excluding the header) and replace newline characters
            //        StringBuilder originalCleanedDataMarkedUp = new StringBuilder();
            //        foreach (var line in lines.Skip(1))
            //        {
            //            // Split the line into fields based on the inputData data format
            //            string[] fields;
            //            if (inputDataFormat == "TSV" || inputDataFormat == "Tab-Separated")
            //            {
            //                fields = line.Split('\t');
            //            }
            //            else // assuming CSV format
            //            {
            //                fields = line.Split(',');
            //            }

            //            // Replace newline characters in the middle of the line
            //            for (int i = 0; i < fields.Length - 1; i++)
            //            {
            //                fields[i] = fields[i].Replace("\r", "[RemovedCR]").Replace("\n", "[RemovedNL]");
            //            }

            //            // Join the fields to get the cleaned line
            //            originalCleanedDataMarkedUp.AppendLine(string.Join(inputDataFormat == "TSV" || inputDataFormat == "Tab-Separated" ? "\t" : ",", fields));
            //        }

            /*
             * // Extract the actual header row including newline characters
            //OK  string cleanedHeaderRow = initialAnalysisDataString.Substring(0, trueEndOfLineIndex);

            // Check if the actual header row is not empty
            if (string.IsNullOrEmpty(cleanedHeaderRow))
            {
                return (cleanedHeaderRow, "originalCleanedDataMarkedUp", "EMPTY");
            }
            */


            return (cleanedHeaderRow, string.Join("\t", fields), "headerRowChange");
        }




        private static string CheckHeaderRowChanges(string headerRow)
        {
            // Perform your checks here and return a message describing the changes
            // For example, you can compare the headerRow with a predefined structure or make specific validations.

            // Dummy logic: Check if the headerRow contains the word "Date"
            if (headerRow.Contains("Date"))
            {
                // Replace this with your actual logic for determining the change
                string updatedHeaderRow = headerRow.Replace("Date", "NewDate");

                return $"#War - Change from '{headerRow}' to '{updatedHeaderRow}'";
            }

            return "#OK No changes to header required";
        }

        private static string DetermineDataSetType(StringBuilder inputDataMarkedUp)
        {
            // Determine if Member or Scheme
            bool isMemberData = inputDataMarkedUp.ToString().IndexOf("NINO", StringComparison.OrdinalIgnoreCase) >= 0;
            return isMemberData ? "Member" : "Scheme";
        }

        private static string ReplaceNewLineWithinQuotes(string input)
        {
            StringBuilder result = new StringBuilder();
            bool withinQuotes = false;

            foreach (char character in input)
            {
                if (character == '"')
                {
                    withinQuotes = !withinQuotes;
                }
                else if (withinQuotes && (character == '\r' || character == '\n'))
                {
                    result.Append("[SmNL]");
                    continue; // Skip appending the original newline origCharacter
                }

                result.Append(character);
            }

            return result.ToString();
        }

    }
}


