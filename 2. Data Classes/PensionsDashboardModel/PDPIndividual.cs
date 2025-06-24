//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************

using System;
using System.Collections.Generic;


namespace PTXClassLibrary
{
    /// <summary>
    /// This class is use to hold data about each of the Pension Dashboard Data Items
    /// This is only to be used for demonstration purposes, in reality Each member identified in Part 1 could have 1..* of thr Step 2 Benefits
    /// https://www.pensionsdashboardsprogramme.org.uk/2020/12/15/data-standards-guide/
    /// PDF Dec 2020
    /// This contains a list of member data that can be stored for each member according the the elements defined in the PDP model
    /// Basically 65 items referred 
    /// In each variable name the PTX_reference refers to the table name and the #.### refers to the mapping to the PDP variable refnum
    /// </summary>

    public class Individual_PDP
    {
        //Errors
        public string sError { get; set; }
        public double dError { get; set; }

        //Contains Infos about this class and a description 
        public string PDPStandardDataElementDescription { get; set; }

        //PDP Statement
        public string PDPStatement { get; set; }


        #region Step 1 Matching - Variables
        /// <summary>
        /// This part of the class describes the Individual details that are stored and used for matching, the PeI must match 
        /// (1.001	1.002	1.003	1.004	1.005	1.006	1.007	1.008	1.009	1.01	1.011	1.012	1.013	1.014	1.015	1.016	1.017	1.018	1.019	1.02	1.021)
        // </summary>

        //Individual UID eg         INDfe82f-03aa-4ce9-ad5c-711945422208
        public string PTX_Individual_PDP_UID { get; set; } = "Not Found";
        //Simple string list of pension UID eg PEN2b4aa-7ce6-4622-b4fd-b82000b936df
        public List<string> PDP_PeI_PensionList = new List<string>();

        //Calculated count of pensions based on string
        public int PDP_PeI_PensionCount { get; set; }

        public PDPName Name { get; set; }
        /*{
            get { return Name; }
            set { Name = new PDPName(); }
        }
        */
        /*
         * PDPClass: Name
         * PTX_GivenName	    1.001
         * PTX_Name	            1.002
         * PTX_AlternateNameType		1.006
         * PTX_AlternateName    1.007
         * PTX_AlternateNameAssertion	1.008
       */
        public GenNINO NINO { get; set; }
        /*
         * PTXClass: GenNINO
         * PTX_NINO	    1.004
         * PTX_NINOAssertion    1.005          
         */

        //public System.DateTime DOB { get; set; }
        public DateTime DOB { get; set; }
        /*
         * PTX_DOB	1.003
        */

        public GenAddress Address { get; set; }
        /*
         * PTXClass: GenAddress
         * PTX_AddressType	1.009
         * PTX_AddressLine1	1.01
         * PTX_AddressLine2	1.011
         * TX_AddressLine3	1.012
         * PTX_AddressLine4	1.013
         * PTX_AddressLine5	1.014
         * PTX_CountryCodeISO	1.016, Address Based on List	
         * PTX_AddressAssertion	1.017
        */

        public GenEmail Email { get; set; }
        /*
         * PTXClass: GenEmail
         * PTX_Email	1.018
         * PTX_EmailAssertioN   1.019
        */

        public GenPhone Phones { get; set; }
        /*
         * TO BE UPDATED Phone[] ??
         * PTXClass: GenPhone  
         * PTX_MobileNumber	    1.02
         * PTX_MobileAssertion  1.021
        */
        #endregion


        #region Class Methods

        //Allowable ref number are stored in he list             PDPRefNumberList
        //Constructor to return the Data Element by refNumber 
        public Individual_PDP()
        {

            PDPStatement = "This information is based on the document Data Standards Guide, Dec 2020 produced by the Pensions Dashboard Programme.  " +
            "Whilst all reasonable efforts have been made to ensure the accuracy of this website, errors may sometimes occur.  Please report any issues to RPM IT Consulting as soon as possible.  RPM IT Consulting accepts no liability arising from inaccuracies or omissions in this this website, blog and attached documents, and reserves the right to revise the contents without Notice.";

            //IMPORTANT
            //Instantiate class

            Name = new PDPName();
            NINO = new GenNINO();
            Email = new GenEmail();
            Address = new GenAddress();
            Phones = new GenPhone();

            //List



        }

        #endregion

        ///Why is all this here?
        ///xxx
        #region PDPERI
        /// <summary>
        /// Specific class for ERI  Data for Pensions Dashboard
        /// </summary>
        public class PDPERI
        {

            /*
             * 2.301	2.### View	2.3## Estimated Retirement Income (ERI) Data	ERI type	To indicate to the individual the type of pension generating the retirement income	ErrMessage of pension generating the retirement income eg DC. To allow dashboards to signpost information to the dashboard user	Text	2	3	Free format	Yes		Mandatory	Mandatory	1..1
             * 2.302	2.### View	2.3## Estimated Retirement Income (ERI) Data	ERI basis	To indicate to the individual with the basis on which their ERI has been calculated	A code representing the basis of calculation for the ERI to enable the dashboard to explain the basis of calculation	Text	1	4	Free format	No		Mandatory	Mandatory	1..1
             * 2.303	2.### View	2.3## Estimated Retirement Income (ERI) Data	ERI calculation date	To provide the individual with the date the ERI was calculated to show how current the value is. For example this date could be the last benefit statement issue date	The date the ERI was calculated	Date	1	8	YYYY-MM-DD ISO 8601 – numeric representation of date	No	Must be a valid date ie - a valid month - a number of days that is valid for the month - inclusion of 29 February if a leap year	Mandatory	Mandatory	1..
             * 2.304	2.### View	2.3## Estimated Retirement Income (ERI) Data	ERI payable date	To provide the individual with the date it is assumed the ERI will be paid from	The date the ERI is payable from	Date	1	8	YYYY-MM-DD ISO 8601 – numeric representation of date	No	Must be a valid date ie - a valid month - a number of days that is valid for the month - inclusion of 29 February if a leap year	Mandatory	Mandatory	1. .
             * 2.305	2.### View	2.3## Estimated Retirement Income (ERI) Data	ERI amount	To provide the individual with the amount of the ERI in GBP	Estimated retirement income amount	Decimal	1	16	-	No	Must be an annual income if the benefit is a regular amount. For ERI types DBL and CDL this amount will be a single lumpsum	Mandatory	Mandatory	1..
             * 2.306	2.### View	2.3## Estimated Retirement Income (ERI) Data	ERI pot	To provide the individual with the amount of the estimated DC pot that the estimated retirement income in 2.305 is calculated from (GBP)	Estimated retirement pot used to calculate the estimated retirement income	Decimal	1	16	-	No		Conditional	Conditional - if available and relevant (eg for DC pensions) this should be provided.	1..
             * 2.307	2.### View	2.3## Estimated Retirement Income (ERI) Data	ERI safeguarded benefits	To indicate to the individual that their accrued pension has safeguarded benefits. Pension providers should assess whether the pension has safeguarded benefits in order to determine whether to return a 1 or 0 for this data element	The individual’s pension has safeguarded benefits (see Notes below)	Boolean	1	1	-	Yes		Mandatory	Mandatory – Default to 0	1..
             * 2.308	2.### View	2.3## Estimated Retirement Income (ERI) Data	ERI unavailable	To explain to an individual why an ERI is Not available	Provide a reason for an ERI Not being available from a set list of reasons	Text	1	4	-	Yes		Conditional	Conditional - if the ERI amount has Not been provided then this must be included	0..1
            */

            public string ERIType { get; set; }
            public string ERIBasis { get; set; }
            public DateTime ERICalcDate { get; set; }
            public DateTime ERIPayableDate { get; set; }
            public string ERIAmount { get; set; }
            public string ERIPot { get; set; }
            public string ERISafeguardedBenefits { get; set; }
            public string ERIUnavailable { get; set; }
        }
        #endregion

        #region PDPAdditionalData
        /// <summary>
        /// Specific class for AdditionalData Data for Pensions Dashboard
        /// </summary>
        public class PDPAdditionalData
        {

            /*
             * PTX_CostsAndCharges
             * SIPURL
             * ImplementationStatementURL
             * #AnnualReportURL
             * 
             * 2.501	2.### View	2.5## Additional Data (Signposts)	Costs and charges	To allow the individual to access general cost and charges information that relate to their pensions	Website URL where information on costs and charges relating to DC pension can be found	Text
             * 2.502	2.### View	2.5## Additional Data (Signposts)	SIP URL	To allow the individual to access the statement of investment principles that relate to their pensions	Website URL where the statement of investment principles can be found	Text
             * 2.503	2.### View	2.5## Additional Data (Signposts)	Implementation statement URL	To allow the individual to access the implementation statement that relate to their pensions	Website URL where the implementation statement can be found	Text
             * 2.504	2.### View	2.5## Additional Data (Signposts)	Annual report URL	To allow the individual to access the annual report of the independent governance committee	Website URL where the annual report of the independent governance can be found	Text
            */
            public string CostsAndCharges { get; set; }
            public string SIPURL { get; set; }
            public string ImplementationStatementURL { get; set; }
            public string AnnualReportURL { get; set; }

            //Constructor
            public PDPAdditionalData()
            {
            }

        }
        #endregion

        #region PDPAccruedPensionData
        /// <summary>
        /// Specific class for Accrued Pensions Data for Pensions Dashboard
        /// </summary>
        public class PDPAccruedPensionData
        {

            /*
             * AccruedType
             * AccruedAmountType
             * AccruedPayableDate
             * AccruedAmount
             * AccruedSafeguardedBenefits
             * AccruedUnavailable
             * CostsAndCharges
             * 
             * 2.401	2.### View	2.4## Accrued Pension Data	Accrued type	To indicate to the individual the type of the accrued pension information	ErrMessage of accrued pension information eg DC	Text
             * 2.402	2.### View	2.4## Accrued Pension Data	Accrued amount type	To provide the individual with the basis of their accrued pension amount	A code representing the basis of calculation for the accrued amount	Text
             * 2.403	2.### View	2.4## Accrued Pension Data	Accrued calculation date	To provide the individual with the effective date of the amount	The date the pension is payable from	Date
             * 2.404	2.### View	2.4## Accrued Pension Data	Accrued payable date	To provide the individual with the date the pension is likely to be payable from	The date the pension is payable from	Date
             * 2.405	2.### View	2.4## Accrued Pension Data	Accrued amount	To provide the individual with the value of their accrued pension either as an income (for DB benefits) or a pot value(for DC)	Accrued pension as at the calculation date	Decimal
             * 2.406	2.### View	2.4## Accrued Pension Data	Accrued safeguarded benefits	To indicate to the individual that their accrued pension has safeguarded benefits. Pension providers should assess whether the pension has safeguarded benefits in order to determine whether to return a 1 or 0 for this data element	The individual’s pension has safeguarded benefits	Boolean
             * 2.407	2.### View	2.4## Accrued Pension Data	Accrued unavailable	To explain to an individual why an accrued pension amount is Not available	Provide a reason for an accrued pension amount Not being available from a set list of reasons	Text
            */
            public string AccruedType { get; set; }
            public string AccruedAmountType { get; set; }
            public DateTime AccruedCalcDate { get; set; }
            public DateTime AccruedPayableDate { get; set; }
            public string AccruedAmount { get; set; }
            public string AccruedSafeguardedBenefits { get; set; }
            public string AccruedUnavailable { get; set; }
            public string CostsAndCharges { get; set; }

            //Constructor
            public PDPAccruedPensionData()
            {
            }

        }
        #endregion


    }
}