using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents the Franking Model for a Category.
    /// </summary>
    public class Franking
    {
        /// <summary>
        /// The GUID of the Franking Model.
        /// </summary>
        [JsonProperty("GUID")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the Franking Model.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the Franking Model.
        /// </summary>
        [JsonProperty("ID")]
        public string ID { get; set; }

        /// <summary>
        /// The description of the Franking Model.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// The Early Retirements option for the Franking Model.
        /// </summary>
        [JsonProperty("EROption")]
        public string EarlyRetirementsOption { get; set; }

        /// <summary>
        /// The Normal Retirements option for the Franking Model.
        /// </summary>
        [JsonProperty("NROption")]
        public string NormalRetirementsOption { get; set; }

        /// <summary>
        /// The Late Retirements option for the Franking Model.
        /// </summary>
        [JsonProperty("LROption")]
        public string LateRetirementsOption { get; set; }

        /// <summary>
        /// The Normal Retirement Age(s) for the Franking Model.
        /// </summary>
        [JsonProperty("NRA")]
        public int NormalRetirementAge { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Franking"/> class.
        /// </summary>
        public Franking()
        {
            GUID = Guid.NewGuid();
            Name = string.Empty;
            ID = string.Empty;
            Description = string.Empty;
            EarlyRetirementsOption = string.Empty;
            NormalRetirementsOption = string.Empty;
            LateRetirementsOption = string.Empty;
            NormalRetirementAge = 0;
        }

        /// <summary>
        /// Constructor for the Franking class with parameters.
        /// </summary>
        /// <param name="guid">The GUID of the Franking Model.</param>
        /// <param name="name">The name of the Franking Model.</param>
        /// <param name="id">The ID of the Franking Model.</param>
        /// <param name="description">The description of the Franking Model.</param>
        /// <param name="erOption">The Early Retirements option.</param>
        /// <param name="nrOption">The Normal Retirements option.</param>
        /// <param name="lrOption">The Late Retirements option.</param>
        /// <param name="nra">The Normal Retirement Age(s).</param>
        public Franking(Guid guid, string name, string id, string description, string erOption, string nrOption, string lrOption, int nra)
        {
            GUID = guid;
            Name = name;
            ID = id;
            Description = description;
            EarlyRetirementsOption = erOption;
            NormalRetirementsOption = nrOption;
            LateRetirementsOption = lrOption;
            NormalRetirementAge = nra;
        }
    }
}
