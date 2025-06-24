using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    public class ERFx
    {
        /// <summary>
        /// The GUID of the ERF Model/Data data.
        /// </summary>
        [JsonProperty("guid")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the ERF Model/Data data.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the ERF Model/Data data..
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// The description the ERF Model/Data data.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Default constructor for the ERFx class.
        /// </summary>
        public ERFx()
        {
            // Initialize any default values here
        }

        /// <summary>
        /// Constructor for the ERFx class with parameters.
        /// </summary>
        /// <param name="guid">The GUID of the ERF Model/Data data.</param>
        /// <param name="name">The name of the ERF Model/Data data.</param>
        /// <param name="id">The ID of the ERF Model/Data data.</param>
        /// <param name="description">The description of the ERF Model/Data data.</param>
        public ERFx(Guid guid, string name, string id, string description)
        {
            GUID = guid;
            Name = name;
            ID = id;
            Description = description;
            PTXCalc_ConstructorCalcs();
        }

        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
            // Override this if required
        }
    }
}
