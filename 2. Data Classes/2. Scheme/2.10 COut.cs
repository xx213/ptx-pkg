using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents a Contracting Out with its associated details.
    /// </summary>
    public class COut
    {
        /// <summary>
        /// The GUID of the Contracting Out.
        /// </summary>
        [JsonProperty("guid")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the Contracting Out.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the Contracting Out.
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// The description of the Contracting Out.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Indicates whether there is a Contracting Out cessation date.
        /// </summary>
        [JsonProperty("cessDate")]
        public bool CessDate { get; set; }

        /// <summary>
        /// Specifies whether the GMP revaluation rate used is at Date of Leaving (DOL) or Contracting Out Cessation Date.
        /// Allowed values: DOL or COutCessDate.
        /// </summary>
        [JsonProperty("gmpRevRateUsedAtDate")]
        public string GMPRevRateUsedAtDate { get; set; }

        /// <summary>
        /// Specifies the GMP revaluation rate used between 2016 and Date of Leaving (DOL) if active at 2016.
        /// Allowed values: GMPRevaluation.
        /// </summary>
        [JsonProperty("gmpRevRateUsed2016ToDOL")]
        public string GMPRevRateUsed2016ToDOL { get; set; }

        /// <summary>
        /// Indicates whether the scheme has applied LEA adjustments in practice.
        /// </summary>
        [JsonProperty("leaAdjustments")]
        public bool LEAAdjustments { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="COut"/> class.
        /// </summary>
        public COut()
        {
            GUID = Guid.NewGuid();
            Name = string.Empty;
            ID = string.Empty;
            Description = string.Empty;
            CessDate = false;
            GMPRevRateUsedAtDate = string.Empty;
            GMPRevRateUsed2016ToDOL = string.Empty;
            LEAAdjustments = false;
        }

        /// <summary>
        /// Constructor for the COut class with parameters.
        /// </summary>
        /// <param name="guid">The GUID of the Contracting Out.</param>
        /// <param name="name">The name of the Contracting Out.</param>
        /// <param name="id">The ID of the Contracting Out.</param>
        /// <param name="description">The description of the Contracting Out.</param>
        /// <param name="cessDate">Indicates whether there is a Contracting Out cessation date.</param>
        /// <param name="gmpRevRateUsedAtDate">Specifies whether the GMP revaluation rate used is at Date of Leaving (DOL) or Contracting Out Cessation Date.</param>
        /// <param name="gmpRevRateUsed2016ToDOL">Specifies the GMP revaluation rate used between 2016 and Date of Leaving (DOL) if active at 2016.</param>
        /// <param name="leaAdjustments">Indicates whether the scheme has applied LEA adjustments in practice.</param>
        public COut(Guid guid, string name, string id, string description, bool cessDate,
                    string gmpRevRateUsedAtDate, string gmpRevRateUsed2016ToDOL, bool leaAdjustments)
        {
            GUID = guid;
            Name = name;
            ID = id;
            Description = description;
            CessDate = cessDate;
            GMPRevRateUsedAtDate = gmpRevRateUsedAtDate;
            GMPRevRateUsed2016ToDOL = gmpRevRateUsed2016ToDOL;
            LEAAdjustments = leaAdjustments;
            PTXCalc_ConstructorCalcs();
        }

        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
            // Override this if required
        }
    }
}
