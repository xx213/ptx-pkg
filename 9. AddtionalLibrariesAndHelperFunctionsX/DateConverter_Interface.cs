using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Globalization;

namespace PTXClassLibrary
{
    public static class DateConverter_Interface
    {
        public static DateTime ConvertToDate(string inputDate)
        {
            // Check if the input date is in US or UK format
            bool isUSFormat = IsUSDateFormat(inputDate);

            // Define date formats based on whether it's US or UK format
            string[] dateFormats = isUSFormat
                ? new[] {
                    "MM/dd/yyyy",
                    "M/d/yy",
                    "MM-MMM-yy",
                    "MM MMM yy" }

                : new[] { "dd/MM/yyyy",
        "d/M/y",
        "dd-MMM-yy",
        "dd MMM yy",
        "ddmmyy",
        "ddmmmyy",
        "ddmmmyyyyy",
        "ddmmyyyyy",
        "dd MMM yy" };

            DateTime parsedDate;

            if (DateTime.TryParseExact(inputDate, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return parsedDate;
            }

            // Handle other cases or throw an exception if the date format is not supported
            throw new ArgumentException($"Unsupported date format: {inputDate}");
        }

        private static bool IsUSDateFormat(string inputDate)
        {
            // To determine the date format, check if the first numeric value is greater than 12
            // If it is, assume it's in the US format (mmddyyyy)
            if (int.TryParse(inputDate, out int firstNumericValue))
            {
                return firstNumericValue > 12;
            }

            // Default to US format if the check cannot be performed
            return true;
        }
    }

    #region JSON properties
    public class DateConversionSettings
    {
        /// <summary>
        /// Gets or sets the input date.
        /// </summary>
        [JsonProperty("inputDate")]
        [Description("The input date.")]
        public string InputDate { get; set; }

        /// <summary>
        /// Gets or sets the converted date.
        /// </summary>
        [JsonProperty("convertedDate")]
        [Description("The converted date.")]
        public DateTime ConvertedDate { get; set; }
    }
    #endregion
}
