//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************

using System.Collections.Generic;

namespace PTXClassLibrary
{

    //List all Global Variables used int PTXClassLibrary

    public class ErrorMessages : PTXGlobals
    {


        //Error Checking
        public const string ewmOK = "#OK";
        public const string ewmError = "#Err";
        public const string ewmWarning = "#War";
        public const string ewmInfo = "#Info";
        public const string ewmNA = "#NA";
        public const string ewmNotMatched = "#NotMatched";
        public const string ewmUpdate = "#Upd";
        public const string ewmNotFound = "#NotFound";
        public const string ewmMissing = "#Missing";
        public const string ewmEmpty = "#Empty";
        public const string ewmPass = "#Pass";
        public const string ewmFail = "#Fail";


        //Data Handling
        //Source Data Prefix
        internal const string dataSrc = "src";
        internal const string dataPTX = "ptx";
        internal const string dataAdmin = "adm";
        internal const string dataDB = "db";
        internal const string dataWeb = "www";


        //Errors and coded
        //To be properly documented
        internal const double dErrAgeNotInRange = -199999991; //An Age is Not in the range of the other 1D Dec Tables


        //Construct of error IIIFFFVVVCCC
        //Lever 1 - GGG = Function Group/Class code eg interface
        //Lever 2 - FFF = function code, dErrF ... 
        //Lever 3 - VVV = Variable Error, dErrV ... 
        //Lever 4 - CCC = Condition Of Failure, dErrC ...

        /*List of GGG, Level 1 
        -001FFFVVVCCC = Interface - Class : CalcsInterface
        -006FFFVVVCCC = ENGINE - Class : CalcsEngine


        -002FFFVVVCCC = TABLES - Class : Table Reader
        -003FFFVVVCCC = TABLES - Class : Act1dTable
        -075FFFVVVCCC = INTERFACE - Class : TableInterface

        
        -005FFFVVVCCC = INTERFACE - Class : AgeServiceInterface
        -004FFFVVVCCC = ENGINE - Class : AgeServiceEngine
        
        -010FFFVVVCCC = ENGINE - Class : StatePension
        -011FFFVVVCCC = INTERFACE - Class : StatePensionDate

        -007FFFVVVCCC = INTERFACE - Class : ProjectionInterface
        -008FFFVVVCCC = ENGINE - Class : ProjectionEngine

        -009FFFVVVCCC = SECURITY - Class : WebSecurity

        -099FFFVVVCCC = API - Multiple classes folder PTX_Functions

        -020FFFVVVCCC = DATAChecks

        */


        //FFF = function codes
        //For Calc INTERFACE Function Errors use FFF=-001fff, 
        //Class "CalcsInterface"
        internal const double dErrFAJL = -001001000000;
        internal const string sErrFAJL = "AJL";
        internal const double dErrfnASL = -001002000000;
        internal const string sErrfnASL = "ASL";
        internal const double dErrfnANC = -001003000000;
        internal const string sErrfnANC = "ANC";
        internal const double dErrFAREV = -001004000000;
        internal const string sErrFAREV = "AREV";
        internal const double dErrFAREVTP = -001005000000;
        internal const string sErrFAREVTP = "AREVTP";
        //internal const double dErrfnASL = -001006000000;
        //internal const string sErrfnASL = "ASL";
        internal const double dErrfnATP = -001007000000;
        internal const string sErrfnATP = "ATP";
        internal const double dErrfnDOND = -001008000000;
        internal const string sErrfnDOND = "DOND";
        internal const double dErrfnLONL = -001009000000;
        internal const string sErrfnLONL = "LONL";
        internal const double dErrFTA = -001010000000;
        internal const string sErrFTA = "TA";
        internal const double dErrfnVN = -001011000000;
        internal const string sErrfnVN = "VN";
        internal const double dErrFACONT = -001012000000;
        internal const string sErrFACONT = "ACONT";
        internal const double dErrGetarrDIList = -001013000000;
        internal const string sErrGetarrDIList = "GetarrDIList";

        //For Calcs ENGINE Function Errors use FFF=-006fff
        internal const double dErrFAJL_Engine = -006001000000;
        internal const string sErrFAJL_Engine = "AJL_Engine";
        internal const double dErrfnASL_Engine = -006002000000;
        internal const string sErrfnASL_Engine = "ASL_Engine";
        internal const double dErrfnANC_Engine = -006003000000;
        internal const string sErrfnANC_Engine = "ANC_Engine";
        internal const double dErrFAREV_Engine = -006004000000;
        internal const string sErrFAREV_Engine = "AREV_Engine";
        internal const double dErrFAREVTP_Engine = -006005000000;
        internal const string sErrFAREVTP_Engine = "AREVTP_Engine";
        //internal const double dErrfnASL_Engine = -006006000000;
        //internal const string sErrfnASL_Engine = "ASL_Engine";
        internal const double dErrfnATP_Engine = -006007000000;
        internal const string sErrfnATP_Engine = "ATP_Engine";
        internal const double dErrfnDOND_Engine = -006008000000;
        internal const string sErrfnDOND_Engine = "DOND_Engine";
        internal const double dErrfnLONL_Engine = -006009000000;
        internal const string sErrfnLONL_Engine = "LONL_Engine";
        internal const double dErrFTA_Engine = -006010000000;
        internal const string sErrFTA_Engine = "TA_Engine";
        internal const double dErrfnVN_Engine = -006011000000;
        internal const string sErrfnVN_Engine = "VN_Engine";
        internal const double dErrFACONT_Engine = -006012000000;
        internal const string sErrFACONT_Engine = "ACONT_Engine";
        internal const double dErrFREV_Engine = -006013000000;
        internal const string sErrFREV_Engine = "AREV_Engine";


        //Top level Error always
        //For Read Function Errors use FFF=-002fff
        //Class "TableReader"
        internal const double dErrFRead = -002000000000; //File cannot be read in, general FAIL get rod of XXX
        internal const double dErrFReadAllData = -002001000000;  //
        internal const string sErrFReadAllData = "Reader_ReadAllData";

        //Top level Error always
        //For Act1DTable Function Errors use FFF=-003fff,
        //Class "Act1DTable"
        internal const double dErrFDi = -003001000000; //Error with a DI newValue

        //Top level Error always
        //For AgeService ENGINE Function Errors use FFF=-004fff
        //Class "AgeService"
        internal const double dErrFAgeService_Engine = -004001000000; //
        internal const string sErrFAgeService_Engine = "AgeService_Engine";

        //Top level Error always
        //For StatePension ENGINE Function Errors use FFF=-010fff
        //Class "StatePension"
        internal const double dErrFStatePension_Engine = -010001000000; //
        internal const string sErrFStatePension_Engine = "StatePensionDate_Engine";

        //Top level Error always
        //For StatePensionDate INTERFACE Function Errors use FFF=-011fff
        //Class "StatePensionDate"
        internal const double dErrFStatePensionDate = -011001000000; //
        internal const string sErrFStatePensionDate = "StatePensionDate";
        internal const double dErrFStatePensionDateFuture = -011002000000; //
        internal const string sErrFStatePensionDateFuture = "StatePensionDateFuture";




        //Top level Error always
        //For Tables INTERFACE Function Errors use FFF=-075fff
        //Class "TableInterface"
        internal const double dErrFTables = -075001000000; //
        internal const string sErrFTables = "Tables";


        //For AgeService INTERFACE Function Errors use FFF=-005fff
        //Class "AgeServiceInterface"
        internal const double dErrfnAgeCompD = -005001000000; //
        internal const string sErrfnAgeCompD = "AgeCompD";
        internal const double dErrfnAgeCompM = -005002000000; //
        internal const string sErrfnAgeCompM = "AgeCompM";
        internal const double dErrfnAgeCompY = -005003000000; //
        internal const string sErrfnAgeCompY = "AgeCompY";
        internal const double dErrfnServCompD = -005004000000; //
        internal const string sErrfnServCompD = "ServCompD";
        internal const double dErrfnServCompM = -005005000000; //
        internal const string sErrfnServCompM = "ServCompM";
        internal const double dErrfnServCompY = -005006000000; //
        internal const string sErrfnServCompY = "ServCompY";
        internal const double dErrFAgeServiceNET = -005007000000; //
        internal const string sErrFAgeServiceNET = "AgeServiceNET";

        internal const double dErrFStringToDateTime = -005008000000; // USed with Age Service Interface
        internal const string sErrFStringToDateTime = "StringToDateTime";

        //For ProjectionsEngine issues ( FFF=-008fff)
        //Class "ProjectionEngine"
        //-008FFFVVVCCC = ENGINE - Class : ProjectionEngine
        //ADD FUCNTION NAMES HERE
        //internal const double dProjectBenefitsSimple = -00001000000; //
        //internal const string sProjectBenefitsSimple = "ProjectBenefitsSimple";



        //For ProjectionsEngine issues ( FFF=-007fff)
        //Class "ProjectionInterface"
        //-007FFFVVVCCC = INTERFACE - Class : ProjectionInterface
        internal const double dErrfnProjectBenefitsSimple = -007001000000; //
        internal const string sErrfnProjectBenefitsSimple = "ProjectBenefitsSimple";
        internal const double dErrfnProjectSalarySimple = -007002000000; //
        internal const string sErrfnProjectSalarySimple = "ProjectSalarySimple";

        //For GMP issues ( FFF=-111fff)
        //Class "GMP" [Interface]
        internal const double dErrnGMPInterface = -111000000000;
        internal const string sErrGMPInterface = "#Err in GMP Interface"; //General Error
        internal const double dErrnGMPInterface_GMPUplift = -111001000000;
        internal const string sErrGMPInterface_GMPUplift = "#Err in GMP Uplift Interface"; //General Error
        internal const double dErrnGMPInterface_GMPXSReval = -111002000000;
        internal const string sErrGMPInterface_GMPXSReval = "#Err in GMP XS Revals Interface"; //General Error

        //For GMP issues ( FFF=-112fff)
        //Class "GMP" [Engine]
        internal const double dErrnGMPEngine = -112000000000;
        internal const string sErrGMPEngine = "#Err in GMP Interface"; //General Error
        internal const double dErrnGMPEngine_GMPUplift = -112001000000;
        internal const string sErrGMPEngine_GMPUplift = "#Err in GMP Uplift Engine";
        internal const double dErrnGMPEngine_GMPXSReval = -112002000000;
        internal const string sErrGMPEngine_GMPXSReval = "#Err in GMP XS Revals Engine";

        //For Web Security issues ( FFF=-009fff)
        //Class "WebSecurity"
        internal const double dErrFWebConfrimID = -009000000000;
        internal const string sErrFWebConfrimID = "ERROR General Error in WebSecurity : WebConfrimID"; //General Error
        internal const double dErrFWebSecurityFailed = -009000999999;
        internal const string sErrFWebSecurityFailed = "Security Failed"; //General Error


        //For API Function Errors use FFF=-099fff
        //Various classes in API layer"
        //Could add more error codes, but just one default one for now
        internal const double dErrAPI = -099000000000; //
        internal const string sErrAPI = "APIError";
        internal const double dErrAPIInputs = -099000001000; //
        internal const string sErrAPIInputs = "API Error-Incorrect Inputs or Format";

        internal const double dErrAPICalcs = -099000002000; //
        internal const string sErrAPICalcs = "API Error-Calcs error";

        internal const double dErrAPIJSon = -099000003000; //
        internal const string sErrAPIJSon = "API Error-Json serialisation error";

        //For API Function Errors use FFF=-020fff
        //Various data checks
        //Could add more error codes, but just one default one for now
        internal const double dErrDataCheck = -020000000000; //
        internal const string sErrDataCheck = "Data Check Error";



        // 2nd Level Error
        //VVV = Variable Error
        internal const double dErrVAge = -000000001000;
        internal const string sErrVAge = "Age";
        internal const double dErrVTerm = -000000002000;
        internal const string sErrVTerm = "Term";
        internal const double dErrVGTee = -000000003000;
        internal const string sErrVGTee = "GTee";
        internal const double dErrVI = -000000004000;
        internal const string sErrVI = "I Rate";
        internal const double dErrVJ = -000000005000;
        internal const string sErrVJ = "J Rate";
        internal const double dErrVMortRate1 = -000000006000;
        internal const string sErrVMortRate1 = "MortRate1";
        internal const double dErrVMortRate2 = -000000007000;
        internal const string sErrVMortRate2 = "MortRate2";
        internal const double dErrVMortWeight1 = -000000008000;
        internal const string sErrVMortWeight1 = "MortWeight1";
        internal const double dErrVMortWeight2 = -000000009000;
        internal const string sErrVMortWeight2 = "MortWeight2";
        internal const double dErrVADiff = -000000010000;
        internal const string sErrVADiff = "ADiff";
        internal const double dErrVTermGTee = -000000011000;
        internal const string sErrVTermGTee = "Term and GTee";
        internal const double dErrVMort = -000000012000;
        internal const string sErrVMort = "Mortality Table";

        //Generally Used with Read functions
        internal const double dErrVDataRead = -000000013000;
        internal const string sErrVDataRead = "Check Data"; // Use with
        internal const double dErrVFile = -000000014000;
        internal const string sErrVFile = "File Not Found"; // Use with dErrFRead
        internal const double dErrVMort2 = -000000015000;
        internal const string sErrVMort2 = "2nd Life Mortality Table";

        //Generally used with Act1DTable values
        internal const double dErrVDi = -000000016000;
        internal const string sErrVDi = "Error with class DI value"; // Could be used with lees than min/max  or some specific rule

        //DateTime
        internal const double dErrVdt = -000000017000;
        internal const string sErrVdt = "DateTime Error"; // Could be used with lees than min/max  or some specific rule

        //Sex
        internal const string sErrSex = "Incorrect Sex Format (M/F)";

        //Generic
        internal const string sNotInRange = "Not in valid range";
        internal const string sGeneralFailure = "Failed";

        // 3rd Level Error
        //CCC = Condition Of Failure if in hundreds specific to a function.
        internal const double dErrCLTMin = -000000000001;
        internal const string sErrCLTMin = "Variable Less Than Min newValue";
        internal const double dErrCGTMax = -000000000002;
        internal const string sErrCGTMax = "Variable More Than Max newValue";
        internal const double dErrCIntegerDouble = -000000000003;
        internal const string sErrCIntegerDouble = "Expecting Integer got double";
        internal const double dErrCDoubleInteger = -000000000004;
        internal const string sErrCDoubleInteger = "Expecting Double got Integer";
        internal const double dErrCIntegerString = -000000000005;
        internal const string sErrCIntegerString = "Expecting Integer got String";
        internal const double dErrCDoubleString = -000000000006;
        internal const string sErrCDoubleString = "Expecting Double got String";

        //Generally Used with Read functions
        internal const double dErrCInvalidTable = -000000000007;
        internal const string sErrCInvalidTable = "Table has been set to Invalid";

        internal const double dErrCTermLTGTee = -000000000008;   // Specific for term and Gtee variables
        internal const string sErrCTermLTGTee = "Term less that GTee";

        internal const double dErrCDivZero = -000000000009;
        internal const string sErrCDivZero = "newValue is equal to Zero, DivZero Error";

        //AgeService Functions, use DateTime
        internal const double dErrCDate1GTDate2 = -000000000010;
        internal const string sErrCDate1GTDate2 = "Date 2 is prior to Date 1";
        internal const double dErrCDateInValid = -000000000011;
        internal const string sErrCDateInValid = "Date is incorrect format";
        internal const double dErrCAge1GTAge2 = -000000000012;
        internal const string sErrCAge1GTAge2 = "Age 2 is prior or equal to to Age 1";
        internal const double dErrCAge1GTEge2 = -000000000014;
        internal const string sErrCAge1GTEAge2 = "Age 2 is prior to Age 1";
        internal const double dErrDDandMMAreValidDate = -000000000013;
        internal const string sErrDDandMMAreValidDate = "MM and DD combination are not a proper date.  ";



        /// <summary>
        /// Gets the background color based on code or EWM status.
        /// Resource : https://www.colorhexa.com/cc0000
        /// </summary>
        /// <param name="ewmOrCode">The EWM status.</param>
        /// <returns>The background color in hex.</returns>
        public static string GetBackgroundColourEWMCode(string ewmOrCode)
        {
            Dictionary<string, string> colorMappings = new Dictionary<string, string>
            {
                  { ErrorMessages.ewmPass, "#00FF00" },       // Android Green in hex
                { ErrorMessages.ewmOK, "#00FF00" },       // Android Green in hex
                { ErrorMessages.ewmUpdate,       "#008000" }, // Dark Green in hex
                { ErrorMessages.ewmWarning, "#FFFF99" },      // Banana Yellow in hex
                
                { ErrorMessages.ewmError, "#ff8181" },      // Boston University Red in hex
                { ErrorMessages.ewmFail, "#ff8181" },      // Boston University Red in hex
                { ErrorMessages.ewmInfo, "#3399FF" },     // Info Blue in hex

                { "QTE", "#ee82ee" },             // Quotation (double quotes)
                { "StQTE", "#f198f1" },                  // Start of quotation (double quotes)
                { "EndQTE", "#f7c5f7" },      // End of quotation (double quotes)

                { "Control", PTXGlobals.colRed },                 // Control character
                
                { "Eol", "#c081ff" },          // End of Line
                { "CRNL", "#ffc081" },                 // Carriage Return + New Line in quotations
                { "NL", "#ffc081" },                   // New Line in quotations
                { "CR", "#ffc081" },                   // Carriage Return in quotations
                
                { "Tab", "ultraviolet" },           // Tab character
                { "Comma", "palevioletred" },         // Comma character
                                                      //
                                                      //
                { "delimTab", "#81ffc0" },               // Delimiter Tab
                { "delimComma", "#81ffc0" },             // Delimiter Comma
                 { "delim", "#82ffc0" },             // Delimiter Comma

                { "Curr", "#ffff81" },                 // Currency symbol at start/end
                { "Pct", "#feef81" },                 // % symbol at end
                { "#ErrCommaOutsideQoutes", PTXGlobals.colRed },                 // % Commasymbol at end
                
            };

            // Check if the ewmOrCode exists in the dictionary
            if (colorMappings.ContainsKey(ewmOrCode))
            {
                return colorMappings[ewmOrCode];
            }

            // Default background color if none of the conditions match
            return "transparent";
        }
    }
}