//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************

using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// A standard Scheme Year
    /// </summary>
    public class EarningsSY : SchemeYear
    //Earning and Salary for a single year
    {

        //Variables
        public double earn { get; set; }
        public double sal { get; set; }
        public double Actual { get; set; }
        public double infGrownSal { get; set; }

        //Default Constructor
        public EarningsSY()
        {
            earn = 0;
            sal = 0;
            Actual = 0;
            infGrownSal = 0;
        }

        //Constructor
        public EarningsSY(DateTime dtBaseDate, DateTime dtLDOS, DateTime dtEmpStartDate, DateTime dtEndEndDate, DateTime dtProjDate,
                            double dearn, double dsal, double dActual, double dInfGrownSal)
        {
            this.BaseDate = dtBaseDate;
            this.LDOS = dtLDOS;
            this.EmpStartDate = dtEmpStartDate;
            this.EmpEndDate = dtEndEndDate;
            this.ProjDate = dtProjDate;

            //Do scheme year calculations on creation to set up all required fields
            this.CalcSchemeYear();

            this.earn = dearn;
            this.sal = dsal;
            this.Actual = dActual;
            this.infGrownSal = dInfGrownSal;
        }

    }
}
