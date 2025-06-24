
using System;

namespace PTXClassLibrary
{

    //List all Global Variables used in MyCSP, unique to MyCSPusing PTXClassLibrary; namespace

    internal class MyCSPGlobals : PTXGlobals
    {
        //Version, names etc
        internal const string sCompany = "MyCSP";
        internal const string sCalcs = "MyCSP Calculations";
        internal const string sVersion = "MyCSP2.0";

        //MyCSP CSV Table Location
        internal const string sTablesLocation = @"Tables\FactorsTableReader.csv";


        //******************************************************************
        //Taper choices 
        internal const string strRetain = "Retain";
        internal const string strRelinquish = "Relinquish";

        //Dates
        internal const string dayOne = "01/04/2015";
        internal static DateTime dtOne = new DateTime(2015, 4, 1);
        internal const string day2012 = "01/04/2012";
        internal static DateTime dt2012 = new DateTime(2012, 4, 1);
        internal static DateTime dtTestDate = dt2012;
        internal const string dayCalcDate = "31/03/2014";
        internal static DateTime dtCalcDate = new DateTime(2014, 3, 31);

        //Schemes
        internal const string scmAlpha = "ALPHA";
        internal const string scmClassic = "CLASSIC";
        internal const string scmClassicPlus = "CLASSICPLUS";
        internal const string scmPremium = "PREMIUM";
        internal const string scmNuvos = "NUVOS";
        internal const string scmFresh = "FRESH";

        //Accrual Rates
        internal const double accAlpha = 0.0232;
        internal const double accNuvos = 0.0230;
        internal const double accClassic = 29200;
        internal const double accClassicPlus = 21900;
        internal const double accPremium = 21900;

        //Age Addition Rates
        internal const double aarNuvos = 0.055;

        //Commutation Rates
        internal const double com12 = 12;

        //NPA and retirement ages
        internal const int npaNuvos = 65;
        internal const int npaClassic = 60;
        internal const int npaClassicPlus = 60;
        internal const int npaPremium = 60;
        internal const int npaFresh = 60;

        internal const int iOE_MinNPA = 55;  //Integers used for UI validation
        internal const int iOE_MaxNPA = 75;  //Integers used for UI validation
        internal const int iDefaultNPA = 0;
        internal const double dUpperAgeLimit = 75;

        //Security 
        internal const string sPassword = "m1CSP_p@SSword";

        //Error Messages

        internal const string sErrScheme = "Incorrect scheme Name (" + scmClassic + "/" + scmClassicPlus + "/" + scmPremium + "/" + scmNuvos + scmFresh + "/" + scmAlpha + ")";
        internal const string sErrSchemeP1 = "Incorrect Part 1 scheme Name";
        internal const string sErrSchemeP2 = "Incorrect Part 2 scheme Name (" + scmAlpha + ")";
        internal const string sErrDOBFormat = "Date Of Birth incorrect";
        internal const string sErrDayCalcFormat = "Calculation Date is incorrect";
        internal const string sErrDOBOOR = "DOB out of range";
        internal const string sErrDayCalcOOR = "CalcDate out of range";

        internal const string sTotalReckServGT45 = "Total GT 45";
        internal const string sErrReckServDOOR = "Days outside range";
        internal const string sErrReckServYOOR = "Years outside range";
        internal const string sErrStanLTContHours = "Standard < Contracted Hours";







    }
}