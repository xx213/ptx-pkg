using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents the Later Earnings Addition (LEA) with its associated details.
    /// </summary>
    public class LEA
    {
        /// <summary>
        /// The GUID of the LEA.
        /// </summary>
        [JsonProperty("GUID")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the LEA.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the LEA.
        /// </summary>
        [JsonProperty("ID")]
        public string ID { get; set; }

        /// <summary>
        /// The description of the LEA.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Indicates whether the scheme has applied LEA adjustments in practice.
        /// </summary>
        [JsonProperty("Adjustments")]
        public string HasAdjustments { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LEA"/> class.
        /// </summary>
        public LEA()
        {
            // Default constructor
            GUID = Guid.NewGuid();
            Name = string.Empty;
            ID = "";
            Description = string.Empty;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LEA"/> class.
        /// </summary>
        /// <param name="guid">The GUID of the LEA.</param>
        /// <param name="name">The name of the LEA.</param>
        /// <param name="id">The ID of the LEA.</param>
        /// <param name="description">The description of the LEA.</param>
        /// <param name="hasAdjustments">Indicates whether the scheme has applied LEA adjustments in practice.</param>
        public LEA(Guid guid, string name, string id, string description, string hasAdjustments)
        {
            GUID = guid;
            Name = name;
            ID = id;
            Description = description;
            HasAdjustments = hasAdjustments;
            PTXCalc_ConstructorCalcs();
        }

        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
            // Override this if required
        }
    }
}
