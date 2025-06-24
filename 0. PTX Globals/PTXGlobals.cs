//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************

//using Microsoft.AspNetCore.Http;
using System;
namespace PTXClassLibrary
{

    //List all Global Variables used in PTXClassLibrary and PenTechX
    //Public level

    public class PTXGlobals
    {

        public const string colRed = "Red";
        public const string colOrange = "Orange";
        public const string colGreen = "Green";

        // Define global color variables
        //Specific for Charts.JS
        public const string colrgbaPassBG = "rgba(75, 192, 192, 0.2)";
        public const string colrgbaPassBorder = "rgba(75, 192, 192, 1)";
        public const string colrgbaFailBG = "rgba(255, 99, 132, 0.2)";
        public const string colrgbaFailBorder = "rgba(255, 99, 132, 1)";
        public const string colrgbaNABG = "rgba(54, 162, 235, 0.2)";
        public const string colrgbaNABorder = "rgba(54, 162, 235, 1)";


        //Version, names etc
        internal const string sCompany = "RPM IT Consulting Ltd";
        internal const string sPenTechX = "PenTechX";
        internal const string sCalcs = "Actuarial Annuity and Commutation Calculations";
        internal const string sAgeService = "Age and Service Calculations";
        internal const string sMemberRec = "Member Reconciliation Calculations";

        internal const string sExample = "PTXClassLibrary Example";
        internal const string sVersion = "0.0.1.0";
        internal const string sNotFound = "Not Found";



        //Assembly details
        internal static AssemblyInfo GetAssemblyInfo()
        {
            return AssemblyInfoList.GetAssemblyInfoDTO();
        }


        //Deployment data
        internal const string sDeploymentMessage = "Deployment Message for PTXApp.DLL : Beta version, please request final version.";
        internal static DateTime dtReleaseDate = new DateTime(2024, 2, 1);


        //Get actual DLL verison'
        //Assembly PTXDLLAssembly = Assembly.LoadFrom("PTXApp.dll");
        //Version ver = PTXDLLAssembly.GetName().Version;
        //internal const string sDLLVersion = ver;


        //Tables Location
        internal const string sTablesLocation = "C:\\Users\\public\\Documents\\Robs Stuff\\Visual Studio 2008\\Projects\\ActTools\\Tables\\";

        //Security 
        internal const double dFail = 0;
        internal const double dPass = 1;
        internal const string sPassword = "Password";

        //Variable types
        internal const string sTypeString = "String";
        internal const string sTyPeInt = "Int";
        internal const string sTypeDouble = "Double";

        //Global Variables
        //Age
        internal const string sAgeType = sTyPeInt;
        internal const int iMaxAge = 150;
        internal const int iMinAge = 0;

        internal const string sADiffType = sTyPeInt;
        internal const int iMinADiff = -40;
        internal const int iMaxADiff = 40;

        //Sex, only check on first letter
        internal const string Male = "M";
        internal const string Female = "F";

        //GM
        internal const string sCalYearType = sTyPeInt;
        internal const int iMinCalYear = 1992;
        internal const int iMaxCalYear = 2192;

        internal const string sBirthYearType = sTyPeInt;
        internal const int iMinBirthYear = iMinCalYear - 150;
        internal const int iMaxBirthYear = iMaxCalYear - 150;

        internal const string sMortRate1Type = sTyPeInt;
        internal const int iMinMortRate1 = -10;
        internal const int iMaxMortRate1 = 10;

        internal const string sMortRate2Type = sTyPeInt;
        internal const int iMinMortRate2 = -10;
        internal const int iMaxMortRate2 = 10;

        internal const string sMortWeight1Type = sTyPeInt;
        internal const double dMinMortWeight1 = 0;
        internal const double dMaxMortWeight1 = 1;

        internal const string sMortWeight2Type = sTyPeInt;
        internal const double dMinMortWeight2 = 0;
        internal const double dMaxMortWeight2 = 1;

        //Rates (Act1DTable) // Not USED I THINK
        internal const string sIType = sTypeDouble;
        internal const double dMinI = -0.1;
        internal const double dMaxI = 0.2;

        internal const string sJType = sTypeDouble;
        internal const double dMinJ = -0.1;
        internal const double dMaxJ = 0.2;

        //Guarantee Period 
        internal const string sGTeeType = sTyPeInt;
        internal const int iMinGTee = 0;
        internal const int iMaxGTee = 19;

        //Temporary/Term Period
        internal const string sTermType = sTyPeInt;
        internal const int iMinTerm = 1;
        internal const int iMaxTerm = 100;

        internal const double dDefaultTableValue = -999999999;

        //Define Decrement/Age tables TableTypes
        internal const string sDecTypeQD = "QD";	//Death Decrement ErrMessage - same validation as atMort Variables
        internal const string sDecTypeQW = "QW";	//Withdrawal Decrement ErrMessage - same validation as atMort Variables
        internal const string sDecTypeQI = "QI";	//Ill Health Decrement ErrMessage - same validation as atMort Variables
        internal const string sDecTypeER = "ER";	//ER Decrement ErrMessage 
        internal const string sDecTypeSX = "SX";	//Promotional salary  - same validation for all Rate types
        internal const string sDecTypeHX = "HX";	//Proportion Married
        internal const string sDecTypeRA = "RA";	//Interest/Increase Rate - same validation for all Rate types
        internal const string sDecTypePR = "PR";	//ProjBenefits Table ErrMessage

        //Table Source Identfiers
        internal const string sTableSourceFile = "File"; // Read in from TXT file, currently only done in Reader.cs
        internal const string sTableSourceDataBase = "DataBase"; // Read in from DataBase XXX NEEDS IMPLEMENTATION
        internal const string sTableSourceConstant = "Constant"; // Used as constant eg 0.04 for 4%
        internal const string sTableSourceArray = "Array"; // Passed in as an array
        internal const string sTableMock = "Mock"; // From the DLL itself
        internal const string sTableSystem = "System"; // Generated by the system in engine functions
        internal const string sTableSourceNull = "NULL"; // Null Table

        //Age/Service Identifiers
        internal const string sAge = "Age";
        internal const string sService = "Service";
        internal const string sYear = "Y";
        internal const string sMonth = "M";
        internal const string sDay = "D";
        internal const string sYYYYMMDD = "YYYYMMDD";
        internal const string sDDMMYYYY = "DDMMYYYY";
        internal const string sDDMMYY = "DDMMYY";
        internal const string sMMDDYYYY = "MMDDYYYY";
        internal const string sMMDDYY = "MMDDYY";
        internal const string sMMDD = "MMDD";
        internal const string sDDMM = "DDMM";
        internal const double dDaysInYear36525 = 365.25;
        internal const double dDaysInYear365 = 365;
        internal const double dDaysInYear366 = 366;
        internal const double dDaysInYear = dDaysInYear36525;
        internal const double dMonthsInYear = 12;
        internal const double dCrossOverYear = 20; //ie if YY=20 is entered use 1900+20, if YY=19 use 1900+100+19
        internal const double dCrossOverCentury = 1900;

        //Age Service Max Mins
        internal static DateTime dtMinDate = new DateTime(1900, 1, 1); //Used in AgeServiceEngine
        internal static DateTime dtMaxDate = new DateTime(2200, 1, 1); //Used in AgeServiceEngine

        //MemRec variables
        internal static string sMRFrom = "From";
        internal static string sMRTo = "To";
        internal static string sMRID = "ID";
        internal static string sMRNew = "New"; // Key workd for "new" members in member reconciliation
        internal static string sMRMissing = "Missing"; // Key workd for "missing" members in member reconciliation

        //CARE variables
        internal static double dCAREMinNPA = 55;
        internal static double dCAREMaxNPA = 75;
        internal static double dCAREMinSalary = 0;
        internal static double dCAREMaxSalary = 150000;
        internal static double dCAREMinAccrualRate = 0;
        internal static double dCAREMaxAccrualRate = 0.15;
        internal static double dCAREMinInfl = -0.25;
        internal static double dCAREMaxInfl = 0.25;
        internal static double dCAREMinJPen = -0.25;
        internal static double dCAREMaxJPen = 0.25;
        internal static double dCAREMinJAct = -0.25;
        internal static double dCAREMaxJAct = 0.25;


    }
}