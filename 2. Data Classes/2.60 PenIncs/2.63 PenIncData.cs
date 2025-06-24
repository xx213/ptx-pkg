using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents pension increase data with various properties.
    /// </summary>
    public class PenIncData
    {
        /// <summary>
        /// The GUID of the pension increase data.
        /// </summary>
        [JsonProperty("GUID")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the base data table, such as CPI, RPI, PenIncs.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the pension increase data.
        /// </summary>
        [JsonProperty("ID")]
        public string ID { get; set; }

        /// <summary>
        /// The description of the pension increase data.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// The 2D array of values in the base table, containing IncreaseDate, IncreaseDefinition, and Rate%.
        /// </summary>
        [JsonProperty("Array")]
        public string[,] Values { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PenIncData"/> class.
        /// </summary>
        /// <param name="guid">The GUID of the pension increase data.</param>
        /// <param name="name">The name of the base data table.</param>
        /// <param name="id">The ID of the pension increase data.</param>
        /// <param name="description">The description of the pension increase data.</param>
        /// <param name="values">The 2D array of values in the base table.</param>
        public PenIncData(Guid guid, string name, string id, string description, string[,] values)
        {
            GUID = guid;
            Name = name;
            ID = id;
            Description = description;
            Values = values;
        }
    }
}
