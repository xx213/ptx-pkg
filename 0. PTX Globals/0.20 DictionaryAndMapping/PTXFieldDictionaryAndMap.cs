using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents a row in the PTX field mapping data.
    /// </summary>
    public class PTXFieldMappingDataRow
    {
        [JsonProperty("PTXCalcName")]
        public string PTXCalcName { get; 
            set; }

        [JsonProperty("PTXDataTypeName")]
        public string PTXDataTypeName { get; set; }

        [JsonProperty("PensionDataType")]
        public string PensionDataType { get; set; }

        [JsonProperty("PTXClassName")]
        public string PTXClassName { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("KnownNames")]
        public List<string> KnownNames { get; set; }

        /// <summary>
        /// Default constructor for PTXFieldMappingDataRow.
        /// </summary>
        public PTXFieldMappingDataRow()
        {
            PTXCalcName = "";
            PTXDataTypeName = "";
            PensionDataType = "";
            PTXClassName = "";
            Description = "";
            KnownNames = new List<string>();
        }

        /// <summary>
        /// Parameterized constructor for PTXFieldMappingDataRow.
        /// </summary>
        public PTXFieldMappingDataRow(string inPTXFieldName, string inDataTypeName, string inPensionDataType, string inPTXClassName, string inDescription, List<string> lstString)
        {
            PTXCalcName = inPTXFieldName;
            PTXDataTypeName = inDataTypeName;
            PensionDataType = inPensionDataType;
            PTXClassName = inPTXClassName;
            Description = inDescription;
            KnownNames = lstString;
        }
    }

    /// <summary>
    /// Represents a dictionary and mapping for PTX fields.
    /// </summary>
    public class PTXFieldDictionaryAndMap
    {
        [JsonProperty("TypeData")]
        public List<PTXFieldMappingDataRow> FieldData { get; set; }

        /// <summary>
        /// Default constructor for PTXFieldDictionaryAndMap.
        /// </summary>
        public PTXFieldDictionaryAndMap()
        {
            FieldData = new List<PTXFieldMappingDataRow>();
            //ReadPTXDictionaryAndMappingFromCsv();
            ReadPTXDictionaryAndMappingFromjson();

            //quick test delete 
            //string json = Properties.Resources.PTXDataTypesTableJson;
            //var TypeData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PTXDataTypeRow>>(json);
        }

        private void PTXFieldDictionaryAndMapCSV()
        {
            FieldData = new List<PTXFieldMappingDataRow>();
            ReadPTXDictionaryAndMappingFromCsv();
        }

        private void PTXFieldDictionaryAndMapjson()
        {
            FieldData = new List<PTXFieldMappingDataRow>();
            ReadPTXDictionaryAndMappingFromjson();
        }

        /// <summary>
        /// Finds the data type based on the provided field name.
        /// Not case sensitive
        /// </summary>
        public string FindPTXFieldNameDataType(string queryFieldName)
        {
            foreach (var dataTypeInfo in FieldData)
            {
                if (dataTypeInfo.PTXCalcName.Equals(queryFieldName, StringComparison.OrdinalIgnoreCase))
                {
                  //Here would be an option to find NON ptx fiel name
                  return dataTypeInfo.PTXDataTypeName;
                }
            }

            return ErrorMessages.ewmNotFound;
        }

       //XXXXXX
       public string FindANYFieldNameDataType(string queryFieldName, string adminSystemName)


        {
            foreach (var dataTypeInfo in FieldData)
            {
                //xxxx
                if (dataTypeInfo.PTXCalcName.Equals(queryFieldName, StringComparison.OrdinalIgnoreCase))
                {
                    //Here would be an option to find NON ptx field name
                    return dataTypeInfo.PTXDataTypeName;
                    //Find position of header based on adminSystem Name
                    //return dataTypeInfo.Description(pos of header)

                }
            }

            return ErrorMessages.ewmNotFound;
        }

        /// <summary>
        /// Reads PTX dictionary and mapping data from a CSV file.
        /// // Source 'LIVE DataDictionary.xlsm' ptxFieldDictionaryAndMapMatrix.
        /// Added to PTXClassLibrary Resource file as CSV.
        /// Location: \PTX.ClassLibrary\0. PTX Globals\0.20 DictionaryAndMapping\
        /// Filename: PTXFieldDictionaryAndMapTable.CSV
        ///Notes :
        ///  Column                    -->> 0           , 1          , 2           , 3              , 4           , 5 onwards
        ///  Row 1 = Header            -->> PTXCalcName, PTXDataTypeName, PensionDataType, PTXClassName, Description, KnownNames (For Mapping) 1..1000
        ///  Row 2 = SourceOfKnownName -->> BLANK      , BLANK       , BLANK          , BLANK       , BLANK      , General, Client XYZ, Compendia, System X etc etc
        /// </summary>
        private void ReadPTXDictionaryAndMappingFromCsv()
        {
            using (StringReader reader = new StringReader(Properties.Resources.PTXFieldDictionaryAndMapTable))
            {
                string line;

                // PTXCalcName, PTXDataTypeName, PensionDataType, PTXClassName, Description, KnownNames 1..1000
                while ((line = reader.ReadLine()) != null)
                {
                    var fields = line.Split(',');

                    if (fields.Length >= 5)
                    {
                        List<string> additionalItems = new List<string>();

                        for (int i = 5; i < fields.Length; i++)
                        {
                            if (!string.IsNullOrWhiteSpace(fields[i]))
                            {
                                additionalItems.Add(fields[i].Trim());
                            }
                        }

                        FieldData.Add(new PTXFieldMappingDataRow(
                            fields[0].Trim(), fields[1].Trim(), fields[2].Trim(), fields[3].Trim(), fields[4].Trim(),
                            additionalItems
                        ));
                    }
                }
            }
        }

        private void ReadPTXDictionaryAndMappingFromjson()
        {
            string json = Properties.Resources.PTXFieldDictionaryAndMapTableJson;
            FieldData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PTXFieldMappingDataRow>>(json);

        }
    }
}
