//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************

using System;

namespace PTXClassLibrary
{
    abstract public class SchemeYear
    {
        //Notes :: 
        //  The END OF scheme year is used as the primary key

        //Inputs
        // Base Date is date all calcs are based on
        public DateTime BaseDate { get; set; }
        /// <summary>
        /// Last Day Of Service
        /// </summary>
        public DateTime LDOS { get; set; }

        /// <summary>
        /// Start/End of employee's service, these are used to set the min and max values
        /// EmpEndDate : Date member left service
        /// </summary>

        public DateTime EmpStartDate { get; set; }
        public DateTime EmpEndDate { get; set; }

        // Date of projection
        public DateTime ProjDate { get; set; }


        //Calculated Values
        //   ProjBenefits Year used as PK, Year at end of Scheme year
        public int projYear { get; set; }

        //   Member's Start/End Dates in Scheme Year
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        //   Required Days Calculations       
        public int iDaysTotal { get; set; }
        public int iDaysAfterNPA { get; set; }
        public int iDaysToLDOS { get; set; }

        // Default constructor: 
        internal SchemeYear()
        { }

        //Methods
        public void CalcSchemeYear()
        {
            //Do calcs and assign values based on Base/Test date :

            //   Member's Start/End Dates in Scheme Year
            //startDate = MyCSPEngine.MyCSPSYStart_Engine(BaseDate);
            //if (BaseDate >= startDate) { startDate = BaseDate; }

            //Min (PrjDate, EmpEndDate, 
            //endDate = MyCSPEngine.MyCSPSYEnd_Engine(BaseDate);


            //   Year at end of Scheme year
            //           projYear = MyCSPEngine.MyCSPSYEnd_Engine(endDate).Year;
            //   Required Days Calculations       
            //iDaysTotal =
            //iDaysAfterNPA
            //iDaysToLDOS

        }


    }
}
