using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents an Additional Lump Sum with its associated details.
    /// </summary>
    public class LumpSum
    {
        /// <summary>
        /// The GUID of the Lump Sum.
        /// </summary>
        [JsonProperty("GUID")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the Lump Sum.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the Lump Sum.
        /// </summary>
        [JsonProperty("ID")]
        public string ID { get; set; }

        /// <summary>
        /// The description of the Lump Sum.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Indicates whether the PCLS (Pension Commencement Lump Sum) is paid in addition to the pension.
        /// </summary>
        [JsonProperty("PCSLPaidInAddnyn")]
        public string PclsPaidInAdditionToPension { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LumpSum"/> class.
        /// </summary>
        public LumpSum()
        {
            GUID = Guid.NewGuid();
            Name = string.Empty;
            ID = "";
            Description = string.Empty;
            PclsPaidInAdditionToPension = string.Empty;

            // Additional code in default constructor
            // You can add more initialization logic here if needed
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LumpSum"/> class.
        /// </summary>
        /// <param name="guid">The GUID of the Lump Sum.</param>
        /// <param name="name">The name of the Lump Sum.</param>
        /// <param name="id">The ID of the Lump Sum.</param>
        /// <param name="description">The description of the Lump Sum.</param>
        /// <param name="pclsPaidInAdditionToPension">Indicates whether the PCLS is paid in addition to the pension.</param>
        public LumpSum(Guid guid, string name, string id, string description, string pclsPaidInAdditionToPension)
        {
            GUID = guid;
            Name = name;
            ID = id;
            Description = description;
            PclsPaidInAdditionToPension = pclsPaidInAdditionToPension;
            PTXCalc_ConstructorCalcs();
        }

        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
        }
    }
}
