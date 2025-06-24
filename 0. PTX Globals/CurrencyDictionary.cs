using System.Collections.Generic;

namespace PTXClassLibrary
{
    /// <summary>
    /// A static class representing a dictionary of currency symbols and their names.
    /// </summary>
    public static class CurrencyDictionary
    {
        // Dictionary to store currency symbols and names
        private static Dictionary<char, string> CurrencySymbols;

        // Static constructor to initialize the dictionary
        static CurrencyDictionary()
        {
            InitialiseCurrencySymbols();
        }

        /// <summary>
        /// Initializes the CurrencySymbols dictionary with common currency symbols and their names.
        /// </summary>
        private static void InitialiseCurrencySymbols()
        {
            CurrencySymbols = new Dictionary<char, string>
            {
                { '€', "Euro" },
                { '¥', "Yen" },
                { '£', "Pound Sterling" },
                { '$', "Dollar" },
                { '₣', "Swiss Franc" },
                { '₤', "Lira" },
                { '₱', "Peso" },
                { '₦', "Naira" },
                { '฿', "Baht" },
                { '₩', "Won" },
                { '₪', "New Shekel" },
                { '₫', "Dong" },
                { '₭', "Kip" },
                { '₮', "Tugrik" },
                { '₸', "Tenge" },
                { '₽', "Ruble" },
                { '₾', "Lari" },
                { '元', "Yuan" },
                { '₴', "Hryvnia" },
                { '₹', "Rupee" }
                // Add other currency symbols and their names here
            };
        }

        /// <summary>
        /// Checks if a given character is a known currency symbol.
        /// </summary>
        /// <param name="symbol">The character to check.</param>
        /// <returns>True if the character is a known currency symbol, false otherwise.</returns>
        public static bool IsCurrencySymbol(char symbol)
        {
            return CurrencySymbols.ContainsKey(symbol);
        }

        /// <summary>
        /// Gets the name of a currency based on its symbol.
        /// </summary>
        /// <param name="symbol">The currency symbol.</param>
        /// <returns>The name of the currency or "Unknown" if the symbol is not found.</returns>
        public static string GetCurrencyName(char symbol)
        {
            return CurrencySymbols.ContainsKey(symbol) ? CurrencySymbols[symbol] : "Unknown";
        }
    }
}
