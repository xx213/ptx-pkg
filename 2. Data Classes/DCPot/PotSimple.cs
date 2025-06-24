using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// DC/Pot used to store DC info
    /// Used in projections for simplicity
    /// </summary>
    public class PotSimple
    //Single DC POT class
    {

        [JsonProperty("Age")]
        public int Age { get; set; }

        /// <summary>
        /// newValue of pot at start of index, curr
        /// </summary>
        [JsonProperty("Pot")]
        public double Pot { get; set; }

        /// <summary>
        /// Investment costs/expenses over index, curr
        /// </summary>
        [JsonProperty("InvCosts")]
        public double InvCosts { get; set; }

        /// <summary>
        /// Investment increase over index, curr
        /// </summary>
        [JsonProperty("InvInc")]
        public double InvInc { get; set; }

        /// <summary>
        /// Additional cash over index, curr (Payments)
        ///</summary>
        [JsonProperty("AddCash")]
        public double AddCash { get; set; }

        /// <summary>
        /// Pot value at end of year, curr
        ///</summary>
        [JsonProperty("PotEOY")]
        public double PotEOY { get; set; }

        /// <summary>
        /// Pot value after Costs at end of year, curr
        ///</summary>
        [JsonProperty("PotPostCostsEOY")]
        public double PotPostCostsEOY { get; set; }
        public double SalConts { get; private set; }

        //[JsonProperty("CalcAudit")]
        //public string CalcAudit { get; set; } = "NA.  ";

        // Default constructor: 
        public PotSimple()
        {
            Age = 0;
            Pot = 0;
            InvCosts = 0;
            InvInc = 0;
            AddCash = 0;
            PotEOY = 0;
            PotPostCostsEOY = 0;
        }



        /// <summary>
        /// Calculate investment increase based on Investment rate, dCostPApc is PC eg 0.025 = 2.5% increase
        /// Excel Model : Investment Increases, =(1+IF([@IndexRange]="i1_2",DSXXDD_Inv1_2,0))^1
        /// Excel  =[@[POT Start of Index]]*[@[Investment Inc 1+PC]]+[@[Additional Cash]]*[@[Investment Inc 1+PC]]+[@[Salary Conts (whole Year)]]
        /// </summary>
        /// <param name="dInvpc"></param>
        public void CalcInvInc(double dInvpc)
        {
            //Define investment model here
            InvInc = Pot * Math.Pow(1 + dInvpc, 1) - Pot
                   + AddCash * Math.Pow(1 + dInvpc, 1) - AddCash;
        }

        /// <summary>
        /// Calculate the cost running fund over the index 
        /// dCostPApc is PC eg 0.025 = 2.5% increase cost
        /// Excel : =[@[Pot End Of Year]]*DSXXDD_CostPApc1_2
        /// </summary>
        /// <param name="dCostPApc"></param>
        public void CalcInvCosts(double dCostPApc)
        {
            InvCosts = PotEOY * dCostPApc;

        }

        /// <summary>
        /// Calculate PotEOY using existing values , Pot + InvInc + AddCash
        /// </summary>
        public void CalcPotEOY(double SalConts)
        {
            PotEOY = Pot + AddCash + InvInc + SalConts;
        }

        /// <summary>
        /// Calculate PotPostCostsEOY using existing values , Pot + InvInc - InvCosts
        /// </summary>
        public void CalcPotPostCostsEOY()
        {
            PotPostCostsEOY = PotEOY - InvCosts;
        }


        /// <summary>
        /// Calculate PotPostCostsEOY using input basically :  Pot + InvInc + SalConts  - InvCosts
        /// This is done pageSuperLoader goes an populates the object fully
        /// </summary>
        /// <param name="dPot"></param>
        /// <param name="dInvpc"></param>
        /// <param name="dAddCash"></param>
        /// <param name="dCostPApc"></param>
        public void CalcSalEOY(double dPot, double dAddCash, double dInvpc, double dSalConts, double dCostPApc)
        {
            Pot = dPot;
            AddCash = dAddCash;

            CalcInvInc(dInvpc);
            CalcInvCosts(dCostPApc);
            CalcPotEOY(dSalConts);
            CalcPotPostCostsEOY();
        }

    }
}
