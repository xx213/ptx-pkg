using CsvHelper;
using CsvHelper.Configuration;
//using CsvHelper.Configuration;
using FuzzySharp;
using PTXClassLibrary; // Import the PTXClassLibrary namespace
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PTXClassLibrary
{
    public class MatchFuzzy_FieldName
    {
        private FieldNameData fieldNameData; // Add a field to hold the field descriptions
        private List<FieldDataRow> fieldNameDataList = new List<FieldDataRow>();

        public MatchFuzzy_FieldName(List<FieldDataRow> fieldNameDataList)
        {
            this.fieldNameDataList = fieldNameDataList;
        }
        
        
        public MatchFuzzy_FieldName()
        {
            // Load field descriptions from the CSV file
            //fieldNameData = new FieldNameData("DD1.csv");
            fieldNameData = new FieldNameData();
            //fieldNameData = new FieldNameData(Resources.
            //
            //.);
            //Resources.FieldNames_Member
            //StrTableRef = "LTA";
            //string csvContent = Resources.FieldNames_Member.ToString();
            //{ CSVData = Resources.MyCSPTables_Ret.ToString(); }
            string ss = "dd";
            // Get the CSV file content from resources
            //string csvContent = GetResourceFileContent("PTXCalc.Resources.FieldNames_Member"); // Replace "YourResourceName" with your resource name

            ///This is the provblem  FFS
            ///
            //fieldNameDataList = ReadDataFromCSVResource(csvContent);
            //fieldNameData = fieldNameDataList;

            //fieldNameData = new FieldNameData();


        }



        //Function to match againts array
        public (string bestMatch, string value) FindBestMatch(string inputFieldName)
        {
            if (string.IsNullOrWhiteSpace(inputFieldName))
            {
                throw new ArgumentException("Input field name is empty or null.");
            }

            var bestMatch = string.Empty;
            var bestScore = 0;

            foreach (var fieldDescription in fieldNameData.FieldData)
            {
                var score = Fuzz.PartialRatio(fieldDescription.FieldName, inputFieldName);
                if (score > bestScore)
                {
                    bestMatch = fieldDescription.FieldName;
                    bestScore = score;
                }
            }

            // Retrieve the corresponding value from the field description
            var description = fieldNameData.FieldData.Find(fd => fd.FieldName == bestMatch);

            if (description != null)
            {
                return (bestMatch, description.Description);
            }

            return (bestMatch, string.Empty); // No matching value found
        }

        //Intenal funitons

        public string GetResourceFileContent(string resourceName)
        {
            // Use reflection to access the resource stream
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null)
                {
                    throw new InvalidOperationException("Resource not found.");
                }

                using (StreamReader reader = new StreamReader(resourceStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }



        public List<FieldDataRow> ReadDataFromCSVResource(string csvContent)
        {
            List<FieldDataRow> data = new List<FieldDataRow>();

            var reader = new StringReader(csvContent);
            CsvReader csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));

            data = csv.GetRecords<FieldDataRow>().ToList();


            return data;
        }



    }
}
