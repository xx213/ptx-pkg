//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************


using System;

namespace PTXClassLibrary
{
    [Serializable]
    public class OE_ReturnX
    {


        //Simple data container class, to return values for the MyCSP Options exercise web function 
        //public string[] KnownLanguages = { "C#", "Java", "Perl" };
        //Format
        //Description	Name	type	format	Example	newValue on error	Typical UI representation

        //Error message	strError	string	Limited to 256 characters	Date Of birth is out of range	Error message	String, warning message	
        public string strError { get; set; }
        //Standard Pension, used	dPension	double		15000	0	Currency, £	
        public string dayTaperDate { get; set; }
        //Part 2 NPA	strP2NPA	double		65.083333	0	years and months eg 65y 1m	
        public string strP2NPA;
        //Part 1 NPA	strP1NPA	double		65	0	years and months eg 65y 1m	
        public string strP1NPA;
        //State Pension Date	daySPD	string	dd/mm/yyyy	01/01/2025	BLANK	Date	
        public string daySPD;
        //Day 1, date for option 2	dayDay1	string	dd/mm/yyyy	42095	
        public string dayDay1;
        //Age at taper date, option 1	dTaperAgeOpt1	double		45.41666667	0	years and months eg 45y 1m
        public double dTaperAgeOpt1;
        //Age at taper date, option 2	dTaperAgeOpt2	double		47.08333333	0	years and months eg 45y 1m
        public double dTaperAgeOpt2;
        //State Pension Age, returned as Year and remainder of months, a multiple of 1/12.  Remainder will be rounded to 4dp.	dSPA	double	##.##	eg 65.0833,65.1667,65.25,65.3333,65.4167,65.5,65.5833,65.6667,65.75,65.8333,65.9167,66	0	65Y4M
        public double dSPA;
        //User selected pension age.	dPA	double	eg 65.0833
        public double dPA;

        //Array used in Pension commutation tables for options 1 and 2
        // arrComm[]	doubles, 3 columns, 101 rows		
        //Col 0 is percentage of Commuted pension
        //Col 1 is Residual pension,
        //Col 2 is Commuted pension
        //Col 3 is Part 1 Residual Pension	
        //Col 4 Part 1 Lump Sum	
        //Col 5 is Part 2 Residual Pension	
        //Col 6 is Part 2 Lump Sum

        // Max allowable pension is arrComm[1,0]
        // Min allowable pension is arrComm[1,100]
        // Max allowable cash is arrComm[2,100]
        // Min allowable cash is arrComm[1,0]

        //RPM 020221
        //public double[,] arrCommOpt1x = new double[7, 101];
        //public double[,] arrCommOpt2x = new double[7, 101];


        public double[][] arrCommOpt1 { get; set; } = new double[7][];
        public double[][] arrCommOpt2 = new double[7][];






        //Overload to return an Error
        public OE_ReturnX()
        {
            strError = "";
            dayTaperDate = "";
            strP2NPA = "";
            strP1NPA = "";
            dSPA = 0;
            dPA = 0;
            daySPD = "";
            dayDay1 = "";
            dTaperAgeOpt1 = 0;
            dTaperAgeOpt2 = 0;

            for (int iCol = 0; iCol < 7; iCol++)
            {
                arrCommOpt1[iCol] = new double[101];
                arrCommOpt2[iCol] = new double[101];
                for (int iRow = 0; iRow < 101; iRow++)
                {
                    arrCommOpt1[iCol][iRow] = 0;
                    arrCommOpt2[iCol][iRow] = 0;
                }
            }
        }


        //Overload to return an Error
        internal OE_ReturnX(string strErrorType)
        {
            strError = strErrorType;
            dayTaperDate = "";
            strP2NPA = "";
            strP1NPA = "";
            dSPA = 0;
            dPA = 0;
            daySPD = "";
            dayDay1 = "";
            dTaperAgeOpt1 = 0;
            dTaperAgeOpt2 = 0;

            for (int iCol = 0; iCol < 7; iCol++)
            {
                arrCommOpt1[iCol] = new double[101];
                arrCommOpt2[iCol] = new double[101];
                for (int iRow = 0; iRow < 101; iRow++)
                {
                    arrCommOpt1[iCol][iRow] = 0;
                    arrCommOpt2[iCol][iRow] = 0;
                }
            }
        }
    }

    [Serializable]
    //TODo  --  Add new function that returns a string for XML
    public class OE_ReturnCollectionX
    {
        //Simple data container class, return a collection of OE_return objects 
        //Format : array of 22 OE_Return classes at each age from 55to75 + SPA
        public OE_ReturnX[] OEReturnDataArrayX { get; set; } = new OE_ReturnX[MyCSPGlobals.iOE_MaxNPA - MyCSPGlobals.iOE_MinNPA + 2];

        public OE_ReturnCollectionX()
        {
            for (int i = 0; i <= MyCSPGlobals.iOE_MaxNPA - MyCSPGlobals.iOE_MinNPA + 1; i++)
            {
                //Starts at age 55 = MyCSPGlobals.iOE_MaxNPA 
                OEReturnDataArrayX[i] = new OE_ReturnX();
            }
        }


        internal OE_ReturnCollectionX(string strErrorType)
        {
            for (int i = 0; i <= MyCSPGlobals.iOE_MaxNPA - MyCSPGlobals.iOE_MinNPA + 1; i++)
            {
                //Starts at age 55 = MyCSPGlobals.iOE_MaxNPA 
                OEReturnDataArrayX[i] = new OE_ReturnX(strErrorType);
            }
        }

        //Return OE_Return Object, uses integers 55-75 or string "SPA"
        public OE_ReturnX OE_Data(int iOE_NPA)
        {
            OE_ReturnX OERet = new OE_ReturnX("Not Found");
            try
            {
                //Convert age to index
                if (iOE_NPA < MyCSPGlobals.iOE_MinNPA || iOE_NPA > MyCSPGlobals.iOE_MaxNPA) { OERet = new OE_ReturnX("NPA out of range"); }
                OERet = OEReturnDataArrayX[iOE_NPA - MyCSPGlobals.iOE_MinNPA];
            }
            catch
            { }
            return OERet;
        }
        //Overloaded
        public OE_ReturnX OE_Data(string strOE_NPA)
        {
            OE_ReturnX OERet = new OE_ReturnX("Not Found");
            try
            {
                //if SPA get index 21
                if (strOE_NPA == "SPA") { OERet = OEReturnDataArrayX[MyCSPGlobals.iOE_MaxNPA - MyCSPGlobals.iOE_MinNPA + 1]; }
                else { OERet = new OE_ReturnX("NPA out of range"); }
            }
            catch
            { }
            return OERet;
        }
    }
}

