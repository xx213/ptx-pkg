//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************

namespace PTXClassLibrary
{

    //List all Global Variables used in MyCSP, unique to MyCSPusing PTXClassLibrary; namespace

    internal class Client1Globals : PTXGlobals
    {
        //Version, names etc
        internal const string sCompany = "Client1";
        internal const string sCalcs = "Client1 Calculations";
        internal const string sVersion = "Client0.1";

        //MyCSP CSV Table Location
        internal const string sTablesLocation = @"Tables\FactorsTableReader.csv";


        //******************************************************************

        //Deferred Revaluation Basis
        internal const double dPre88GMPStatRev = 0;
        internal const double dPost88GMPStatRev = 0;  //Uses fixed
        internal const double dPre97XSStatRev = 0;
        internal const double dPost97StatRev = 0;

        //Pension In Payment Increases Basis
        internal const double dPre88GMPPenIncs = 0.03;
        internal const double dPost88GMPPenIncs = 0.03;
        internal const double dPre97XSPenIncs = 0.025;
        internal const double dPost97PenIncs = 0.04;

        //Dates


        //Schemes
        internal const string scmClient1 = "TheNumberOnePensionScheme";


        //Accrual Rates
        internal const double accScheme = 0.0232;

        //Commutation Rates
        internal const double com12 = 12;

        //NPA and retirement ages
        internal const int iSchemeNPA = 65;
        internal const int iSchemeMinNPA = 55;  //Integers used for UI validation
        internal const int iSchemeMaxNPA = 75;  //Integers used for UI validation

        //Security 
        internal const string sPassword = "m1CSP_p@SSword";

        //Error Messages

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