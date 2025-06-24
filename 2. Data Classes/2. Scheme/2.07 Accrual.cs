using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents accrual data.
    /// </summary>
    public class Accrual
    {
        /// <summary>
        /// The GUID of the accrual data.
        /// </summary>
        [JsonProperty("GUID")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the accrual data.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the accrual data.
        /// </summary>
        [JsonProperty("ID")]
        public string ID { get; set; }

        /// <summary>
        /// The description of the accrual data.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// The accrual cease date.
        /// </summary>
        [JsonProperty("AccCeaseDate")]
        public DateTime AccCeaseDate { get; set; }

        /// <summary>
        /// The rate of accrual.
        /// </summary>
        [JsonProperty("Rate")]
        public double Rate { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Accrual"/> class with default values.
        /// </summary>
        public Accrual()
        {
            GUID = Guid.NewGuid();
            Name = string.Empty;
            ID = string.Empty;
            Description = string.Empty;
            AccCeaseDate = new DateTime(2099, 12, 31);
            Rate = 0.0;
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="Accrual"/> class.
        /// </summary>
        /// <param name="guid">The GUID of the accrual data.</param>
        /// <param name="name">The name of the accrual data.</param>
        /// <param name="id">The ID of the accrual data.</param>
        /// <param name="description">The description of the accrual data.</param>
        /// <param name="accCeaseDate">The accrual cease date.</param>
        /// <param name="rate">The rate of accrual.</param>
        public Accrual(string name, string id, string description, DateTime accCeaseDate, double rate)
        {
            GUID = Guid.NewGuid();
            Name = name;
            ID = id;
            Description = description;
            AccCeaseDate = accCeaseDate;
            Rate = rate;
            PTXCalc_ConstructorCalcs();
        }

        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
            // Override this if required
        }
    }
}

