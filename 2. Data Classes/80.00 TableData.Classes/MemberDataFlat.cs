using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents a Data member Flat with relevant properties.
    /// </summary>
    public class DataMemberFlat
    {

        public int Id { get; set; }
        public string GUID { get; set; }
        public string memPTXGUID { get; set; }
        //PTX Internals
        public string TableRef { get; set; }
        public string Arrangement { get; set; }
       //Audit
        public string Audit { get; set; }
        public string DataImportGUID { get; set; }
        public string DataImportType { get; set; }
        public string DataImportFilename { get; set; }
        public DateTime DataImportDateTime { get; set; }
        public string DataImportUser { get; set; }
        public string DataImportSchemeID { get; set; }
        public string DataImportFileVersion { get; set; }
        public string DataImportDescription { get; set; }
        public string PTXMemGuid { get; set; }
        public string memUID { get; set; }
        public string memSchemeID { get; set; }
        public string memSchemeName { get; set; }
        public DateTime DataExtractDate { get; set; }
        public DateTime memEffPIPDate { get; set; }
        public string SpsGender { get; set; }
        public DateTime DepDOB { get; set; }
        public string ChlPenyn { get; set; }
        public DateTime memDCPS { get; set; }
        public DateTime memDJS { get; set; }
        public DateTime memDOL { get; set; }
        public DateTime memDOR { get; set; }
        public DateTime memStartCOutDate { get; set; }
        public DateTime memEndCOutDate { get; set; }
        public DateTime memStartAdminDate { get; set; }
        public DateTime memEndAdminDate { get; set; }
        public string memRetFromActDef { get; set; }
        public double memGMPA { get; set; }
        public string memOverGMPAyn { get; set; }
        public string memOverGMPAatDORyn { get; set; }
        public string memOverGMPAatDOLyn { get; set; }
        public double memScmPre88GMPDOL { get; set; }
        public string memScmPre88GMPCatDOL { get; set; }
        public double memScmPost88GMPDOL { get; set; }
        public string memScmPost88GMPCatDOL { get; set; }
        public double memUsePre88GMPDOL { get; set; }
        public double memUsePost88GMPDOL { get; set; }
        public double memUseTotGMPDOL { get; set; }
        public string memUseGMPRevRate { get; set; }
        public double memUsePre88GMPDODGMPA { get; set; }
        public double memUsePost88GMPDODGMPA { get; set; }
        public double memUseTotGMPDODGMPA { get; set; }
        public double memPre88GMPCurr { get; set; }
        public double memScmPre88GMPCatEffPipDate { get; set; }
        public double memPost88GMPCurr { get; set; }
        public double memScmPost88GMPCatEffPipDate { get; set; }
        public double memPre97XSCurr1 { get; set; }
        public double memScmPre97XS1CatEffPipDate { get; set; }
        public double memPre97XSCurr2 { get; set; }
        public double memScmPre97XS2CatEffPipDate { get; set; }
        public double memPre97XSCurr3 { get; set; }
        public double memScmPre97XS3CatEffPipDate { get; set; }
        public string memPSOPenyn { get; set; }
        public DateTime memPSODate { get; set; }
        public string memPSOPenDebpc { get; set; }
        public string memLEAAppyn { get; set; }
        public string memFPSIncGMPAtoDOLTot { get; set; }
        public string memFPSIncGMPAtoDOLAnn { get; set; }
        public string memMultiPeriodsServiceyn { get; set; }
        public string memMultiPeriodsServiceNum { get; set; }
        public string memTVINyn { get; set; }
        public string memPenCredyn { get; set; }
        public string memPTServyn { get; set; }
        public string memVFMyn { get; set; }
        public string memPartialTVOutyn { get; set; }
        public string memSalLinkyn { get; set; }
        public string memPIEyn { get; set; }
        public string memJerseyyn { get; set; }
        public string memOverseasyn { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public  DataMemberFlat()
        {
            // Default constructor
        }

    }
}
