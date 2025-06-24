//-----------------------------------------------------------------------------
// File: BaseMemberMyCSP.cs
//-----------------------------------------------------------------------------
// Namespace: PTXClassLibrary
//-----------------------------------------------------------------------------
// Description: This file contains the BaseMemberMyCSP class, which is the base class for MemberMyCSP and provides fundamental properties and calculations related to members.
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
// List of functions: N/A
//-----------------------------------------------------------------------------
// Author: RPM IT Consulting Ltd
// Website: https://www.rpmitconsulting.com
// Website: https://www.pentechx.com
// Repository: https://randomwalk.visualstudio.com/PTX
//-----------------------------------------------------------------------------
// Version History:
//-----------------------------------------------------------------------------
// Version    | Author and Date    | Checker and Date | Description
//-----------------------------------------------------------------------------
// 1.000 #DEV | RPMIT dd/mm/yyyy   | USER dd/mm/yyyy  | Initial version
//-----------------------------------------------------------------------------


using System;
namespace PTXClassLibrary
{
    internal class BaseMemberMyCSP : Individual
    {
        public string P1Scheme { get; set; }  //Note sections are treated like separate schemes for the purposes of this code
        public double ReckServY { get; set; }
        public double ReckServD { get; set; }
        public double ReckServPre2002Y { get; set; }
        public double ReckServPre2002D { get; set; }
        public double ReckServPost2002Y { get; set; }
        public double ReckServPost2002D { get; set; }

        //***
        public double AccruedNuvosPen { get; set; }
        public double AccruedAlphaPen { get; set; }
        public double ContactedHours { get; set; }
        public double StandardHours { get; set; }

        //Calculated Values
        public DateTime BD75 { get; set; }
        public DateTime P1NPD { get; set; }
        public DateTime P2NPD { get; set; }
        public string sP1NPA { get; set; }
        public string sP2NPA { get; set; }
        public double P1NPA { get; set; }
        public double P2NPA { get; set; }
        public int P2NPAY { get; set; }
        public int P2NPAM { get; set; }
        public string sAgeApr12 { get; set; }

        //TBC
        public DateTime TEEnd { get; set; }
        public DateTime TELDOS { get; set; }

        //Constructors
        // Default constructor: 
        public BaseMemberMyCSP()
        {
            //Sex and DOB set in member Class
            this.DOB = PTXGlobals.dtMinDate;
            this.Sex = "M";
            this.CalcDate = PTXGlobals.dtMinDate;
            this.P1Scheme = MyCSPGlobals.scmClassic;
            this.ReckServD = 0;
            this.ReckServY = 0;
            this.ReckServPre2002D = 0;
            this.ReckServPre2002Y = 0;
            this.ReckServPost2002D = 0;
            this.ReckServPost2002Y = 0;
            this.AccruedNuvosPen = 0;
            this.AccruedAlphaPen = 0;
            this.ContactedHours = 0;
            this.StandardHours = 0;

            this.BD75 = PTXGlobals.dtMinDate;
            this.P1NPD = PTXGlobals.dtMinDate;
            this.P2NPD = PTXGlobals.dtMinDate;


        }

        // Constructor: 
        public BaseMemberMyCSP(DateTime dtDOB, string strSex, DateTime dtCalcDate,
                            string strP1,
                            double dReckServY, double dReckServD,
                            double dReckServPre2002Y, double dReckServPre2002D,
                            double dReckServPost2002Y, double dReckServPost2002D,
                            double dAccruedNuvosPen, double dAccruedAlphaPen,
                            double dContactedHours, double dStandardHours,
                            double dSalary)
        {
            this.DOB = dtDOB;
            this.Sex = strSex;
            this.CalcDate = dtCalcDate;
            this.P1Scheme = strP1;
            this.ReckServD = dReckServD;
            this.ReckServY = dReckServY;
            this.ReckServPre2002D = dReckServPre2002D;
            this.ReckServPre2002Y = dReckServPre2002Y;
            this.ReckServPost2002D = dReckServPost2002D;
            this.ReckServPost2002Y = dReckServPost2002Y;
            this.AccruedNuvosPen = dAccruedNuvosPen;
            this.AccruedAlphaPen = dAccruedAlphaPen;
            this.ContactedHours = dContactedHours;
            this.StandardHours = dStandardHours;

            //Set Calculated Values
            //First Year's Salary, rounded and salary done in projection
            this.FirstYearEarnings.sal = dSalary;


            //this.RetDate = /*Add Code*/; 

            this.BD75 = DOB.AddYears(75);



        }



    }
}
