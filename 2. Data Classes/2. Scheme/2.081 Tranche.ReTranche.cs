using Newtonsoft.Json;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents a redefined tranche with additional components.
    /// </summary>
    public class ReTranche : Tranche
    {
        /// <summary>
        /// The Normal Pension Age for a Female the tranche.
        /// </summary>
        [JsonProperty("npa_f")]
        public double NPAF { get; set; }

        /// <summary>
        /// The Normal Pension Age for a Male the tranche.
        /// </summary>
        [JsonProperty("npa_m")]
        public double NPAM { get; set; }

        /// <summary>
        /// The Early Retirement Factor (ERF) for the tranche.
        /// </summary>
        [JsonProperty("erf")]
        public ERFx ERF { get; set; }

        /// <summary>
        /// The Late Retirement Factor (LRF) for the tranche.
        /// </summary>
        [JsonProperty("lrf")]
        public LRFx LRF { get; set; }

        /// <summary>
        /// The pension value.
        /// </summary>
        [JsonProperty("pen")]
        public decimal Pen { get; set; }

        /// <summary>
        /// Creates a new instance of the ReTranche class with default values.
        /// </summary>
        public ReTranche()
            : base()
        {
            // Initialize the additional components with default values
            NPAM = 65; // Set the default value for NPAM
            NPAF = 65; // Set the default value for NPAF
            ERF = new ERFx(); // Initialize ERF object
            LRF = new LRFx(); // Initialize LRF object
            Pen = 0; // Set the default value for Pen

        }

        /// <summary>
        /// Creates a new instance of the ReTranche class.
        /// </summary>
        /// <param name="guid">The GUID of the tranche.</param>
        /// <param name="name">The name of the tranche.</param>
        /// <param name="id">The ID of the tranche.</param>
        /// <param name="description">The description of the tranche.</param>
        public ReTranche(string name, string id, string description)
            : base(name, id, description)
        {
            // Initialize the additional components
            NPAM = 65; // Set the default value for NPAM
            NPAF = 65; // Set the default value for NPAF
            ERF = new ERFx(); // Initialize ERF object
            LRF = new LRFx(); // Initialize LRF object
            Pen = 0; // Set the default value for Pen

            PTXCalc_ConstructorCalcs();
        }

        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
            // Override this if required
        }
    }
}
