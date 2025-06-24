//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************

using System;

namespace PTXClassLibrary
{

    //List all Global Pensions related variables used in PTXClassLibrary

    internal class PensionGlobals : PTXGlobals
    {
        //Version, names etc
        internal const string sCompany = "PTX.Eco";
        internal const string sCalcs = "PTX Pension Globals";
        internal const string sVersion = "V0.1";

        //MyCSP CSV Table Location
        internal const string sTablesLocation = @"Tables\FactorsTableReader.csv";


        //******************************************************************




        //Dates
        internal const string dayGMP97 = "06/04/1997";
        internal static DateTime dtGMP97 = new DateTime(1997, 4, 6);
        internal const string dayGMP88 = "06/04/1988";
        internal static DateTime dtGMP88 = new DateTime(1988, 4, 6);
        internal const string dayGMP78 = "06/04/1978";
        internal static DateTime dtGMP78 = new DateTime(1978, 4, 6);

        //Pre 85 service get zero revaluation increases by default
        internal const string dayXS85 = "01/01/1985";
        internal static DateTime dtXS85 = new DateTime(1985, 1, 1);

        //Pension increase cap changed from 5% to 2.5%
        internal const string dayPI2005 = "04/06/2005";
        internal static DateTime dtPI2005 = new DateTime(2005, 6, 4);


        //Barber date 
        internal const string dayBB90 = "17/05/1990";
        internal static DateTime dtBB90 = new DateTime(1990, 5, 17);

        //A Day 
        internal const string dayADay = "04/06/2006";
        internal static DateTime dtADay = new DateTime(2006, 6, 4);

        //day2009_InfIRevalSwitch, Switch from RPI to CPI revaluation
        internal const string day2009 = "04/06/2009";
        internal static DateTime dt2009 = new DateTime(2009, 6, 4);

        //day2011_InfPenIncSwitch , Switch from Cap of RPI 2.5% to CPI 2.5% on Public Sector Pensions
        internal const string dayPI2011 = "01/04/2011";
        internal static DateTime dtPI2011 = new DateTime(2011, 4, 1);

        //day2012_McCloudStartDate , McCloud start period
        internal const string dayMcCloud2009 = "04/01/2009";
        internal static DateTime dtMcCloud2009 = new DateTime(2012, 1, 4);

        //day2012_PISwitch , Switch from use of RPI to CPI as a measure for pension increases for other (non-public sector) occupational pension schemes
        internal const string dayPI2014 = "04/06/2012";
        internal static DateTime dtPI2014 = new DateTime(2012, 6, 4);

        //day2014_McCloudRemedyStartDate , McCloud remedy period start date
        internal const string dayMcCloudRemedyStartDate2014 = "01/04/2012";
        internal static DateTime dtMcCloudRemedyStartDate2014 = new DateTime(2012, 4, 1);

        //day2016_SPAChanges,First Changes to State Pension Scheme and Age TBC
        internal const string daySPAChanges2016 = "04/06/2016";
        internal static DateTime dtSPAChanges2016 = new DateTime(2016, 6, 4);


        //GMPAges 
        internal const int GMPAM = 65;
        internal const int GMPAF = 60;


        //Schemes


        //Accrual Rates


        //Age Addition Rates


        //Commutation Rates


        //NPA and retirement ages

    }
}