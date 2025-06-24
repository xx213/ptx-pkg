using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents equalisation data with various properties.
    /// </summary>
    public class Equalisation
    {
        /// <summary>
        /// The GUID of the equalisation data.
        /// </summary>
        [JsonProperty("guid")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the equalisation data.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the equalisation data.
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// The description of the equalisation data.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The end date or condition for the Barber model in equalisation.
        /// </summary>
        [JsonProperty("barberEndDate")]
        public DateTime BarberEndDate { get; set; }

        /// <summary>
        /// The Normal Retirement Age (NRA) for the Barber model in equalisation.
        /// Also See Category.RetirementAges.BBtoEqnNRA_M/F 
        /// </summary>
        [JsonProperty("barberNRA")]
        public double BarberNRA { get; set; }

        /// <summary>
        /// The index linking method from Barber NRA to NRA in equalisation.
        /// </summary>
        [JsonProperty("indexBBNRAtoNRA")]
        public string IndexBBNRAtoNRA { get; set; }

        /// <summary>
        /// The index linking method from post-category NRA to NRA in equalisation.
        /// Enumerated List to be added
        /// </summary>
        [JsonProperty("indexPostCatNRA")]
        public string IndexPostCatNRA { get; set; }

        public Equalisation()
        {
            // Set default values for properties
            GUID = Guid.Empty;
            Name = string.Empty;
            ID = string.Empty;
            Description = string.Empty;
            BarberEndDate = new DateTime(1990, 5, 17);
            BarberNRA = 0.0;
            IndexBBNRAtoNRA = "Revaluation";
            IndexPostCatNRA = string.Empty;
        }

        public Equalisation(string name, string id, string description,
                             DateTime barberEndDate, double barberNRA,
                            string indexBBNRAtoNRA, string indexPostCatNRA)
        {
            GUID = Guid.NewGuid();
            Name = name;
            ID = id;
            Description = description;
            BarberEndDate = barberEndDate;
            BarberNRA = barberNRA;
            IndexBBNRAtoNRA = ValidateAndSetDefault(indexBBNRAtoNRA, "Revaluation", "Non-Standard", "Standard LRF Model");
            IndexPostCatNRA = indexPostCatNRA;
            PTXCalc_ConstructorCalcs();
        }

        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
            // Override this if required
        }

        private T ValidateAndSetDefault<T>(T value, params T[] allowedValues)
        {
            if (Array.IndexOf(allowedValues, value) != -1)
                return value;

            // Set default value if not allowed
            return allowedValues[0];
        }
    }
}
