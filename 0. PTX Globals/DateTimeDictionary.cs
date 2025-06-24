using System;
using System.Collections.Generic;
using System.Globalization;

namespace PTXClassLibrary
{
    /// <summary>
    /// A static class representing a dictionary of date/time symbols and their names.
    /// </summary>
    public static class DateTimeDictionary
    {
        // Dictionary to store date/time symbols and names
        private static Dictionary<char, string> DateTimeSymbols;

        // List of common date/time formats
        private static List<string> DateTimeFormats = new List<string>
        {
             "yyyy-MM-dd",
    "MM/dd/yyyy",
    "dd/MM/yyyy",
    "yyyyMMdd",
    "MM/dd/yyyy HH:mm:ss",
    "M/d/yyyy HH:mm:ss",
    "yyyy-MM-ddTHH:mm:ss",
    "yyyy-MM-ddTHH:mm:ss.fff",
    "yyyy/MM/dd",
    "yyyy/MM/dd HH:mm:ss",
    "dd-MM-yyyy",
    "dd-MM-yyyy HH:mm:ss",
    "yyyy.MM.dd",
    "yyyy.MM.dd HH:mm:ss",
    "dd/MMM/yyyy",
    "dd/MMM/yyyy HH:mm:ss",
    "MMM dd, yyyy",
    "MMM dd, yyyy HH:mm:ss",
    "yyyy-MM-dd HH:mm:ss zzz",
    "dd-MMM-yyyy HH:mm:ss",
    "dd MMMM yyyy"
            // Add more date/time formats here if needed
        };

        // Static constructor to initialize the dictionary
        static DateTimeDictionary()
        {
            InitialiseDateTimeSymbols();
        }

        /// <summary>
        /// Initializes the DateTimeSymbols dictionary with common date/time symbols and their names.
        /// </summary>
        private static void InitialiseDateTimeSymbols()
        {
            DateTimeSymbols = new Dictionary<char, string>
            {
                { 'y', "Year" },
                { 'M', "Month" },
                { 'd', "Day" },
                { 'H', "Hour (24-hour)" },
                { 'h', "Hour (12-hour)" },
                { 'm', "Minute" },
                { 's', "Second" },
                { 'f', "Fractional seconds" },
                { 't', "AM/PM designator" },
                { 'z', "Time zone offset" }
                // Add other date/time symbols and their names here
            };
        }

        /// <summary>
        /// Checks if a given character is a known date/time symbol.
        /// </summary>
        /// <param name="symbol">The character to check.</param>
        /// <returns>True if the character is a known date/time symbol, false otherwise.</returns>
        public static bool IsDateTimeSymbol(char symbol)
        {
            return DateTimeSymbols.ContainsKey(symbol);
        }

        /// <summary>
        /// Gets the name of a date/time symbol.
        /// </summary>
        /// <param name="symbol">The date/time symbol.</param>
        /// <returns>The name of the date/time symbol or "Unknown" if the symbol is not found.</returns>
        public static string GetDateTimeSymbolName(char symbol)
        {
            return DateTimeSymbols.ContainsKey(symbol) ? DateTimeSymbols[symbol] : "Unknown";
        }

        /// <summary>
        /// Parses a date/time string using the specified format and culture.
        /// </summary>
        /// <param name="value">The date/time string to parse.</param>
        /// <param name="culture">The culture information used for parsing.</param>
        /// <param name="parsedDate">The parsed DateTime value if successful; otherwise, the default DateTime value.</param>
        /// <returns>True if the parsing was successful, otherwise false.</returns>
        public static bool TryParseDateTime(string value, CultureInfo culture, out DateTime parsedDate)
        {
            return DateTime.TryParseExact(value, DateTimeFormats.ToArray(), culture, DateTimeStyles.None, out parsedDate);
        }

        /// <summary>
        /// Tries to parse the input value as a DateTime using various formats.
        /// </summary>
        /// <param name="value">The input value to parse.</param>
        /// <param name="parsedDate">The parsed DateTime value if successful.</param>
        /// <returns>True if the parsing was successful, otherwise false.</returns>
        public static bool TryParseDateTime(string value, out DateTime parsedDate)
        {
            return DateTime.TryParseExact(value, DateTimeFormats.ToArray(), CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
        }


    }
}
