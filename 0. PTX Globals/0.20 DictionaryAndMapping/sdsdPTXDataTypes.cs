using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents a row in the PTX Data Type mapping data.
    /// </summary>
    
    
    
    
    
    public class PTXDataTypeRow
    {
        public string PTXDataTypeUID { get; set; }
        public string PTXDefaultOther { get; set; }
        public string PTXDataTypeName { get; set; }
        public string PTXDataTypeDescription { get; set; }
        public string PTXDataTypeT1 { get; set; }
        public bool T1AllowNullable { get; set; }
        public dynamic T1Min { get; set; }
        public dynamic T1Max { get; set; }
        public List<dynamic> T1List { get; set; }
        public dynamic T1Default { get; set; }
        public string PTXDataTypeT2 { get; set; }
        public bool T2AllowNullable { get; set; }
        public dynamic T2Min { get; set; }
        public dynamic T2Max { get; set; }
        public List<dynamic> T2List { get; set; }
        public dynamic T2Default { get; set; }

        /// <summary>
        /// Default constructor for PTXDataTypeRow.
        /// </summary>
        public PTXDataTypeRow()
        {
            // Update or initialize properties if needed
        }

        /// <summary>
        /// Parameterized constructor for PTXDataTypeRow.
        /// </summary>
        public PTXDataTypeRow(
            string inPTXDataTypeUID2, string inPTXDefaultOther, string inPTXDataTypeName, string inPTXDataTypeT1,
            bool t1AllowNullable, string t1Min, string t1Max, List<dynamic> t1List, string t1Default,
            string inPTXDataTypeT2, bool t2AllowNullable, string t2Min, string t2Max, List<dynamic> t2List, string t2Default)
        {
            PTXDataTypeUID = inPTXDataTypeUID2;
            PTXDefaultOther = inPTXDefaultOther;
            PTXDataTypeName = inPTXDataTypeName;
            PTXDataTypeT1 = inPTXDataTypeT1;
            T1AllowNullable = t1AllowNullable;
            T1Min = t1Min;
            T1Max = t1Max;
            T1List = t1List;
            T1Default = t1Default;
            PTXDataTypeT2 = inPTXDataTypeT2;
            T2AllowNullable = t2AllowNullable;
            T2Min = t2Min;
            T2Max = t2Max;
            T2List = t2List;
            T2Default = t2Default;
        }
    }


    /// <summary>
    /// Represents a dictionary and mapping for PTX data types.
    /// </summary>
    public class PTXDataTypes
    {
        [JsonProperty("TypeData")]
        public List<PTXDataTypeRow> TypeData { get; set; }

        /// <summary>
        /// Default constructor for PTXFieldDictionaryAndMap.
        /// </summary>
        public PTXDataTypes()
        {
            TypeData = new List<PTXDataTypeRow>();
            //            ReadPTXDataTypesFromCsv();
            ReadPTXDataTypesFromJson();
        }

        /// <summary>
        //Add summayr here : 
        /// (dynamic dynRetValue, string messageEWM) CheckValueVsType(string queryFieldName, string inValueToCheck, PTXFieldDictionaryAndMap  inPTXFieldDictionaryAndMap , boolean bCorrectValue)		
        ///        string queryFieldName
        ///        string inValueToCheck
        ///        PTXFieldDictionaryAndMap PTXFieldDictionaryAndMap
        ///        bool bCorrectValue	//Used to indicate if a check on type (false) or a check and correct is to be done.
        ///        dynamic dynRetValue	//the string inValueToCheck returned as a new type
        ///        string retMessage	//Any error messages generated.
        ///        Finds the data type based on the provided field name.
        /// Not case sensitive
        /// </summary>
        public (dynamic retValue, List<string> messageEWM)
            CheckValueVsType(string queryFieldName, string inValueToCheck,
                                PTXFieldDictionaryAndMap inPTXFieldDictionaryAndMap,
                                List<PTXMappingRow> inlistPTXFieldMappings,
                                bool bCorrectValue)
        {
            dynamic dynRetValue = null;
            //FOrmat output for messages
            string msgRetValue = ErrorMessages.ewmEmpty;
            msgRetValue = inValueToCheck.ToString();
            if (inValueToCheck == "") { msgRetValue = ErrorMessages.ewmEmpty; }

            List<string> messageEWM = new List<string>();
            messageEWM.Add($"Func: CheckValueVsType. ");

            try
            {
                // Step 0: Get FieldType from Fieldname dictionary
                string myPTXDataTypeName = ErrorMessages.ewmNotFound;
                myPTXDataTypeName = inPTXFieldDictionaryAndMap.FindPTXFieldNameDataType(queryFieldName);

                //If not record Warning and uses Mapped Value
                if (string.IsNullOrEmpty(myPTXDataTypeName) || myPTXDataTypeName == ErrorMessages.ewmNotFound)
                { try
                    {
                        if (inlistPTXFieldMappings != null){
                            //bbbb
                            //If queryFieldname is not found, the use the type defeind by the  System in ''
                            var mappingRow = inlistPTXFieldMappings.FirstOrDefault(row => row.CalcName == queryFieldName);
                            myPTXDataTypeName = mappingRow.CalcTypeName;
                            messageEWM.Add($"{ErrorMessages.ewmWarning} FieldName : {queryFieldName} not found in dictionary, system generated type {myPTXDataTypeName} has been used.  ");
                        }
                    }
                    catch
                    {
                        myPTXDataTypeName = "string";
                        messageEWM.Add($"{ErrorMessages.ewmWarning} FieldName : {queryFieldName} not found in dictionary, a default type {myPTXDataTypeName} has been used.  ");
                    }
                }
                
                // Step 0.1: Get the data row for myPTXDataTypeName
                var myPTXDataTypes = new PTXDataTypes();
                //var myPTXDataTypeRow = myPTXDataTypes.TypeData.FirstOrDefault(row => row.PTXDataTypeName == myPTXDataTypeName);
                //NOt case dependant
                var myPTXDataTypeRow = myPTXDataTypes.TypeData.FirstOrDefault(row =>
                    string.Equals(row.PTXDataTypeName, myPTXDataTypeName, StringComparison.OrdinalIgnoreCase));

                if (myPTXDataTypeRow == null)
                {
                    messageEWM.Add($"PTXDataType : {ErrorMessages.ewmNotFound}.  ");
                    messageEWM.Insert(0, ErrorMessages.ewmWarning);
                    msgRetValue = inValueToCheck;
                    return (msgRetValue, messageEWM);
                }

                // Step 0.2: Get Types from myDataTypeRow
                var myDataType1 = myPTXDataTypeRow.PTXDataTypeT1;
                var myDataType2 = myPTXDataTypeRow.PTXDataTypeT2 ?? ErrorMessages.ewmNA;
                

                // Set Default Values
                dynamic T1Default = null;
                dynamic T2Default = null;

                if (myPTXDataTypeRow.T1Default != null)
                {
                    T1Default = myPTXDataTypeRow.T1Default;
                }

                if (myPTXDataTypeRow.T2Default != null)
                {
                    T2Default = myPTXDataTypeRow.T2Default;
                }

                // Step 2: Cast newValue to new var myDataType1 and/or 2
                // Step 2.1: Set bool bCastSuccessfulT1 = false AND bCastSuccessfulT2 = False
                bool bCastSuccessfulT1 = false;
                bool bCastSuccessfulT2 = false;
                dynamic retValueT1;
                bool bCastSuccessfulT1X = false;
                dynamic retValueT2;
                bool bCastSuccessfulT2X = false;

                // Step 2.2: Can newValue be cast as myDataTypeT1?
                // Uses NEW function

                if (FieldTypesUtility.IsNullOrEmptyOrWhiteSpace(inValueToCheck))
                {
                    if (myPTXDataTypeRow.T1AllowNullable)
                    { dynRetValue = null; }
                    else
                    { dynRetValue = T1Default; }

                    bCastSuccessfulT1X = true; // Treat as successful cast
                }
                else
                {
                    (dynRetValue, bCastSuccessfulT1X) = FieldTypesUtility.TryToCastValue(inValueToCheck, myDataType1);
                }


                if (bCastSuccessfulT1X)
                {
                    bCastSuccessfulT1 = bCastSuccessfulT1X;
                    //msgRetValue = dynRetValue;

                    messageEWM.Add($"T1 Cast : {ErrorMessages.ewmOK}. ");
                }
                else if (myDataType2 != ErrorMessages.ewmNA)
                {
                    if (FieldTypesUtility.IsNullOrEmptyOrWhiteSpace(inValueToCheck))
                    {
                        if (myPTXDataTypeRow.T2AllowNullable)
                        { dynRetValue = null; }
                        else
                        { dynRetValue = T2Default; }
                        bCastSuccessfulT2X = true;

                    }
                    else
                    {
                        (dynRetValue, bCastSuccessfulT2X) = FieldTypesUtility.TryToCastValue(inValueToCheck, myDataType2);
                    }

                    if (bCastSuccessfulT2X)
                    {
                        bCastSuccessfulT2 = bCastSuccessfulT2X;
                        //msgRetValue = dynRetValue;

                        messageEWM.Add($"T2 Cast : {ErrorMessages.ewmOK}.  ");
                    }
                    else
                    {
                        messageEWM.Add($"T1 cast :  {ErrorMessages.ewmFail}. Cannot cast  {msgRetValue}  to {myDataType1} or to T2 {myDataType2}.  ");
                        dynRetValue = inValueToCheck;
                        messageEWM.Insert(0, ErrorMessages.ewmFail);
                        return (dynRetValue, messageEWM);
                    }
                }
                else
                {
                    messageEWM.Add($"T1 cast :  {ErrorMessages.ewmFail}. Cannot cast {msgRetValue}  to {myDataType1}.  ");
                    messageEWM.Insert(0, ErrorMessages.ewmFail);
                    dynRetValue = inValueToCheck;
                    return (dynRetValue, messageEWM);
                }

                if (bCastSuccessfulT1)
                {
                   
                    // Step 9: Check and Correct newValue
                    // Step 9.1: Check Min Max Range for T1
                    //ZXXXXXISSUES FOR TYEP ROW NOT BEIN NULL
                    if (myPTXDataTypeRow.T1Min != null && dynRetValue != null && myPTXDataTypeRow.T1Min != ErrorMessages.ewmNA)
                    {
                     
                        dynamic T1Min = FieldTypesUtility.TryToCastValue(myPTXDataTypeRow.T1Min, myPTXDataTypeRow.PTXDataTypeT1);
                      


                        // Check if dynRetValue is less than T1Min
                        if (dynRetValue < T1Min.Item1)
                        {
                            if (bCorrectValue)
                            {
                                dynRetValue = T1Min.Item1;
                                messageEWM.Add($"{ErrorMessages.ewmWarning} {msgRetValue} < T1Min {dynRetValue.ToString()}, T1Min has been used. ");
                            }
                            else
                            {
                                messageEWM.Insert(0, ErrorMessages.ewmFail);
                                messageEWM.Add($"{ErrorMessages.ewmError} {msgRetValue}  < T1Min {T1Min.Item1.ToString()}. ");
                            }
                        }
                        else
                        {
                            messageEWM.Add($"{ErrorMessages.ewmOK} {msgRetValue} > T1Min {dynRetValue.ToString()} ");
                        }
                    }

                    // Check if T1Max is not null
                    if (myPTXDataTypeRow.T1Max != null && dynRetValue != null && myPTXDataTypeRow.T1Max != ErrorMessages.ewmNA)
                    {
                        dynamic T1Max = FieldTypesUtility.TryToCastValue(myPTXDataTypeRow.T1Max, myPTXDataTypeRow.PTXDataTypeT1);

                        // Check if dynRetValue is greater than T1Max
                        if (dynRetValue > T1Max.Item1)
                        {
                            if (bCorrectValue)
                            {
                                dynRetValue = T1Max.Item1;
                                messageEWM.Add($"{ErrorMessages.ewmWarning} {msgRetValue} > T1Max {dynRetValue.ToString()}, T1Max has been used. ");
                            }
                            else
                            {
                                messageEWM.Insert(0, ErrorMessages.ewmFail);
                                messageEWM.Add($"{ErrorMessages.ewmError} {msgRetValue}  > T1Max {T1Max.Item1.ToString()}. ");
                            }
                        }
                        else
                        {
                            messageEWM.Add($"{ErrorMessages.ewmOK} {msgRetValue} < T1Max {dynRetValue.ToString()} ");
                        }
                    }
                }

                if (bCastSuccessfulT2)
                {
                    // Step 9.1.2: Check Min Max Range for T2
                    if (myPTXDataTypeRow.T2Min != null && dynRetValue != null && myPTXDataTypeRow.T2Min != ErrorMessages.ewmNA)
                    {
                        dynamic T2Min = FieldTypesUtility.TryToCastValue(myPTXDataTypeRow.T2Min, myPTXDataTypeRow.PTXDataTypeT2);

                        // Check if dynRetValue is less than T2Min
                        if (dynRetValue < T2Min.Item1)
                        {
                            if (bCorrectValue)
                            {
                                dynRetValue = T2Min.Item1;
                                messageEWM.Add($"{ErrorMessages.ewmWarning} {msgRetValue} < T2Min {dynRetValue.ToString()}, T2Min has been used. ");
                            }
                            else
                            {
                                messageEWM.Insert(0, ErrorMessages.ewmFail);
                                messageEWM.Add($"{ErrorMessages.ewmError} {msgRetValue}  < T2Min {T2Min.Item1.ToString()}. ");
                            }
                        }
                        else
                        {
                            messageEWM.Add($"{ErrorMessages.ewmOK} {msgRetValue} > T2Min {dynRetValue.ToString()} ");
                        }
                    }

                    // Check if T2Max is not null
                    if (myPTXDataTypeRow.T2Max != null && myPTXDataTypeRow.T2Max != ErrorMessages.ewmNA)
                    {
                        dynamic T2Max = FieldTypesUtility.TryToCastValue(myPTXDataTypeRow.T2Max, myPTXDataTypeRow.PTXDataTypeT2);

                        // Check if dynRetValue is greater than T2Max
                        if (dynRetValue > T2Max.Item1)
                        {
                            if (bCorrectValue)
                            {
                                dynRetValue = T2Max.Item1;
                                messageEWM.Add($"{ErrorMessages.ewmWarning} {msgRetValue} > T2Max {dynRetValue.ToString()}, T2Max has been used. ");
                            }
                            else
                            {
                                messageEWM.Insert(0, ErrorMessages.ewmFail);
                                messageEWM.Add($"{ErrorMessages.ewmError} {msgRetValue}  > T2Max {T2Max.Item1.ToString()}. ");
                            }
                        }
                        else
                        {
                            messageEWM.Add($"{ErrorMessages.ewmOK} {msgRetValue} < T2Max {dynRetValue.ToString()} ");
                        }
                    }

                   // return (dynRetValue, messageEWM);
                } 

                //End of Min max checks, list will not be required


                // Step 9.2: Check value is on list T1List
                if (bCastSuccessfulT1 && myPTXDataTypeRow.T1List != null)
                {
                    var T1List = myPTXDataTypeRow.T1List;

                    if (!T1List.Contains(dynRetValue))
                    {
                        messageEWM.Add("#Err dynRetValue " + dynRetValue + " is not on T1List. ");
                        if (bCorrectValue)
                        {
                            dynRetValue = myPTXDataTypeRow.T1Default;
                            messageEWM.Add("#War dynRetValue is not on T1List, T1Default has been used. ");
                        }
                        return (dynRetValue, messageEWM);
                    }
                    else
                    {
                        dynRetValue = inValueToCheck;
                        messageEWM.Add("#OK dynRetValue " + dynRetValue + " is on T1List. ");
                    }
                }

                // Step 9.2.1: Check value is on list T2List
                if (bCastSuccessfulT2 && myPTXDataTypeRow.T2List != null)
                {
                    var T2List = myPTXDataTypeRow.T2List;

                    if (!T2List.Contains(dynRetValue))
                    {
                        messageEWM.Add("#Err dynRetValue " + dynRetValue.ToString() + " is not on T2List. ");
                        messageEWM.Insert(0, ErrorMessages.ewmFail);
                        if (bCorrectValue)
                        {
                            dynRetValue = myPTXDataTypeRow.T2Default;
                            messageEWM.Add("#War dynRetValue is not on T2List, T2Default has been used. ");

                            return (dynRetValue, messageEWM);
                        }
                        else
                        {
                            messageEWM.Add("#OK dynRetValue " + dynRetValue.ToString() + " is on T2List. ");
                        }
                    }
                    //End List Checks
                    return (dynRetValue, messageEWM);
                }

                // 
                return (dynRetValue, messageEWM);


            }
            catch (Exception ex)
            {
                // Handle exception
                messageEWM.Add($"Exception occurred: {ex.Message}");
                messageEWM.Insert(0, ErrorMessages.ewmFail);
                return (dynRetValue, messageEWM);
            }
        }

        // Overloaded method for multiple, coule be more efficient
        public (List<dynamic> listRetValue, List<List<String>> listmessagesEWM) 
            CheckValueVsType(string queryFieldName, List<string> inValueToCheck, PTXFieldDictionaryAndMap inPTXFieldDictionaryAndMap, List<PTXMappingRow>  inlistPTXFieldMappings, bool bCorrectValue)
        {
            List<dynamic> retValues = new List<dynamic>();
            List<List<string>> listmessagesEWM = new List<List<string>>();
            //DQAAudit dqaAuditList = new List<DQAAudit>();

            // Iterate over the list of values to check
            foreach (string valueToCheck in inValueToCheck)
            {
                List<string> thisMessageEWM = new List<string>();

                // Call the original method for each value
                var (retValue, MessageEWM) = CheckValueVsType(queryFieldName, valueToCheck, inPTXFieldDictionaryAndMap, inlistPTXFieldMappings, bCorrectValue);
                //var dqaAuditList = new DQAAudit();

                // Add the results to the lists
                retValues.Add(retValue);
                listmessagesEWM.Add(MessageEWM);

            }

            // Return the lists of results
            //return (retValues, messagesEWM);
            return (retValues, listmessagesEWM);
        }



        // <summary>
        /// Reads PTX data types from a CSV file.
        /// Source 'LIVE DataDictionary.xlsm' ptxFieldDictionaryAndMapMatrix.
        /// Added to PTXClassLibrary Resource file as CSV.
        /// Location: \PTX.ClassLibrary\0. PTX Globals\0.20 DictionaryAndMapping\
        /// Filename: PTXDataTypesTable.CSV
        /// Filename: PTXDataTypesTableJson.CSV
        /// Notes:
        /// Column                   -->> 0               , 1              , 2               , 3                  , 4               , 5 onwards
        /// Row 1 = Header           -->> PTXDataTypeUID, PTXDefaultOther, PTXDataTypeName, PTXDataTypeT1, T1AllowNullable, T1Min, T1Max, T1List, T1Default, PTXDataTypeT2, T2AllowNullable, T2Min, T2Max, T2List, T2Default
        /// Row 2 = SourceOfKnownName -->> BLANK           , BLANK           , BLANK           , BLANK            , BLANK           , General, Client XYZ, Compendia, System X etc etc
        /// </summary>

        //private void ReadPTXDataTypesFromCsv()
        //{
        //    using (StringReader reader = new StringReader(Properties.Resources.PTXDataTypesTable))
        //    {
        //        string line;

        //        // PTXDataTypeUID, PTXDefaultOther, PTXDataTypeName, PTXDataTypeT1, T1AllowNullable, T1Min, T1Max, T1List, T1Default, PTXDataTypeT2, T2AllowNullable, T2Min, T2Max, T2List, T2Default
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            var fields = line.Split(',');

        //            if (fields.Length >= 15)
        //            {
        //                List<dynamic> t1List = new List<dynamic>();
        //                List<dynamic> t2List = new List<dynamic>();

        //                // Parsing List<dynamic> values
        //                if (!string.IsNullOrWhiteSpace(fields[7]))
        //                {
        //                    t1List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(fields[7]);
        //                }

        //                if (!string.IsNullOrWhiteSpace(fields[13]))
        //                {
        //                    t2List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(fields[13]);
        //                }

        //                TypeData.Add(new PTXDataTypeRow(
        //                    fields[0].Trim(), fields[1].Trim(), fields[2].Trim(), fields[3].Trim(), bool.Parse(fields[4]), fields[5].Trim(),
        //                    fields[6].Trim(), t1List, fields[8].Trim(), fields[9].Trim(), bool.Parse(fields[10]), fields[11].Trim(),
        //                    fields[12].Trim(), t2List, fields[14].Trim()
        //                ));
        //            }
        //        }
        //    }
        //}

        private void ReadPTXDataTypesFromJson()
        {
            /// Filename: PTXDataTypesTableJson.CSV

            string json = Properties.Resources.PTXDataTypesTableJson;
            TypeData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PTXDataTypeRow>>(json);


            //string json = Properties.Resources.PTXDataTypesTableJson;

            //// Deserialize JSON to a dynamic object
            //dynamic dynamicData = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            //// Convert dynamic object to List<PTXDataTypeRow>
            //TypeData = ConvertDynamicToPTXDataTypeRowList(dynamicData);

        }

        private List<PTXDataTypeRow> ConvertDynamicToPTXDataTypeRowList(dynamic dynamicData)
        {
            List<PTXDataTypeRow> result = new List<PTXDataTypeRow>();

            foreach (var item in dynamicData)
            {
                // Map dynamic properties to PTXDataTypeRow
                PTXDataTypeRow row = new PTXDataTypeRow(
                    item.PTXDataTypeUID,
                    item.PTXDefaultOther,
                    item.PTXDataTypeName,
                    item.PTXDataTypeT1,
                    item.T1AllowNullable,
                    item.T1Min,
                    item.T1Max,
                    item.T1List.ToObject<List<dynamic>>(),
                    item.T1Default,
                    item.PTXDataTypeT2,
                    item.T2AllowNullable,
                    item.T2Min,
                    item.T2Max,
                    item.T2List.ToObject<List<dynamic>>(),
                    item.T2Default
                );

                result.Add(row);
            }

            return result;
        }

    }
}
