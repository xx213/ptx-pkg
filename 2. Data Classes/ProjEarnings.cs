//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************


using System;
using System.Collections.Generic;

namespace PTXClassLibrary
{
    abstract internal class ProjEarnings
    {

        //Collection of EarningsSY Classes, by future projected year
        public List<EarningsSY> EarningsYears = new List<EarningsSY>();

        //Single first year earnings
        public EarningsSY FirstYearEarnings { get; set; }

        //Only required if calculating split year salaries
        public DateTime ProjStartDate { get; set; }  //Date Projections Start
        public DateTime ProjEndDate { get; set; }  //Date Projections End

        //Ages for projections, for flexibility
        public double ProjStartAge { get; set; }  //Age Projections Start
        public double ProjEndAge { get; set; }  //Age  Projections End

        //Only required for Part Time Calcs
        public double ContractedHours { get; set; }
        public double StandardHours { get; set; }

        //ProjBenefits basis
        public double SalGrowth { get; set; }
        public double ActInfRate { get; set; }
        public double DefInfRate { get; set; }

        //Indexed on ProjYear ranges from ProjStartYear to ProjEndYear
        public int ProjStartYear { get; set; }
        public int ProjEndYear { get; set; }

        //Constructors
        /// <summary>
        /// Calculate projected Earnings
        /// </summary>
        internal ProjEarnings() { }


        /// <summary>
        /// Abstract function for overriding Projected Earnings
        /// </summary>
        public abstract void CalcProjEarnings();
        //{This method will be overloaded in each derived class}

        //Function to return relevant EarningsSY
        public EarningsSY GetProjYear(int iSchemeYear)
        {
            try
            {
                if (iSchemeYear >= ProjStartYear && iSchemeYear <= ProjEndYear)
                {
                    return EarningsYears.Find(x => x.projYear == iSchemeYear);
                }
                else
                {
                    return new EarningsSY();
                }
            }
            catch { return new EarningsSY(); }
        }



    }
}
