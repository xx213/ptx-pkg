using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;

namespace PTXClassLibrary
{
    public class DataStreamUtility
    {
        [JsonPropertyName("CsvRow")]
        [Description("Gets or sets the CSV row.")]
        public string[] CsvRow { get; set; }

        /// <summary>
        /// Parses the data stream into a CSV list.
        /// </summary>
        /// <param name="dataStream">The input data stream to parse.</param>
        /// <param name="dataCollection">The output CSV list.</param>
        public void ParseDataStreamIntoCSVList(string dataStream, out List<string[]> dataCollection)
        {
            dataCollection = new List<string[]>(); // Initialize the list

            if (dataStream == null)
            {
                Console.WriteLine("Error: Input dataStream is null.");
                return;
            }

            char delimiter = dataStream.Contains('\t') ? '\t' : ',';
            var lines = dataStream.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            var headers = lines.FirstOrDefault()?.Split(delimiter);

            dataCollection.Add(headers);

            var dataRows = lines.Skip(1).Select(line => line.Split(delimiter));
            foreach (var dataRow in dataRows)
            {
                dataCollection.Add(dataRow);
            }
        }

        /// <summary>
        /// Creates a CSV string from the input data stream.
        /// </summary>
        /// <param name="dataStream">The input data stream.</param>
        /// <returns>A CSV string representing the data.</returns>
        public string CreateCSVFromDataStream(string dataStream)
        {
            if (dataStream == null)
            {
                Console.WriteLine("Error: Input dataStream is null.");
                return string.Empty;
            }

            var csvLines = new List<string>();

            char delimiter = dataStream.Contains('\t') ? '\t' : ',';
            var lines = dataStream.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            var headers = lines.FirstOrDefault()?.Split(delimiter);
            csvLines.Add(string.Join(",", headers));

            var dataRows = lines.Skip(1).Select(line => line.Split(delimiter));

            foreach (var dataRow in dataRows)
            {
                var rowValues = dataRow.Select(value => value);
                csvLines.Add(string.Join(",", rowValues));
            }

            return string.Join(Environment.NewLine, csvLines);
        }


        [Description("Parses the data stream into header and data rows.")]
        public void ParseDataStream(string dataStream, out string[] headerRow, out IEnumerable<string[]> dataRows)
        {
            char delimiter = dataStream.Contains('\t') ? '\t' : ',';

            var lines = dataStream.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            headerRow = lines.FirstOrDefault()?.Split(delimiter);
            dataRows = lines.Skip(1).Select(line => line.Split(delimiter));
        }


        [JsonPropertyName("headerRow")]
        [Description("The collection of field names parsed from the input data stream.")]
        private string[] FieldNames { get; set; }

        [JsonPropertyName("dataRows")]
        [Description("The collection of data rows parsed from the input data stream.")]
        private IEnumerable<string[]> DataRows { get; set; }


        [Description("Processes the input data stream and builds a collection of dictionaries.")]
        public List<Dictionary<string, string>> ProcessDataStreamListDict(string dataStream)
        {
            char delimiter = dataStream.Contains('\t') ? '\t' : ',';

            var lines = dataStream.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            var headers = lines.FirstOrDefault()?.Split(delimiter);
            var dataRows = lines.Skip(1).Select(line => line.Split(delimiter));

            var dataCollectionList = new List<Dictionary<string, string>>();

            foreach (var dataRow in dataRows)
            {
                var dictRow = new Dictionary<string, string>();

                for (int i = 0; i < headers.Length; i++)
                {
                    var value = dataRow.Length > i ? dataRow[i] : string.Empty;
                    dictRow[headers[i]] = value;
                }

                dataCollectionList.Add(dictRow);
            }

            return dataCollectionList;
        }

        [Description("Processes the input data stream and builds a limited collection.")]
        public List<string[]> ProcessDataStreamListLimted(string dataStream)
        {
            char delimiter = dataStream.Contains('\t') ? '\t' : ',';

            var lines = dataStream.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            var headers = lines.FirstOrDefault()?.Split(delimiter);
            var dataRows = lines.Skip(1).Select(line => line.Split(delimiter));

            var dataCollectionList = new List<string[]>();

            dataCollectionList.Add(headers);

            foreach (var dataRow in dataRows)
            {
                dataCollectionList.Add(dataRow);
            }

            return dataCollectionList;
        }

        [Description("Processes the marked-up input data stream and builds a collection of arrays.")]
        public List<T[]> ProcessDataMarkedUpToList<T>(string DataMarkedUp)
        {
            var dataCollectionList = new List<T[]>();

            string delimiter = DataMarkedUp.Contains("[delimComma]") ? "[delimComma]" : "[delimTab]";
            delimiter = "[delim]";

            var lines = DataMarkedUp.Split(new[] { "[Eol]" }, StringSplitOptions.RemoveEmptyEntries);
            var headers = lines.FirstOrDefault()?.Split(new[] { delimiter }, StringSplitOptions.None);
            var dataRows = lines.Skip(1).Select(line => line.Split(new[] { delimiter }, StringSplitOptions.None));

            dataCollectionList.Add(ConvertArray<T>(headers));

            foreach (var dataRow in dataRows)
            {
                dataCollectionList.Add(ConvertArray<T>(dataRow));
            }

            var replacementStrings = new List<string> { "[StQTE]", "[EndQTE]", "[QTE]" };

            for (int i = 0; i < dataCollectionList.Count; i++)
            {
                for (int j = 0; j < replacementStrings.Count; j++)
                {
                    dataCollectionList[i] = dataCollectionList[i].Select(s =>
                        (T)Convert.ChangeType(s?.ToString()?.Replace("\"", string.Empty), typeof(T))).ToArray();
                }
            }

            return dataCollectionList;
        }

        private T[] ConvertArray<T>(string[] inputArray)
        {
            return inputArray.Select(s => (T)Convert.ChangeType(s, typeof(T))).ToArray();
        }

        [Description("Converts the processed collection to CSV format.")]
        public string ConvertListDictToCsv(List<Dictionary<string, string>> dataCollectionListDict)
        {
            if (dataCollectionListDict == null || !dataCollectionListDict.Any())
            {
                return string.Empty;
            }

            var csvLines = new List<string>();
            var headers = dataCollectionListDict.First().Keys.ToArray();

            csvLines.Add(string.Join(",", headers.Select(header => $"\"{header}\"")));

            csvLines.AddRange(dataCollectionListDict.Select(dict =>
                string.Join(",", headers.Select(header => $"\"{(dict.TryGetValue(header, out var value) ? value : "")}\""))));

            return string.Join(Environment.NewLine, csvLines);
        }

        [Description("Converts the processed collection to CSV format.")]
        public string ConvertListArrayToCsv(List<string[]> dataCollectionList)
        {
            if (dataCollectionList == null || !dataCollectionList.Any())
            {
                return string.Empty;
            }

            var csvLines = new List<string>();
            var headers = dataCollectionList.First();

            csvLines.Add(string.Join(",", headers.Select(header => $"{header}")));

            csvLines.AddRange(dataCollectionList.Skip(1).Select(row => string.Join(",", row.Select(value => $"{value}"))));

            return string.Join(Environment.NewLine, csvLines);
        }
    }
}
