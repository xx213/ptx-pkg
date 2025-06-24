using System;

namespace PTXClassLibrary
{
    public class MemberFlat : DBBase
    {
        // Overriding the UpdateTypeAndID method
        // Constructor calling base class constructor
        public MemberFlat() : base()
        {
            // Additional initialization if needed
        }

        // Overriding the UpdateTypeAndID method
        public override void UpdateTypeAndID()
        {
            Type = "MemberFlat:DBBase";
            ID = MemID + "_" + SchemeID;
        }

        // Overriding the UpdateUID method
        protected override void UpdateUID()
        {
            // Add your specific logic for updating UID in the MemberFlat class
            UID = MemID + "_" + SchemeID + "_" + VersionUID;
        }

        #region Member Data

        #region Properties

        // Original properties
        public string MemID { get; set; }
        public string SchemeID { get; set; }
        public string SchemeName { get; set; }
        public DateTime? DataExtractDate { get; set; }
        public DateTime? MemEffPIPDate { get; set; }
        public DateTime? MemPaidUpToDate { get; set; }
        public string MemCurrStat { get; set; }
        public DateTime? MemCurrStatDate { get; set; }
        public string MemCurrSubStat { get; set; }
        public string MemNino { get; set; }
        public string MemSurname { get; set; }
        public string MemInitial { get; set; }
        public string MemCurrCat { get; set; }
        public string MemBenSpec_Cat_GUID { get; set; }
        public string MemGender { get; set; }
        public DateTime? MemDOB { get; set; }
        public string MemDependant { get; set; }
        public string MemLinkToDeceasedyn { get; set; }
        public string MemLinkToDeceasedID { get; set; }
        public DateTime? MemDOD { get; set; }
        public string SpsGender { get; set; }
        public DateTime? DepDOB { get; set; }
        public string ChlPenyn { get; set; }
        public DateTime? MemDCPS { get; set; }
        public DateTime? MemDJS { get; set; }
        public DateTime? MemDOL { get; set; }
        public DateTime? MemDOR { get; set; }
        public DateTime? MemStartCOutDate { get; set; }
        public DateTime? MemEndCOutDate { get; set; }
        public DateTime? MemStartAdminDate { get; set; }
        public DateTime? MemEndAdminDate { get; set; }
        public string MemRetFromActDef { get; set; }
        public string MemScmGMPRevRate { get; set; }
        public string MemGMPA { get; set; }
        public string MemOverGMPAyn { get; set; }
        public string MemOverGMPAatDORyn { get; set; }
        public string MemOverGMPAatDOLyn { get; set; }
        public double? MemScmPre88GMPDOL { get; set; }
        public string MemScmPre88GMPCatDOL { get; set; }
        public double? MemScmPost88GMPDOL { get; set; }
        public string MemScmPost88GMPCatDOL { get; set; }
        public double? MemUsePre88GMPDOL { get; set; }
        public double? MemUsePost88GMPDOL { get; set; }
        public double? MemUseTotGMPDOL { get; set; }
        public string MemUseGMPRevRate { get; set; }
        public double? MemUsePre88GMPDODGMPD { get; set; }
        public double? MemUsePost88GMPDODGMPD { get; set; }
        public double? MemUseTotGMPDODGMPD { get; set; }
        public double? MemPre88GMPPenEffPIPDate { get; set; }
        public string MemScmPre88GMPCatEffPIPDate { get; set; }
        public double? MemPost88GMPPenEffPIPDate { get; set; }
        public string MemScmPost88GMPCatEffPIPDate { get; set; }
        public double? MemPre97XS1PenEffPIPDate { get; set; }
        public string MemScmPre97XS1CatEffPIPDate { get; set; }
        public double? MemPre97XS2PenEffPIPDate { get; set; }
        public string MemScmPre97XS2CatEffPIPDate { get; set; }
        public double? MemPre97XS3PenEffPIPDate { get; set; }
        public string MemScmPre97XS3CatEffPIPDate { get; set; }
        public string MemPSOPenyn { get; set; }
        public DateTime? MemPSODate { get; set; }
        public double? MemPSOPenDebpc { get; set; }
        public string MemLEAAppyn { get; set; }
        public double? MemFPSIncGMPAtoDOLTot { get; set; }
        public double? MemFPSIncGMPAtoDOLAnn { get; set; }
        public string MemMultiPeriodsServiceyn { get; set; }
        public double? MemMultiPeriodsServiceNum { get; set; }
        public string MemTVINyn { get; set; }
        public string MemPenCredyn { get; set; }
        public string MemPTServyn { get; set; }
        public string MemVFMyn { get; set; }
        public string MemPartialTVOutyn { get; set; }
        public string MemSalLinkyn { get; set; }
        public string MemPIEyn { get; set; }
        public string MemJerseyyn { get; set; }
        public string MemOverseasyn { get; set; }
        public DateTime? MemInsuredDate { get; set; }
        public DateTime? MemGMPEDate { get; set; }
        public string MemAddInfo { get; set; }
        public string MemadHoc1 { get; set; }
        public string MemadHoc2 { get; set; }
        public string MemadHoc3 { get; set; }
        public string MemadHoc4 { get; set; }
        public string MemadHoc5 { get; set; }

        #endregion

        #endregion
    }
}
