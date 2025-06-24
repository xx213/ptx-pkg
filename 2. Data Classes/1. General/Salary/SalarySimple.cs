using Newtonsoft.Json;
namespace PTXClassLibrary
{
    /// <summary>
    /// Single simplified salary include a Salary, Earnings, PensionContributions,PensionableEarnings
    /// </summary>
    public class SalarySimple
    {
        [JsonProperty("Age")]
        public int Age { get; set; }

        /// <summary>
        /// Salary at start of index, curr
        /// </summary>
        [JsonProperty("Sal")]
        public double Sal { get; set; }

        /// <summary>
        /// Salary increases over index, curr
        /// </summary>
        [JsonProperty("SalInc")]
        public double SalInc { get; set; }

        /// <summary>
        /// Salary at end of index, curr
        /// </summary>
        [JsonProperty("SalEOY")]
        public double SalEOY { get; set; }

        /// <summary>
        /// Pension contributions paid over year, curr
        /// </summary>
        [JsonProperty("Conts")]
        public double Conts { get; set; }

        // Other earnings buckets
        /// <summary>
        /// Earnings over index, curr
        /// </summary>
        [JsonProperty("Earn")]
        public double Earn { get; set; }

        /// <summary>
        /// Pensionable Earnings over index, curr
        /// </summary>
        [JsonProperty("PensionableEarn")]
        public double PensionableEarn { get; set; }

        /// <summary>
        /// Final Pensionable Salary, end of Index, curr
        /// Required a calculation definition
        /// </summary>
        [JsonProperty("FPS")]
        public double FPS { get; set; }

        // Default constructor
        public SalarySimple()
        {
            InitializeDefaults();
        }

        [JsonConstructor]
        public SalarySimple(int age, double sal, double salInc, double salEOY, double conts, double earn, double pensionableEarn, double fps)
        {
            Age = age;
            Sal = sal;
            SalInc = salInc;
            SalEOY = salEOY;
            Conts = conts;
            Earn = earn;
            PensionableEarn = pensionableEarn;
            FPS = fps;
        }

        private void InitializeDefaults()
        {
            Age = 0;
            Sal = 0;
            SalInc = 0;
            SalEOY = 0;
            Conts = 0;
            Earn = 0;
            PensionableEarn = 0;
            FPS = 0;
        }

        // Rest of the class code...
    }

    /// <summary>
    /// ProjArraySalarySimple List - Trial
    /// </summary>
}
