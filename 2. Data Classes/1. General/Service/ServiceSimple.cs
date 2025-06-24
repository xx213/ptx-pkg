using Newtonsoft.Json;
namespace PTXClassLibrary
{
    /// <summary>
    /// Simple Service used to store DC info
    /// Used in projections for simplicity
    /// </summary>
    public class ServiceSimple
    //Single DC POT class
    {

        [JsonProperty("Age")]
        public int Age { get; set; }

        /// <summary>
        /// Service at start of index, double
        /// </summary>
        [JsonProperty("Service")]
        public double Service { get; set; }


        /// <summary>
        /// Total Service Increase over index, double
        /// </summary>
        [JsonProperty("ServInc")]
        public double ServInc { get; set; }

        /// <summary>
        /// Total Service value at end of index, curr
        ///</summary>
        [JsonProperty("ServEOY")]
        public double ServEOY { get; set; }



        //[JsonProperty("CalcAudit")]
        //public string CalcAudit { get; set; } = "NA.  ";

        // Default constructor: 
        public ServiceSimple()
        {
            Age = 0;
            Service = 0;
            ServInc = 0;
            ServEOY = 0;
        }





        /// <summaryServ
        /// Calculate ServEOY using existing values , Serv + ServInc 
        /// </summary>
        public void CalcServEOY(double SalConts)
        {
            ServEOY = Service + ServInc;
        }






    }
}
