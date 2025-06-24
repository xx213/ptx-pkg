using Newtonsoft.Json;
using PTX.ClassLibrary;
using System;

namespace PTXClassLibrary
{
    public class CatSpecFlat : DBBase
    {
        public CatSpecFlat()
        {
            // Initialization logic specific to CatSpecFlat
            CatSpecFlat_DBAudit = new DBAudit();
            Type = "CatSpecFlatConstructor";
            ID = CalculateID();
            VersionUID = CalculateVersionUID();
            UID = CalculateUID();
            DataImportGUID = CalculateDataImportGUID();
        }

        private Guid CalculateDataImportGUID()
        {
            // Add logic to calculate DataImport GUID
            return Guid.NewGuid();
        }

        private string GenerateBenSpecUID()
        {
            return $"{BenSpecID}_{VersionUID}";
        }

        private string GenerateCatSpecFlatUID()
        {
            return $"{BenSpecID}_{ID}_{VersionUID}";
        }

        private string GenerateDataImportUID()
        {
            // You need to replace "From Member Data :" and "From BenSpecData :" with actual data from the respective sources
            string memberDataInfo = "From Member Data :"; // Replace with actual logic
            string benSpecDataInfo = "From BenSpecData :"; // Replace with actual logic

            return $"{memberDataInfo}{benSpecDataInfo}";
        }



        // ... other properties and methods ...

        // Update the UpdateUID method to use the newly generated UIDs
        protected override void UpdateUID()
        {
            // Replace with your actual logic to calculate UID
            // Example: UID = GenerateCatSpecFlatUID();
            UID = GenerateCatSpecFlatUID();
        }

        public override void UpdateTypeAndID()
        {
            throw new NotImplementedException();
        }



        [JsonProperty("CatSpecFlat_DBAudit.GUID")]
        public DBAudit CatSpecFlat_DBAudit { get; set; }

        // DataImport properties
        [JsonProperty("DataImport.GUID")]
        public Guid DataImportGUID { get; set; }

        [JsonProperty("DataImport.UID")]
        public string DataImportUID { get; set; }

        [JsonProperty("DataImport.ID")]
        public string DataImportID { get; set; }

        [JsonProperty("DataImport.ErrMessage")]
        public string DataImportType { get; set; }

        [JsonProperty("DataImport.UserID")]
        public string DataImportUserID { get; set; }

        [JsonProperty("DataImport.Description")]
        public string DataImportDescription { get; set; }

        [JsonProperty("DataImport.UpdateDateTime")]
        public DateTime DataImportUpdateDateTime { get; set; }

        [JsonProperty("DataImport.Filename")]
        public string DataImportFilename { get; set; }

        [JsonProperty("DataImport.FileVersion")]
        public string DataImportFileVersion { get; set; }

        [JsonProperty("DataImport.FileLocation")]
        public string DataImportFileLocation { get; set; }

        [JsonProperty("DataImport.SchemeID")]
        public string DataImportSchemeID { get; set; }

        // BenSpec properties
        [JsonProperty("BenSpec.ID")]
        public string BenSpecID { get; set; }

        [JsonProperty("BenSpec.UID")]
        public string BenSpecUID { get; set; }

        [JsonProperty("BenSpec.Version")]
        public string BenSpecVersion { get; set; }

        [JsonProperty("BenSpec.Overall.EWM")]
        public string BenSpecOverallEWM { get; set; }

        [JsonProperty("BenSpec.CatSpecFlat.Final.EWM")]
        public string BenSpecCatSpecFlatFinalEWM { get; set; }

        [JsonProperty("BenSpec.PenInc.Final.EWM")]
        public string BenSpecPenIncFinalEWM { get; set; }

        [JsonProperty("BenSpec.ERF.Final.EWM")]
        public string BenSpecERFFinalEWM { get; set; }

        [JsonProperty("BenSpec.LRF.Final.EWM")]
        public string BenSpecLRFFinalEWM { get; set; }

        // Scheme properties
        [JsonProperty("Scm.ID")]
        public string ScmID { get; set; }

        [JsonProperty("Scm.UID")]
        public string ScmUID { get; set; }

        [JsonProperty("Scm.ID.EWM")]
        public string ScmIDEWM { get; set; }

        [JsonProperty("Scm.Name")]
        public string ScmName { get; set; }

        [JsonProperty("Scm.Description")]
        public string ScmDescription { get; set; }

        [JsonProperty("Scm.Name.EWM")]
        public string ScmNameEWM { get; set; }

        // Category properties
        [JsonProperty("Cat.ID")]
        public string CatID { get; set; }

        [JsonProperty("Cat.UID")]
        public string CatUID { get; set; }

        [JsonProperty("Cat.Description")]
        public string CatDescription { get; set; }

        [JsonProperty("Cat.EWM")]
        public string CatEWM { get; set; }

        // RetAges properties
        [JsonProperty("Cat.RetAges.UID")]
        public RetAge_Model CatRetAgesUID { get; set; }

        [JsonProperty("Cat.RetAges.EWM")]
        public string CatRetAgesEWM { get; set; }

        [JsonProperty("Cat.RetAges.PreBBNRAM")]
        public double CatRetAgesPreBBNRAM { get; set; }

        [JsonProperty("Cat.RetAges.PreBBNRAF")]
        public double CatRetAgesPreBBNRAF { get; set; }

        [JsonProperty("Cat.RetAges.PostBBNRA")]
        public double CatRetAgesPostBBNRA { get; set; }

        [JsonProperty("Cat.RetAges.ERFUnreducedMinAge")]
        public string CatRetAgesERFUnreducedMinAge { get; set; }

        [JsonProperty("Cat.RetAges.LRFFromAge")]
        public string CatRetAgesLRFFromAge { get; set; }

        // Eqn properties
        [JsonProperty("Cat.Eqn.UID")]
        public Eqn_Model CatEqnUID { get; set; }

        [JsonProperty("Cat.Eqn.EWM")]
        public string CatEqnEWM { get; set; }

        [JsonProperty("Cat.Eqn.BBEndDate")]
        public DateTime CatEqnBBEndDate { get; set; }

        [JsonProperty("Cat.Eqn.BBNRA")]
        public double CatEqnBBNRA { get; set; }

        [JsonProperty("Cat.Eqn.IndexBBNRAtoNRA")]
        public string CatEqnIndexBBNRAtoNRA { get; set; }

        [JsonProperty("Cat.Eqn.IndexPostCatNRA")]
        public string CatEqnIndexPostCatNRA { get; set; }

        // Tran properties
        [JsonProperty("Cat.Tran.Pre88GMP.Inc.Model.EWM")]
        public string CatTranPre88GMPIncModelEWM { get; set; }

        [JsonProperty("Cat.Tran.Pre88GMP.Inc.Model.Name")]
        public string CatTranPre88GMPIncModelName { get; set; }

        [JsonProperty("Cat.Tran.Pre88GMP.Inc.Model.Desc")]
        public string CatTranPre88GMPIncModelDesc { get; set; }

        [JsonProperty("Cat.Tran.Pre88GMP.Inc.Model.AccStart")]
        public DateTime CatTranPre88GMPIncModelAccStart { get; set; }

        [JsonProperty("Cat.Tran.Pre88GMP.Inc.Model.AccEnd")]
        public DateTime CatTranPre88GMPIncModelAccEnd { get; set; }

        [JsonProperty("Cat.Tran.Pre88GMP.Inc.Model.PenInc.UID")]
        public PenIncModel CatTranPre88GMPIncModelPenIncUID { get; set; }

        [JsonProperty("Cat.Tran.Pre88GMP.Inc.Model.PenInc.ID")]
        public string CatTranPre88GMPIncModelPenIncID { get; set; }

        [JsonProperty("Cat.Tran.Pre88GMP.Inc.Model.NonStatXS.EWM")]
        public string CatTranPre88GMPIncModelNonStatXSEWM { get; set; }

        [JsonProperty("Cat.Tran.Pre88GMP.Inc.Model.NonStatXS")]
        public string CatTranPre88GMPIncModelNonStatXS { get; set; }

        // Tran properties (continued)
        [JsonProperty("Cat.Tran.Post88GMP.Inc.Model.EWM")]
        public string CatTranPost88GMPIncModelEWM { get; set; }

        [JsonProperty("Cat.Tran.Post88GMP.Inc.Model.Name")]
        public string CatTranPost88GMPIncModelName { get; set; }

        [JsonProperty("Cat.Tran.Post88GMP.Inc.Model.Desc")]
        public string CatTranPost88GMPIncModelDesc { get; set; }

        [JsonProperty("Cat.Tran.Post88GMP.Inc.Model.AccStart")]
        public DateTime CatTranPost88GMPIncModelAccStart { get; set; }

        [JsonProperty("Cat.Tran.Post88GMP.Inc.Model.AccEnd")]
        public DateTime CatTranPost88GMPIncModelAccEnd { get; set; }

        [JsonProperty("Cat.Tran.Post88GMP.Inc.Model.PenInc.UID")]
        public PenIncModel CatTranPost88GMPIncModelPenIncUID { get; set; }

        [JsonProperty("Cat.Tran.Post88GMP.Inc.Model.PenInc.ID")]
        public string CatTranPost88GMPIncModelPenIncID { get; set; }

        [JsonProperty("Cat.Tran.Post88GMP.Inc.Model.NonStatXS.EWM")]
        public string CatTranPost88GMPIncModelNonStatXSEWM { get; set; }

        [JsonProperty("Cat.Tran.Post88GMP.Inc.Model.NonStatXS")]
        public string CatTranPost88GMPIncModelNonStatXS { get; set; }

        // Tran.Pre97XS1 properties
        [JsonProperty("Cat.Tran.Pre97XS1.Inc.Model.EWM")]
        public string CatTranPre97XS1IncModelEWM { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS1.Inc.Model.Name")]
        public string CatTranPre97XS1IncModelName { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS1.Inc.Model.Desc")]
        public string CatTranPre97XS1IncModelDesc { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS1.Inc.Model.AccStart")]
        public DateTime CatTranPre97XS1IncModelAccStart { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS1.Inc.Model.AccEnd")]
        public DateTime CatTranPre97XS1IncModelAccEnd { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS1.Inc.Model.PenInc.UID")]
        public PenIncModel CatTranPre97XS1IncModelPenIncUID { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS1.Inc.Model.PenInc.ID")]
        public string CatTranPre97XS1IncModelPenIncID { get; set; }


        // Tran.Pre97XS2 properties
        [JsonProperty("Cat.Tran.Pre97XS2.Inc.Model.EWM")]
        public string CatTranPre97XS2IncModelEWM { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS2.Inc.Model.Name")]
        public string CatTranPre97XS2IncModelName { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS2.Inc.Model.Desc")]
        public string CatTranPre97XS2IncModelDesc { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS2.Inc.Model.AccStart")]
        public DateTime CatTranPre97XS2IncModelAccStart { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS2.Inc.Model.AccEnd")]
        public DateTime CatTranPre97XS2IncModelAccEnd { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS2.Inc.Model.PenInc.UID")]
        public PenIncModel CatTranPre97XS2IncModelPenIncUID { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS2.Inc.Model.PenInc.ID")]
        public string CatTranPre97XS2IncModelPenIncID { get; set; }

        // Tran.Pre97XS3 properties
        [JsonProperty("Cat.Tran.Pre97XS3.Inc.Model.EWM")]
        public string CatTranPre97XS3IncModelEWM { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS3.Inc.Model.Name")]
        public string CatTranPre97XS3IncModelName { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS3.Inc.Model.Desc")]
        public string CatTranPre97XS3IncModelDesc { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS3.Inc.Model.AccStart")]
        public DateTime CatTranPre97XS3IncModelAccStart { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS3.Inc.Model.AccEnd")]
        public DateTime CatTranPre97XS3IncModelAccEnd { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS3.Inc.Model.PenInc.UID")]
        public PenIncModel CatTranPre97XS3IncModelPenIncUID { get; set; }

        [JsonProperty("Cat.Tran.Pre97XS3.Inc.Model.PenInc.ID")]
        public string CatTranPre97XS3IncModelPenIncID { get; set; }

        // Tran.DefRev properties
        [JsonProperty("Cat.Tran.DefRev.Model.UID")]
        public DefRev_Model CatTranDefRevModelUID { get; set; }

        [JsonProperty("Cat.DefRev.EWM")]
        public string CatDefRevEWM { get; set; }

        [JsonProperty("Cat.Tran.GMP.DefRev.Rate")]
        public string CatTranGMPDefRevRate { get; set; }

        [JsonProperty("Cat.Tran.GMP.DefRev.Method")]
        public string CatTranGMPDefRevMethod { get; set; }

        [JsonProperty("Cat.LRF.NonStatGMP.GMPDtoDOR")]
        public string CatLRFNonStatGMPGMPDtoDOR { get; set; }

        // Tran.Pre97XS1.DefRev properties
        [JsonProperty("Cat.Tran.Pre97XS1.DefRev.Rate")]
        public string CatTranPre97XS1DefRevRate { get; set; }

        // Tran.Pre97XS2.DefRev properties
        [JsonProperty("Cat.Tran.Pre97XS2.DefRev.Rate")]
        public string CatTranPre97XS2DefRevRate { get; set; }

        // Tran.Pre97XS3.DefRev properties
        [JsonProperty("Cat.Tran.Pre97XS3.DefRev.Rate")]
        public string CatTranPre97XS3DefRevRate { get; set; }

        // ... Continue with other properties ...

        // DefRev.XS properties
        [JsonProperty("Cat.DefRev.XS.DOLPre010186RevOnPre85XSyn")]
        public string CatDefRevXSDOLPre010186RevOnPre85XSyn { get; set; }

        [JsonProperty("Cat.DefRev.XS.DOLPre0101191RevOnPre010185XSyn")]
        public string CatDefRevXSDOLPre0101191RevOnPre010185XSyn { get; set; }

        // DefRev.Frank.Model properties
        [JsonProperty("Cat.DefRev.Frank.Model.DOLPre010185ApplyFrankyn")]
        public string CatDefRevFrank_ModelDOLPre010185ApplyFrankyn { get; set; }

        // DefRev.GMPRevDORUnderGMPA property
        [JsonProperty("Cat.DefRev.GMPRevDORUnderGMPA")]
        public string CatDefRevGMPRevDORUnderGMPA { get; set; }

        // FK Frank.Model.UID property
        [JsonProperty("FK Frank.Model.UID")]
        public Frank_Model FKFrank_ModelUID { get; set; }

        // ... Continue with other properties ...

        // Frank.Model properties
        [JsonProperty("Cat.Frank.Model.EWM")]
        public string CatFrank_ModelEWM { get; set; }

        [JsonProperty("Cat.Frank.Model.ER")]
        public string CatFrank_ModelER { get; set; }

        [JsonProperty("Cat.Frank.Model.NR")]
        public string CatFrank_ModelNR { get; set; }

        [JsonProperty("Cat.Frank.Model.LR")]
        public string CatFrank_ModelLR { get; set; }

        [JsonProperty("Cat.Frank.Model.NRAges")]
        public double CatFrank_ModelNRAges { get; set; }

        // ERF.Model properties
        [JsonProperty("Cat.ERF.UID")]
        public ERF_Model CatERFUID { get; set; }

        [JsonProperty("Cat.ERF.Model.EWM")]
        public string CatERF_ModelEWM { get; set; }

        [JsonProperty("Cat.ERF.AppliedAtDate")]
        public string CatERFAppliedAtDate { get; set; }

        [JsonProperty("Cat.ERF.AssumedProjRevRate")]
        public string CatERFAssumedProjRevRate { get; set; }

        [JsonProperty("Cat.ERF.Model.ActPreBB")]
        public string CatERF_ModelActPreBB { get; set; }

        [JsonProperty("Cat.ERF.Model.ActBBtoEqnNRA")]
        public string CatERF_ModelActBBtoEqnNRA { get; set; }

        [JsonProperty("Cat.ERF.Model.ActBBtoNRA")]
        public string CatERF_ModelActBBtoNRA { get; set; }

        [JsonProperty("Cat.ERF.Model.DefPreBB")]
        public string CatERF_ModelDefPreBB { get; set; }

        [JsonProperty("Cat.ERF.Model.DefBBtoEqn")]
        public string CatERF_ModelDefBBtoEqn { get; set; }

        [JsonProperty("Cat.ERF.Model.DefPostBB")]
        public string CatERF_ModelDefPostBB { get; set; }

        // LRF.Model properties
        [JsonProperty("Cat.LRF.UID")]
        public LRFModel CatLRFUID { get; set; }

        [JsonProperty("Cat.LRF.Model.EWM")]
        public string CatLRFModelEWM { get; set; }

        [JsonProperty("Cat.LRF.Model.ActPreBB")]
        public string CatLRFModelActPreBB { get; set; }

        [JsonProperty("Cat.LRF.Model.ActBBtoEqn")]
        public string CatLRFModelActBBtoEqn { get; set; }

        [JsonProperty("Cat.LRF.Model.ActPostBB")]
        public string CatLRFModelActPostBB { get; set; }

        [JsonProperty("Cat.LRF.Model.DefPreBB")]
        public string CatLRFModelDefPreBB { get; set; }

        [JsonProperty("Cat.LRF.Model.DefBBtoEqn")]
        public string CatLRFModelDefBBtoEqn { get; set; }

        [JsonProperty("Cat.LRF.Model.DefPostBB")]
        public string CatLRFModelDefPostBB { get; set; }

        // DAR.Model properties
        [JsonProperty("Cat.DAR.UID")]
        public DAR_Model CatDARUID { get; set; }

        [JsonProperty("Cat.DAR.EWM")]
        public string CatDAREWM { get; set; }

        [JsonProperty("Cat.DAR.Spspc")]
        public double CatDARSpspc { get; set; }

        [JsonProperty("Cat.DAR.Gtee")]
        public double CatDARGtee { get; set; }

        // DID.Model properties
        [JsonProperty("Cat.DID.UID")]
        public DID_Model CatDIDUID { get; set; }

        [JsonProperty("Cat.DID.EWM")]
        public string CatDIDEWM { get; set; }

        [JsonProperty("Cat.DID.Spspc")]
        public string CatDIDSpspc { get; set; }

        [JsonProperty("Cat.DID.LS")]
        public double CatDIDLS { get; set; }

        // DIS.Model properties
        [JsonProperty("Cat.DIS.UID")]
        public DIS_Model CatDISUID { get; set; }

        [JsonProperty("Cat.DIS.EWM")]
        public string CatDISEWM { get; set; }

        [JsonProperty("Cat.DIS.Spspc")]
        public string CatDISSpspc { get; set; }

        [JsonProperty("Cat.DIS.LS")]
        public double CatDISLS { get; set; }

        // LEA.Model properties
        [JsonProperty("Cat.LEA.UID")]
        public LEA_Model CatLEAUID { get; set; }

        [JsonProperty("Cat.LEA.EWM")]
        public string CatLEAEWM { get; set; }

        [JsonProperty("Cat.LEA.LEAAdjyn")]
        public string CatLEALEAAdjyn { get; set; }

        // DiscBens.Model properties
        [JsonProperty("Cat.DiscBens.UID")]
        public DiscBens_Model CatDiscBensUID { get; set; }

        [JsonProperty("Cat.DiscBens.EWM")]
        public string CatDiscBensEWM { get; set; }

        [JsonProperty("Cat.DiscBens.Desc")]
        public string CatDiscBensDesc { get; set; }

        // CO.Model properties
        [JsonProperty("Cat.CO.UID")]
        public CO_Model CatCOUID { get; set; }

        [JsonProperty("Cat.CO.EWM")]
        public string CatCOEWM { get; set; }

        [JsonProperty("Cat.CO.DCOCeased")]
        public DateTime CatCODCOCeased { get; set; }

        [JsonProperty("Cat.CO.UseGMPRateAtDate")]
        public string CatCOUseGMPRateAtDate { get; set; }

        [JsonProperty("Cat.CO.GMPRevIfAct2016Btwn2016toDOL")]
        public string CatCOGMPRevIfAct2016Btwn2016toDOL { get; set; }

        // AccCease.Model properties
        [JsonProperty("Cat.AccCease.UID")]
        public AccCease_Model CatAccCeaseUID { get; set; }

        [JsonProperty("Cat.AccCease.EWM")]
        public string CatAccCeaseEWM { get; set; }

        [JsonProperty("Cat.AccCease.Date")]
        public string CatAccCeaseDate { get; set; }

        // SalLink.Model properties
        [JsonProperty("Cat.SalLink.UID")]
        public SalLink_Model CatSalLinkUID { get; set; }

        [JsonProperty("Cat.SalLink.EWM")]
        public string CatSalLinkEWM { get; set; }

        [JsonProperty("Cat.SalLink.BrokenDate")]
        public string CatSalLinkBrokenDate { get; set; }

        // Underpin.Model properties
        [JsonProperty("Cat.Underpin.UID")]
        public Underpin_Model CatUnderpinUID { get; set; }

        [JsonProperty("Cat.Underpin.EWM")]
        public string CatUnderpinEWM { get; set; }

        [JsonProperty("Cat.Underpin.UPTBC")]
        public string CatUnderpinUPTBC { get; set; }

        [JsonProperty("Cat.Underpin.PenIncTBC")]
        public string CatUnderpinPenIncTBC { get; set; }

        [JsonProperty("Cat.Underpin.Note")]
        public string CatUnderpinNote { get; set; }

        // LS.Model properties
        [JsonProperty("Cat.LS.UID")]
        public LS_Model CatLSUID { get; set; }

        [JsonProperty("Cat.LS.EWM")]
        public string CatLSEWM { get; set; }

        [JsonProperty("Cat.LS.PCSLPainInAddnyn")]
        public string CatLSPCSLPainInAddnyn { get; set; }




    }
}
