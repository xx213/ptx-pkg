using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents the Underpin with its associated details.
    /// </summary>
    public class Underpin
    {
        /// <summary>
        /// The GUID of the Underpin.
        /// </summary>
        [JsonProperty("GUID")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the Underpin.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the Underpin.
        /// </summary>
        [JsonProperty("ID")]
        public string ID { get; set; }

        /// <summary>
        /// The description of the Underpin.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// The revaluation rate of the Underpin.
        /// </summary>
        [JsonProperty("RevRate")]
        public string RevaluationRate { get; set; }

        /// <summary>
        /// The pension increase underpin, such as Total Pen 3% PA, where the Pre 97 becomes a balancing item.
        /// </summary>
        [JsonProperty("TBC")]
        public string PensionIncreaseUnderpin { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Underpin"/> class.
        /// </summary>
        public Underpin()
        {
            // Default constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Underpin"/> class.
        /// </summary>
        /// <param name="guid">The GUID of the Underpin.</param>
        /// <param name="name">The name of the Underpin.</param>
        /// <param name="id">The ID of the Underpin.</param>
        /// <param name="description">The description of the Underpin.</param>
        /// <param name="revRate">The revaluation rate of the Underpin.</param>
        /// <param name="tbc">The pension increase underpin.</param>
        public Underpin(Guid guid, string name, string id, string description, string revRate, string tbc)
        {
            GUID = guid;
            Name = name;
            ID = id;
            Description = description;
            RevaluationRate = revRate;
            PensionIncreaseUnderpin = tbc;
            PTXCalc_ConstructorCalcs();
        }

        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
            // Override this if required
        }
    }
}
