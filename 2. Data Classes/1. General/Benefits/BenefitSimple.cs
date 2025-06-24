using Newtonsoft.Json;

namespace PTXClassLibrary
{
    /// <summary>
    /// Simplified Benefit include a Pension and Lump sum value
    /// Used in projections for simplicity
    /// </summary>
    public class BenefitSimple
    //Single benefit class
    {

        [JsonProperty("Age")]
        public int Age { get; set; }

        /// <summary>
        /// newValue of Pen at start of index, curr
        /// </summary>
        [JsonProperty("Pen")]
        public double Pen { get; set; }

        /// <summary>
        ///  newValue of Scheme allowable Lump Sum at start of index, curr
        /// </summary>
        [JsonProperty("SchemeLS")]
        public double SchemeLS { get; set; }
        /// <summary>
        ///  newValue of (Lump Sum At Ret), start of index, curr
        /// </summary>
        [JsonProperty("LS")]
        public double LS { get; set; }

        //[JsonProperty("CalcAudit")]
        //public string CalcAudit { get; set; } = "NA.  ";

        // Default constructor: 
        public BenefitSimple()
        {
            Age = 0;
            Pen = 0;
            SchemeLS = 0;
            LS = 0;
        }





    }
}
