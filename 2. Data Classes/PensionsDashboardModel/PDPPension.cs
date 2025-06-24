//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************

using System;
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

    public class PDPPension
    {
        //Errors
        public string sError { get; set; }
        public double dError { get; set; }

        //Contains Infos about this class and a description 
        public string PDPStandardDataElementDescription { get; set; }

        //PDP Statement
        public string PDPStatement { get; set; }

        #region Step 2.0 Benefits - Variables
        /// <summary>
        /// This part of the class describes the benefits that are returned, the PeI must match
        /// </summary>
        /// 
        //Unique ref of PDPPension eg PENd8896-a298-4b33-98b6-4bdea1879d5f
        public string PDP_PeI_Benefit { get; set; }

        //Shows who the pension belongs to eg         INDfe82f-03aa-4ce9-ad5c-711945422208
        public string PTX_Individual_PDP_UID { get; set; }


        //This should be extended for a group  MULITPLE BLOCKS
        public PDPPensionArrangement PensionArrangement { get; set; }
        /*
        * PDPClass: DPDPensionArrangement
        * PTX_PensionReference  2.001
        * PTX_PensionName		2.002
        * PTX_PensionType		2.003
        * PTX_PensionOrigin		2.004
        * PTX_PensionStatus		2.005
        * PTX_PensionStartDate	2.006
        * PTX_PensionRetirementDate		2.007
        * PTX_PensionLink		2.008
       */



        public PensionAdministrator PensionAdministrator { get; set; }
        /*
         * PTXClass: PensionAdministrator : Organisation
         * PTX_AdministratorReference_UID	2.101
         * PTX_AdministratorName	Individual_PDP.Administrator	Organisation.Name	2.102
         * PTX_AdminContactPreference	Individual_PDP.Administrator	Organisation : Administrator	2.103
         * PTX_AdministratorEmail	Individual_PDP.Administrator	Organisation	2.105
         * Abstract Class Organisation : 
         * PTX_AdministratorPhoneNumber	Individual_PDP.Administrator	Org.phone[]	2.106
         * PTX_AdministratorPhoneNumberType	Individual_PDP.Administrator	Org.phone[]	2.107
         * PTX_AdministratorPostalName	Individual_PDP.Administrator		2.108
         * PTX_AdministratorAddressLine1	Individual_PDP.Administrator	Org.Address	2.109
         * PTX_AdministratorAddressLine2	Individual_PDP.Administrator	Org.Address	2.11
         * PTX_AdministratorAddressLine3	Individual_PDP.Administrator	Org.Address	2.111
         * PTX_AdministratorAddressLine4	Individual_PDP.Administrator	Org.Address	2.112
         * PTX_AdministratorAddressLine5	Individual_PDP.Administrator	Org.Address	2.113
         * PTX_AdministratorPostcode	Individual_PDP.Administrator	Org.Address	2.114
        */

        //This should be extended for a group
        //public List <Employer> Employers = new List <Employer> Employers();
        public Employer Employer { get; set; }
        /*
         * PTXClass : Employer : Organisation
         * Only requires employer name
         * PTX_EmployerName	        2.201
         * PTX_EmploymentStartDate	2.202
         * PTX_EmploymentEndDate	2.203
        */


        //This should be extended for a group  MULITPLE BLOCKS
        public PDPERI ERI { get; set; }
        /* 
         * PDPClass PDPERI
         * PTX_ERIType	PDPERI	PDPERI	2.301
         * PTX_ERIBasis	PDPERI		2.302
         * PTX_ERICalcDate	PDPERI		2.303
         * PTX_ERIPayableDate	PDPERI		2.304
         * PTX_ERIAmount	PDPERI		2.305
         * PTX_ERIPot	PDPERI		2.306
         * PTX_ERISafeguardedBenefits	PDPERI		2.307
         * PTX_ERIUnavailable	PDPERI		2.308
        */


        //This should be extended for a group  MULITPLE BLOCKS
        public PDPAccruedPensionData AccruedPensionData { get; set; }
        /*
         * PDPClass: PDPAccruedPensionData
         * PTX_AccruedType 		    2.401
         * PTX_AccruedAmountType	2.402
         * PTX_AccruedCalcDate   	2.402
         * PTX_AccruedCalcDate      2.403
         * PTX_AccruedPayableDate	2.404
         * PTX_AccruedAmount		2.405
         * PTX_AccruedSafeguardedBenefits   2.406
         * PTX_AccruedUnavailable			2.407
         */

        //This should be extended for a group  MULITPLE BLOCKS
        public PDPAdditionalData AdditionalData { get; set; }
        /*
         * PDPClass: PDPAdditionalData
         * PTX_CostsAndCharges  2.501
         * PTX_SIPURL	        2.502
         * PTX_ImplementationStatementURL		2.503
         * PTX_AnnualReportURL	2.504
        */
        #endregion

        public PDPSchemeBasis SchemeBasis { get; set; }
        /*
         * NPA, ERF, LRF, MinNPA, MaxNPA
         */



        #region Class Methods

        //Allowable ref number are stored in he list             PDPRefNumberList
        //Constructor to return the Data Element by refNumber 
        public PDPPension()
        {

            PDPStatement = "This information is based on the document Data Standards Guide, Dec 2020 produced by the Pensions Dashboard Programme.  " +
            "Whilst all reasonable efforts have been made to ensure the accuracy of this website, errors may sometimes occur.  Please report any issues to RPM IT Consulting as soon as possible.  RPM IT Consulting accepts no liability arising from inaccuracies or omissions in this this website, blog and attached documents, and reserves the right to revise the contents without Notice.";

            //IMPORTANT
            //Instantiate class

            PensionArrangement = new PDPPensionArrangement();
            PensionAdministrator = new PensionAdministrator();
            Employer = new Employer();
            ERI = new PDPERI();
            AccruedPensionData = new PDPAccruedPensionData();
            AdditionalData = new PDPAdditionalData();


        }

        #endregion

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

        #region PDPPensionArrangement
        /// <summary>
        /// Specific class for defining the PDP Pension arrangement for Pensions Dashboard
        /// </summary>
        public class PDPPensionArrangement
        {

            /*
             * PensionReference
             * PensionName
             * PensionType
             * PensionOrigin
             * PensionStatus
             * PensionStartDate
             * PensionRetirementDate
             * PensionLink
             * 
             * 2.001	2.### View	2.0## Pension Arrangement Data	Pension reference	To uniquely identify an individual’s pension within the pension arrangement	A unique reference number that connects the individual to the pension arrangement data. It could be their scheme/policy number but it does Not need to be as it could be a one-time 'quote this reference’ for an individual to use if they contact the provider	Text	1	35	Free format	No		Mandatory	Mandatory	1..1
             * 2.002	2.### View	2.0## Pension Arrangement Data	Pension name	To describe where the pension is to the individual	Name of the pension arrangement that should resonate with the individual	Text	1	100	Free format	No		Mandatory	Mandatory	1..1
             * 2.003	2.### View	2.0## Pension Arrangement Data	Pension type	Indicate the type of pension to allow correct signposting to an individual	ErrMessage of pension arrangement eg DC	Text	2	3	Free format	Yes		Mandatory	Mandatory	1..1
             * 2.004	2.### View	2.0## Pension Arrangement Data	Pension origin	Indicate the origin of the pension to allow correct signposting to an individual	Origin of the pension arrangement eg work	Text	1	1	Free format	Yes		Mandatory	Mandatory	1..1
             * 2.005	2.### View	2.0## Pension Arrangement Data	Pension status	To allow the individual to see if they are still actively building up the pension through ongoing contributions and / or pensionable employment	A code identifying the status of the pension arrangement according to a set list of values	Text	1	1	Free format	Yes		Mandatory	Mandatory	1. .1
             * 2.006	2.### View	2.0## Pension Arrangement Data	Pension start date	To allow the individual to see when they started building up their pension	A date identifying the start date of the individual’s pension with the pension arrangement	Date	1	8	YYYY-MM-DD ISO 8601 – numeric representation of date	No	Must be a valid date ie - a valid month - a number of days that is valid for t he month - inclusion of 29 February if a leap year	Mandatory	Mandatory	1..1
             * 2.007	2.### View	2.0## Pension Arrangement Data	Pension retirement date	To allow the individual to see when the retirement income from the pension is set to be payable from	A date identifying when the pension arrangement is set to start paying a retirement income to the individual	Date	1	8	YYYY-MM-DD ISO 8601 – numeric representation of date	No	Must be a valid date ie - a valid month - a number of days that is valid for the month - inclusion of 29 February if a leap year	Conditional	Conditional - if available this should be provided	1..1
             * 2.008	2.### View	2.0## Pension Arrangement Data	Pension link	To link pension arrangements together	IDentifier used to link pension arrangements together eg AVC pot with main scheme pension	Text	1	35	Free format	No		Conditional	Conditional - if a pension has linked arrangements a linking reference should be provided here to allow the pension arrangements to be linked	0..1
            */
            public string PensionReference { get; set; }
            public string PensionName { get; set; }
            public string PensionType { get; set; }
            public string PensionOrigin { get; set; }
            public string PensionStatus { get; set; }
            public DateTime PensionStartDate { get; set; }
            public DateTime PensionRetirementDate { get; set; }

            public string PensionLink { get; set; }
            //Constructor
            public PDPPensionArrangement()
            {
            }

        }
        #endregion

        ///New Section Scheme Basis
        ///


        #region PDPSchemeBasis
        /// <summary>
        /// *NEW invented by RPM IT Consulting Ltd*
        /// Specific class for defining the PDP Scheme Basis for Pension arrangement for Pensions Dashboard
        /// Specific for calculations 
        /// Some bits used for projection, NPA etc
        /// </summary>
        public class PDPSchemeBasis
        {

            /*
             * ERF
             * LRF
             * NPA 
             * MinNPA
             * MaxNPA
             * 99.001	NPA - Normal Pension Age, double stored as string, eg 65 
             * 99.002	ERF - Early Retirement Factor, double but stored as string, eg 0.05 == 5% PA reduction
             * 99.003	LRF - Late Retirement Factor, double but stored as string, eg 0.04 == 4% increase PA   
             * 99.004	MinNPA - Min allowable NPA, double but stored as string, eg 55 
             * 99.004	MaxNPA - Max allowable NPA, double but stored as string, eg 75
             * */
            public string NPA { get; set; }
            public string ERF { get; set; }
            public string LRF { get; set; }
            public string MinNPA { get; set; }
            public string MaxNPA { get; set; }

            //Constructor
            public PDPSchemeBasis()
            {
            }

        }
        #endregion
    }
}