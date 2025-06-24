
//using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents the base class for PTX field mapping.
    /// </summary>
    public class FieldTypesUtility
    {
        /// <summary>
        /// Determines the field type based on the provided value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>A tuple containing the type name and the corresponding System.ErrMessage.</returns>
        public static bool IsNullOrEmptyOrWhiteSpace(string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }
        
        
        public (string typeName, Type type) DetermineFieldTypeFromValue(string value)
        {
            if (Guid.TryParse(value, out _))
            {
                return ("guid", typeof(Guid));
            }
            else if (double.TryParse(value, out _))
            {
                return ("double", typeof(double));
            }
            else if (int.TryParse(value, out _))
            {
                return ("int", typeof(int));
            }
            else if (long.TryParse(value, out _))
            {
                return ("long", typeof(long));
            }
            else if (decimal.TryParse(value, out _))
            {
                return ("decimal", typeof(decimal));
            }
            else if (DateTime.TryParse(value, out _))
            {
                return ("date", typeof(DateTime));
            }

            // Check if the value represents a date
            DateTime parsedDate;
            if (DateTimeDictionary.TryParseDateTime(value, out parsedDate))
            {
                return ("date", typeof(DateTime));
            }

            else if (bool.TryParse(value, out _))
            {
                return ("bool", typeof(bool));
            }
            else
            {
                return ("string", typeof(string));
            }
        }


        /// <summary>
        /// Gets the System.ErrMessage from the type name.
        /// </summary>
        /// <param name="typeName">The type name as a string, simplified list.</param>
        /// <returns>The System.ErrMessage corresponding to the type name.</returns>
        public static Type GetTypeFromString(string typeName)
        {
            // Switch statement to map type names to System.Types
            switch (typeName.ToLower())
            {
                case "null":
                    return null;
                case "guid":
                    return typeof(Guid);
                case "double":
                    return typeof(double);
                case "int":
                    return typeof(int);
                case "long":
                    return typeof(long);
                case "decimal":
                    return typeof(decimal);
                case "date":
                    return typeof(DateTime);
                case "datetime": // Added support for "datetime"
                    return typeof(DateTime);
                case "bool":
                    return typeof(bool);
                case "string":
                    return typeof(string);
                default:
                    // Handle unknown type or throw an exception
                    return typeof(object);
            }
        }


        /// <summary>
        /// Gets the System.ErrMessage from the type name.
        /// </summary>
        /// <param name="ptxDataTypeName">The type name as a string, simplified list.</param>
        /// <returns>The System.ErrMessage corresponding to the type name.</returns>
        private static string GetStringTypeFromString(string ptxDataTypeName)
        {
            //allowable types from PTXDataTypes : EXCEL SHET and JSON Import
            //            memTitle
            //bool
            //MonthsMMM
            //Months##
            //MonthsMMMM
            //double
            //string
            //date
            //datetime
            //int
            //ListYNYesNo
            //ListYN
            //ListYNYesNo


                // Switch statement to map type names to System.Types
            switch (ptxDataTypeName.ToLower())
            {
                case "string":
                    return typeof(string).ToString(); ;
                case "null":
                    return null;
                case "guid":
                    return typeof(Guid).ToString(); ;
                case "double":
                    return typeof(double).ToString(); ;
                case "int":
                    return typeof(int).ToString(); ;
                case "long":
                    return typeof(long).ToString();
                case "decimal":
                    return typeof(decimal).ToString(); ;
                case "date":
                    return typeof(DateTime).ToString(); ;
                case "datetime": // Added support for "datetime"
                    return typeof(DateTime).ToString(); ;
                case "bool":
                    return typeof(bool).ToString(); ;
                case "MonthsMMMM":
                    return typeof(string).ToString(); ;
                case "MonthsMMM":
                    return typeof(string).ToString(); ;
                case "Months##":
                    return typeof(int).ToString(); ;
                case "ListYNYesNo":
                    return typeof(string).ToString(); ;
                case "ListYN":
                    return typeof(string).ToString(); ;
                case "ListYNYesNoNA":
                    return typeof(string).ToString(); ;

                default:
                    // Handle unknown type or throw an exception
                    return typeof(object).ToString(); ;
            }
        }

        internal static (object retValue, bool bCastSuccessful) TryToCastValue(string inValueToCheck, string ptxDataTypeName)
        {
            object retValue = null;
            bool bCastSuccessful = false;

            string ptxDataTypeStringName = GetStringTypeFromString(ptxDataTypeName);

            try
            {
                switch (ptxDataTypeStringName)
                {
                    case "System.Boolean":
                        retValue = Convert.ToBoolean(inValueToCheck, CultureInfo.InvariantCulture);
                        break;

                    case "System.Byte":
                        retValue = Convert.ToByte(inValueToCheck, CultureInfo.InvariantCulture);
                        break;

                    case "System.SByte":
                        retValue = Convert.ToSByte(inValueToCheck, CultureInfo.InvariantCulture);
                        break;

                    case "System.Char":
                        retValue = Convert.ToChar(inValueToCheck, CultureInfo.InvariantCulture);
                        break;

                    case "System.Decimal":
                        retValue = Convert.ToDecimal(inValueToCheck, CultureInfo.InvariantCulture);
                        break;

                    case "System.Double":
                        retValue = Convert.ToDouble(inValueToCheck, CultureInfo.InvariantCulture);
                        break;

                    case "System.Single":
                        retValue = Convert.ToSingle(inValueToCheck, CultureInfo.InvariantCulture);
                        break;

                    case "System.Int32":
                        retValue = Convert.ToInt32(inValueToCheck, CultureInfo.InvariantCulture);
                        break;

                    case "System.UInt32":
                        retValue = Convert.ToUInt32(inValueToCheck, CultureInfo.InvariantCulture);
                        break;

                    case "System.Int64":
                        retValue = Convert.ToInt64(inValueToCheck, CultureInfo.InvariantCulture);
                        break;

                    case "System.UInt64":
                        retValue = Convert.ToUInt64(inValueToCheck, CultureInfo.InvariantCulture);
                        break;

                    case "System.Int16":
                        retValue = Convert.ToInt16(inValueToCheck, CultureInfo.InvariantCulture);
                        break;

                    case "System.UInt16":
                        retValue = Convert.ToUInt16(inValueToCheck, CultureInfo.InvariantCulture);
                        break;

                    case "System.String":
                        retValue = inValueToCheck;
                        break;
                    case "System.Object":
                        retValue = inValueToCheck;
                        break;

                    //case "System.DateTime":
                    //    DateTime parsedDate;
                    //    if (DateTimeDictionary.TryParseDateTime(inValueToCheck, out parsedDate))
                    //    {
                    //        retValue = parsedDate;

                    //    }
                    //    break;

                    case "System.DateTime":
                        DateTime parsedDate;
                        if (DateTimeDictionary.TryParseDateTime(inValueToCheck, out parsedDate))
                        {
                            retValue = parsedDate;
                        }
                        else if (double.TryParse(inValueToCheck, out double excelDate))
                        {
                            // Check if the parsed double is within the valid range for Excel date serials
                            if (excelDate >= 1 && excelDate < 2958466)
                            {
                                // Convert the Excel date serial to a DateTime
                                retValue = DateTime.FromOADate(excelDate);
                            }
                            else
                            {
                                // Handle parsing failure
                                // Assign the input value back to retValue
                                retValue = inValueToCheck;
                            }
                        }
                        else if (inValueToCheck is string)
                        {
                            // Attempt to convert the string to a double
                            if (double.TryParse(inValueToCheck, out double stringValue))
                            {
                                // String was successfully converted to a double
                                retValue = stringValue;
                            }
                            else
                            {
                                // Handle parsing failure
                                // Assign the input value back to retValue
                                retValue = inValueToCheck;
                            }
                        }
                        break;








                    case "System.Collections.Generic.List<dynamic>":
                        dynamic list = JsonConvert.DeserializeObject<List<dynamic>>(inValueToCheck);
                        retValue = list;
                        break;

                    default:
                        if (ptxDataTypeStringName.StartsWith("System.Collections.Generic.List<") && ptxDataTypeStringName.EndsWith(">"))
                        {
                            string innerType = ptxDataTypeStringName.Substring("System.Collections.Generic.List<".Length, ptxDataTypeStringName.Length - "System.Collections.Generic.List<".Length - 1);
                            Type listType = GetTypeFromString(innerType);
                            dynamic listX = JsonConvert.DeserializeObject(inValueToCheck, listType);
                            retValue = listX;
                        }
                        break;
                }

                bCastSuccessful = retValue != null;
            }
            catch (Exception)
            {
                // Handle exceptions if the conversion fails
                bCastSuccessful = false;
                    retValue = inValueToCheck;
            }

            return (retValue, bCastSuccessful);
        }


        ///// <summary>
        ///// Tries to parse the input value as a date using various formats.
        ///// </summary>
        ///// <param name="value">The input value.</param>
        ///// <param name="formats">Array of date formats to try.</param>
        ///// <returns>The parsed DateTime value if successful; otherwise, null.</returns>
        //private bool TryParseDate(string value, string[] formats, out DateTime parsedDate)
        //{
        //    foreach (string format in formats)
        //    {
        //        if (DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
        //        {
        //            return true;
        //        }
        //    }
        //    parsedDate = default; // Set default value if parsing fails
        //    return false;
        //}


        #region JSON properties

        /// <summary>
        /// Gets or sets the type name.
        /// </summary>
        [JsonProperty("ptxDataTypeStringName")]
        [Description("The type name.")]
        public string TypeName { get; set; }

        /// <summary>
        /// Gets or sets the System.ErrMessage.
        /// </summary>
        [JsonProperty("type")]
        [Description("The System.ErrMessage.")]
        public Type Type { get; set; }

        #endregion JSON properties
    }

    //    List<string> typeNames = new List<string>
    //{
    //    "System.Boolean",
    //    "System.Byte",
    //    "System.SByte",
    //    "System.Char",
    //    "System.Decimal",
    //    "System.Double",
    //    "System.Single",
    //    "System.Int32",
    //    "System.UInt32",
    //    "System.Int64",
    //    "System.UInt64",
    //    "System.Int16",
    //    "System.UInt16",
    //    "System.String",
    //    "System.Object",
    //    // Add more types as needed
    //};
}
