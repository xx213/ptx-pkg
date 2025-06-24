using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents the Salary Link with its associated details.
    /// </summary>
    public class SalLink
    {
        /// <summary>
        /// The GUID of the Salary Link.
        /// </summary>
        [JsonProperty("GUID")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the Salary Link.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the Salary Link.
        /// </summary>
        [JsonProperty("ID")]
        public string ID { get; set; }

        /// <summary>
        /// The description of the Salary Link.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// The date when the salary link was broken for this category.
        /// </summary>
        [JsonProperty("SalLinkEndDate")]
        public DateTime SalaryLinkEndDate { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalLink"/> class.
        /// </summary>
        public SalLink()
        {
            // Default constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalLink"/> class.
        /// </summary>
        /// <param name="guid">The GUID of the Salary Link.</param>
        /// <param name="name">The name of the Salary Link.</param>
        /// <param name="id">The ID of the Salary Link.</param>
        /// <param name="description">The description of the Salary Link.</param>
        /// <param name="salLinkEndDate">The date when the salary link was broken.</param>
        public SalLink(Guid guid, string name, string id, string description, DateTime salLinkEndDate)
        {
            GUID = guid;
            Name = name;
            ID = id;
            Description = description;
            SalaryLinkEndDate = salLinkEndDate;
            PTXCalc_ConstructorCalcs();
        }

        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
            // Override this if required
        }
    }
}
