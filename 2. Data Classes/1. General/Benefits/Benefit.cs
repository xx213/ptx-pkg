using System;
using System.Collections.Generic;

namespace PTXClassLibrary
{
    abstract internal class Benefit
    //Single benefit class
    {

        public string Scheme { get; set; }
        public List<double> CommResPen = new List<double>();
        public List<double> CommLS = new List<double>();

        public ProjEarnings myProjEarnings;
        public DateTime ProjStartDate { get; set; }  //Date Projections Start
        public DateTime ProjEndDate { get; set; }  //Date Projections End
        public DateTime ProjLDOS { get; set; } // Last day of service when the projections end
        public int ProjStartYear { get; set; }
        public int ProjEndYear { get; set; }

        //ProjBenefits basis
        public double SalGrowth { get; set; }
        public double ActInfRate { get; set; }
        public double DefInfRate { get; set; }

        //Calculated
        public double ageProjDateYD;  // Age at Proj Date Y+D as decimal
        public int ageProjDateM;     // Age at Proj Date in complete months as integer
        public double NPA;
        //  Pension values
        public double PenBasic = 0;     //Pension at NPA with no reductions
        public double Pen = 0;          //Pension at NPA with ERF reductions  
        public double PenERF = 1;       //Pension Early Ret Factor at ageProjDate to NPAs  
        //  Lump Sum values
        public double MinLS = 0;       //Minimum allowable LumpSum, after ERF reductions on Pension
        public double MaxLS = 0;     //Maximum allowable LumpSum, after ERF reductions on Pension
        public double LSERF = 1;       //Pension Early Ret Factor at ageProjDate to NPAs  

        //Normal set in globals
        public double AccRate;
        public double CashCommRate;



        // Default constructor: 
        public Benefit()
        {
        }

        //Public Methods
        abstract public void CalcBenefit();
        //{
        //This method will be overloaded in each derived class
        //Use to set the values in the CommResPen and CommLS
        //}

        abstract public void CalcAges();
        //{
        //This method will be overloaded in each derived class
        //Use to set the values of any required ages
        //}

        abstract public void CalcLumpSum();
        //{
        //This method will be overloaded in each derived class
        //Use to set the values of all lump sums in range MinLS to MaxLS
        //}

    }
}
