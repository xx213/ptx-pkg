using Newtonsoft.Json;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents death-related information for a category.
    /// </summary>
    public class Death
    {
        /// <summary>
        /// The name of the death category.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the death category.
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// The description of the death category.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The Spouse Death After Retirement (DAR) proportion.
        /// Allowed range: 0 to 2.
        /// </summary>
        [JsonProperty("DAR.SpsProp")]
        public double DARSpouseProportion { get; set; }

        /// <summary>
        /// The guarantee period post-retirement in years.
        /// Allowed range: 0 to 10.
        /// </summary>
        [JsonProperty("guaranteePeriod")]
        public int GuaranteePeriod { get; set; }

        /// <summary>
        /// The Spouse Death in Deferment (DID) proportion.
        /// Allowed range: 0 to 2.
        /// </summary>
        [JsonProperty("DID.SpsProp")]
        public double DIDSpouseProportion { get; set; }

        /// <summary>
        /// The lump sum payment for Death in Deferment (DID).
        /// Allowed range: 0 to 25.
        /// </summary>
        [JsonProperty("DID.LS")]
        public double DIDLumpSum { get; set; }

        /// <summary>
        /// The Spouse Death in Service (DIS) proportion.
        /// Allowed range: 0 to 2.
        /// </summary>
        [JsonProperty("DIS.SpsProp")]
        public double DISSpouseProportion { get; set; }

        /// <summary>
        /// The lump sum payment for Death in Service (DIS).
        /// Allowed range: 0 to 25.
        /// </summary>
        [JsonProperty("DIS.LS")]
        public double DISLumpSum { get; set; }

        /// <summary>
        /// Default constructor for the Death class.
        /// </summary>
        public Death()
        {
            Name = string.Empty;
            ID = string.Empty;
            Description = string.Empty;
            DARSpouseProportion = 0.0;
            GuaranteePeriod = 0;
            DIDSpouseProportion = 0.0;
            DIDLumpSum = 0.0;
            DISSpouseProportion = 0.0;
            DISLumpSum = 0.0;
        }

        /// <summary>
        /// Constructor for the Death class with parameters.
        /// </summary>
        /// <param name="name">The name of the death category.</param>
        /// <param name="id">The ID of the death category.</param>
        /// <param name="description">The description of the death category.</param>
        /// <param name="darSpouseProportion">The Spouse Death After Retirement (DAR) proportion.</param>
        /// <param name="guaranteePeriod">The guarantee period post-retirement in years.</param>
        /// <param name="didSpouseProportion">The Spouse Death in Deferment (DID) proportion.</param>
        /// <param name="didLumpSum">The lump sum payment for Death in Deferment (DID).</param>
        /// <param name="disSpouseProportion">The Spouse Death in Service (DIS) proportion.</param>
        /// <param name="disLumpSum">The lump sum payment for Death in Service (DIS).</param>
        public Death(string name, string id, string description, double darSpouseProportion,
                     int guaranteePeriod, double didSpouseProportion, double didLumpSum,
                     double disSpouseProportion, double disLumpSum)
        {
            Name = name;
            ID = id;
            Description = description;
            DARSpouseProportion = darSpouseProportion;
            GuaranteePeriod = guaranteePeriod;
            DIDSpouseProportion = didSpouseProportion;
            DIDLumpSum = didLumpSum;
            DISSpouseProportion = disSpouseProportion;
            DISLumpSum = disLumpSum;


            PTXCalc_ConstructorCalcs();
        }

        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
        }


    }
}
