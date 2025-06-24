using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PTXClassLibrary
{
    public class FieldDataRow
    {
        public string FieldName { get; set; }
        public string DataType { get; set; }
        public string Description { get; set; }
        public List<string> KnownNames { get; set; }
    }

    public class FieldNameData
    {
        public List<FieldDataRow> FieldData { get; set; }
    }

    /*public class FieldNameData
    {
        public List<FieldDataRow> FieldData;

        public FieldNameData(string csvFilePath)
        {
            
            FieldData = ReadDataFromCSVPath(csvFilePath);
        }

        public FieldNameData()
        {
            // Default constructor without parameters.
            // You can add initialization logic here if needed.
            FieldData = new List<FieldDataRow>();
        }
    */






    /*private List<FieldDataRow> ReadDataFromCSVPath(string csvFilePath)
        {
            List<FieldDataRow> data = new List<FieldDataRow>();

            var reader = new StreamReader(csvFilePath);
            var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            
               data = csv.GetRecords<FieldDataRow>().ToList();
        

            return data;
        }

        public static implicit operator FieldNameData(List<FieldDataRow> v)
        {
            throw new NotImplementedException();
        }
    }*/
}
