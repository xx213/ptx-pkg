//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************


using System;

namespace PTXClassLibrary
{
    internal class CAREAccrualSY : SchemeYear
    {
        internal EarningsSY myEarningsSY { get; set; }

        //Calculated variables
        //  Various Components of CARE account
        public double Opening { get; set; }
        public double Accrual { get; set; }
        public double Indexation { get; set; }
        public double AgeAddition { get; set; }
        public double AssumedAgeAddition { get; set; }
        public double Closing { get; set; }
        public double BasicPenRetDate { get; set; }
        public double ClosingBalancePenRetDate { get; set; }
        public double RIARetDate { get; set; }
        public double PenRetDate { get; set; }  //Pension at Retirement Age, includes RIA


        //Default Constructor
        public CAREAccrualSY()
        {
            this.Opening = 0;
            this.Accrual = 0;
            this.Indexation = 0;
            this.AgeAddition = 0;
            this.AssumedAgeAddition = 0;
            this.Closing = 0;
        }

        //Constructor
        internal CAREAccrualSY(DateTime dtBaseDate, DateTime dtLDOS, DateTime dtEmpStartDate, DateTime dtEndEndDate, DateTime dtProjDate,
                            EarningsSY inmyEarningsSY)

        {
            this.BaseDate = dtBaseDate;
            this.LDOS = dtLDOS;
            this.EmpStartDate = dtEmpStartDate;
            this.EmpEndDate = dtEndEndDate;
            this.ProjDate = dtProjDate;

            //Do scheme year calculations on creation to set up all required fields
            this.CalcSchemeYear();

            myEarningsSY = inmyEarningsSY;
        }



    }
}
