using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Text;

namespace PTXClassLibrary
{
    public static class HtmlGenerator
    {
        /// <summary>
        /// Generates HTML markup from the properties of an object.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="obj">The object whose properties will be used to generate HTML.</param>
        /// <returns>HTML markup representing the object's properties.</returns>
        public static string GenerateHtml<T>(T obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            StringBuilder htmlBuilder = new StringBuilder("<div>");

            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                if (property.GetIndexParameters().Length == 0) // Check if the property is not an indexer
                {
                    object value = property.GetValue(obj);

                    if (value != null)
                    {
                        string valueAsString = value.ToString(); // Convert value to string
                        htmlBuilder.AppendLine($"<p><strong>{property.Name}:</strong> {valueAsString}</p>");
                    }
                }
            }

            htmlBuilder.AppendLine("</div>");

            return htmlBuilder.ToString();
        }

        /// <summary>
        /// Generates HTML markup from a JSON string.
        /// </summary>
        /// <param name="jsonString">The JSON string to be converted to HTML.</param>
        /// <returns>HTML markup representing the JSON data.</returns>
        public static string GenerateJsonHtml(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
            {
                return string.Empty;
            }

            StringBuilder htmlBuilder = new StringBuilder("<div>");

            try
            {
                // Parse the JSON string into a dynamic object
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonString);

                foreach (var property in jsonObject.GetType().GetProperties())
                {
                    var value = property.GetValue(jsonObject);

                    if (value != null)
                    {
                        htmlBuilder.AppendLine($"<p><strong>{property.Name}:</strong> {value}</p>");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle JSON parsing exception
                htmlBuilder.AppendLine($"<p><strong>Error:</strong> {ex.Message}</p>");
            }

            htmlBuilder.AppendLine("</div>");

            return htmlBuilder.ToString();
        }



    }
}
