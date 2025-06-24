//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************

using System;
using System.Collections.Generic;

namespace PTXClassLibrary
{
    abstract internal class ProjBenefits
    {

        //List of benefits associated with project
        // For example Options Exercise has 2 : Part1, Part2
        public List<Benefit> Benefits = new List<Benefit>();
        public DateTime ProjStartDate { get; set; }  //Date Projections Start
        public DateTime ProjEndDate { get; set; }  //Date Projections End
        public ProjEarnings myProjEarnings { get; set; }

        //ProjBenefits basis
        public double SalGrowth { get; set; }
        public double ActInfRate { get; set; }
        public double DefInfRate { get; set; }

        //Calculated
        //Start/End of projection period based on year of scheme
        public int ProjStartYear { get; set; }
        public int ProjEndYear { get; set; }



        //Constructors
        //  
        /// <summary>
        /// Default constructor:
        /// Calculate projected pensions
        /// Uses ERF, LRF, NPA
        /// </summary>
        public ProjBenefits()
        {
            this.ProjStartDate = PTXGlobals.dtMinDate;
        }

        /// <summary>
        /// Calculate Projected Benefits/Pensions
        /// Override in child functions
        /// </summary>
        public abstract void CalcProjBenefits();
        //{This method will be overloaded in each derived class}


    }

}
