using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents retirement age options with various conditions and default values.
    /// </summary>
    public class RetirementAges
    {
        /// <summary>
        /// The GUID of the retirement age option.
        /// </summary>
        [JsonProperty("GUID")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the retirement age option.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the retirement age option.
        /// </summary>
        [JsonProperty("ID")]
        public string ID { get; set; }

        /// <summary>
        /// The description of the retirement age option.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// The pre-Barber Normal Retirement Age (NRA) for males.
        /// Allowed range: 55 to 75.
        /// Default: 65.
        /// </summary>
        [JsonProperty("PreBarberNRA_M")]
        public double PreBarberNRA_M { get; set; }

        /// <summary>
        /// The pre-Barber Normal Retirement Age (NRA) for females.
        /// Allowed range: 55 to 75.
        /// Default: 60.
        /// </summary>
        [JsonProperty("PreBarberNRA_F")]
        public double PreBarberNRA_F { get; set; }

        /// <summary>
        /// The Barber to Eqn Normal Retirement Age (NRA) for females.
        /// Allowed range: 55 to 75.
        /// Default: 60.
        /// </summary>
        [JsonProperty("BBtoEqnrNRA_F")]
        public double BBtoEqnNRA_F { get; set; }

        /// <summary>
        /// The Barber to Eqn Normal Retirement Age (NRA) for males.
        /// Allowed range: 55 to 75.
        /// Default: 60.
        /// </summary>
        [JsonProperty("BBtoEqnrNRA_M")]
        public double BBtoEqnNRA_M { get; set; }

        /// <summary>
        /// The post-Barber Normal Retirement Age (NRA).
        /// Allowed range: 55 to 75.
        /// Default: 65.
        /// </summary>
        [JsonProperty("PostBBNRA")]
        public double PostBBNRA { get; set; }

        /// <summary>
        /// The earliest Age Unreduced (EAU) for retirement.
        /// Allowed values: NRA, EAU, DOR, or a number between 55 and 65.
        /// Default: 55.
        /// </summary>
        [JsonProperty("EarliestAgeUnreduced")]
        public string EarliestAgeUnreduced { get; set; }

        /// <summary>
        /// The option for applying Limited Revaluation Factor (LRF).
        /// Allowed values: NRA, EAU, DOR, or a number between 55 and 65.
        /// Default: NRA.
        /// </summary>
        [JsonProperty("LRFApplies")]
        public string LRFApplies { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetirementAges"/> class.
        /// </summary>
        public RetirementAges()
        {
            GUID = Guid.NewGuid();
            Name = string.Empty;
            ID = string.Empty;
            Description = string.Empty;
            PreBarberNRA_M = 65;
            PreBarberNRA_F = 60;
            BBtoEqnNRA_F = 60;
            BBtoEqnNRA_M = 60;
            PostBBNRA = 65;
            EarliestAgeUnreduced = "55";
            LRFApplies = "NRA";
        }

        protected RetirementAges(string name, string id, string description,
                                 double preBarberNRA_M, double preBarberNRA_F, double postBBNRA,
                                 string earliestAgeUnreduced, string lrfApplies)
        {
            GUID = Guid.NewGuid();
            Name = name;
            ID = id;
            Description = description;
            PreBarberNRA_M = ValidateAndSetDefault(preBarberNRA_M, 55, 75, 65);
            PreBarberNRA_F = ValidateAndSetDefault(preBarberNRA_F, 55, 75, 60);
            BBtoEqnNRA_F = ValidateAndSetDefault(BBtoEqnNRA_F, 55, 75, 60);
            BBtoEqnNRA_M = ValidateAndSetDefault(BBtoEqnNRA_M, 55, 75, 60);
            PostBBNRA = ValidateAndSetDefault(postBBNRA, 55, 75, 65);
            EarliestAgeUnreduced = ValidateAndSetDefault(earliestAgeUnreduced, "NRA", "EAU", "DOR", "55");
            LRFApplies = ValidateAndSetDefault(lrfApplies, "NRA", "EAU", "DOR");
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
