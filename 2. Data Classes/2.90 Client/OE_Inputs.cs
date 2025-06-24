//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************

namespace PTXClassLibrary
{
    //Not MYCSP IC
    public class OE_Input
    {
        //Simple data container class, to return INPUT values for the miCSP Options exercise web function 
        //Data required as per function : 
        //        public static OE_ReturnCollection webOE_Calcs(string strSex, string dayDOB, string strP1,
        //                                                    int iReckServY, int iReckServD, int iReckServPre2002Y, int iReckServPre2002D, int iReckServPost2002Y, int iReckServPost2002D, 
        //                                                    double dPenEarn, double dCPI, double dSalGrowth, double dAccruedNuvosPen, double dContractedHours, double dStandardHours, string sID)

        public string sError;
        public string strSex;
        public string dayDOB;
        public string strP1;
        public int iReckServY;
        public int iReckServD;
        public int iReckServPre2002Y;
        public int iReckServPre2002D;
        public int iReckServPost2002Y;
        public int iReckServPost2002D;
        public double dPenEarn;
        //public double dCPI;
        //public double dSalGrowth;
        public double dAccruedNuvosPen;
        public double dContractedHours;
        public double dStandardHours;

        //Overload to return an Error
        public OE_Input()
        {
            sError = "";
            strSex = "";
            dayDOB = "";
            strP1 = "";
            iReckServY = 0;
            iReckServD = 0;
            iReckServPre2002D = 0;
            iReckServPre2002Y = 0;
            iReckServPost2002D = 0;
            iReckServPost2002Y = 0;
            dAccruedNuvosPen = 0;
            dContractedHours = 0;
            dStandardHours = 0;
            dPenEarn = 0;
        }


        //Overload to return an Error
        internal OE_Input(string strErrorType)
        {
            sError = strErrorType;
            strSex = "";
            dayDOB = "";
            strP1 = "";
            iReckServY = 0;
            iReckServD = 0;
            iReckServPre2002D = 0;
            iReckServPre2002Y = 0;
            iReckServPost2002D = 0;
            iReckServPost2002Y = 0;
            dAccruedNuvosPen = 0;
            dContractedHours = 0;
            dStandardHours = 0;
            dPenEarn = 0;
            PTXCalc_ConstructorCalcs();
        }

        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
            // Override this if required
        }
    }



}

