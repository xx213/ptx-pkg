//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************

using System;
using System.Collections.Generic;
using System.Text;
using PTXClassLibrary;



namespace PTXClassLibrary
{
    /// <summary>
    /// TVEngine - a standard transfer value abstarct Engine class
    /// 
    /// </summary>
    public abstract class TVOutBase
    {

        #region Defaults - Developer input required
        string functionName = "TVOutBase";

        string sError;
        double dError;

        public  CalcAudit CalcAuditObject = new CalcAudit();
        #endregion

        #region Member Info
        public Gender gnGender { get; set; }
        public DateTime dtDOB { get; set; }

        /// <summary>
        /// Date of Leaving scheme
        /// </summary>
        public DateTime dtDOL { get; set; }

        /// <summary>
        /// Date of Calc
        /// </summary>
        public DateTime dtDOC { get; set; }


        /// <summary>
        /// dtNPD is Normal pension age, however this could be any pension age but the overload reval function would need to allow for LRF and ERD
        ///         /// </summary>
        public DateTime dtNPD { get; set; }

        #endregion

        #region Ages used in calcs
        public double Age_YD_DOL { get; set; } 
        public double Age_YD_DOC { get; set; } 
        public double Age_YD_NPD { get; set; } 
        #endregion


        #region Benefits Setup
        //GMP Benefits at DOL
        /// <summary>
        /// GMP accrued between 6/4/78 to 5/4/88 at DOL, NPA
        /// </summary>
        public double Pre88Post78GMP_Ben_DOL { get; set; } 

        /// <summary>
        /// GMP accrued between 6/4/88 to 16/5/90 at DOL
        /// </summary>
        public double Pre90Post88GMP_Ben_DOL { get; set; } 

        /// <summary>
        /// GMP accrued between 17/5/90 to 5/4/97 at DOL
        /// </summary>
        public double Pre97Post90GMP_Ben_DOL { get; set; } 
        #endregion

        #region XS splits @ DOL
        /// <summary>
        /// XS accured in the period 6/4/78 to 31/12/84  at DOL
        /// </summary>
        public double Pre85Post78XS_Ben_DOL { get; set; } 
        /// <summary>
        /// XS accrued between 1/1/85 to 5/4/88 at DOL
        /// </summary>
        public double Pre88Post85XS_Ben_DOL { get; set; } 
        /// <summary>
        /// XS accrued between 6/4/88 to 16/5/90 at DOL
        /// </summary>
        public double Pre90Post88XS_Ben_DOL { get; set; } 
        /// <summary>
        /// XS accrued in the period 17/5/90 to 5/4/97
        /// </summary>
        public double Pre97Post90XS_Ben_DOL { get; set; } 
        #endregion

        // ReturnClass


        //@ GMPA, GMP Only Benefits 
        public double Pre88Post78GMP_Ben_GMPA { get; set; } 
        public double Pre90Post88GMP_Ben_GMPA { get; set; } 
        public double Pre97Post90GMP_Ben_GMPA { get; set; } 


        #region GMP and XS Benefits at NPA
        public double Pre88Post78GMP_Ben_NPD { get; set; } 
        public double Pre90Post88GMP_Ben_NPD { get; set; } 
        public double Pre97Post90GMP_Ben_NPD { get; set; } 

        public double Pre85Post78XS_Ben_NPD { get; set; } 
        public double Pre88Post85XS_Ben_NPD { get; set; } 
        public double Pre90Post88XS_Ben_NPD { get; set; } 
        public double Pre97Post90XS_Ben_NPD { get; set; } 
        #endregion

        #region  GMP and XS Value at NPA

        public double Pre88Post78GMP_Val_NPD { get; set; } 
        public double Pre90Post88GMP_Val_NPD { get; set; } 
        public double Pre97Post90GMP_Val_NPD { get; set; } 

        public double Pre85Post78XS_Val_NPD { get; set; } 
        public double Pre88Post85XS_Val_NPD { get; set; } 
        public double Pre90Post88XS_Val_NPD { get; set; } 
        public double Pre97Post90XS_Val_NPD { get; set; } 

        #endregion

        #region GMP and XS Value at DOC
        public double Pre88Post78GMP_Val_DOC { get; set; } 
        public double Pre90Post88GMP_Val_DOC { get; set; } 
        public double Pre97Post90GMP_Val_DOC { get; set; } 

        public double Pre85Post78XS_Val_DOC { get; set; } 
        public double Pre88Post85XS_Val_DOC { get; set; } 
        public double Pre90Post88XS_Val_DOC { get; set; } 
        public double Pre97Post90XS_Val_DOC { get; set; } 

        #endregion



        // Basis



        /// <summary>
        /// Fixed rate of post retirment interest
        /// </summary>
        public double dIntPostRet { get; set; }

        /// <summary>
        /// Pre Ret intereste Rate
        /// </summary>
        public double dIntPreRet { get; set; }


        //Tranche Specific increase
        public double Pre88Post78GMP_PostRetInc { get; set; } 
        public double Pre90Post88GMP_PostRetInc { get; set; } 
        public double Pre97Post90GMP_PostRetInc { get; set; } 
        public double Pre85Post78XS_PostRetInc { get; set; } 
        public double Pre88Post85XS_PostRetInc { get; set; } 
        public double Pre90Post88XS_PostRetInc { get; set; } 
        public double Pre97Post90XS_PostRetInc { get; set; }

        #region Revaluation Basis
        //This could be done by the GMPXSReval class in the future, for now though use seperate bits
       // public GMPXSReval myGMPXSReval { get; set; }
        

        //These can bes used as well
        public double Pre88Post78GMP_PreRetRev { get; set; } 
        public double Pre90Post88GMP_PreRetRev { get; set; } 
        public double Pre97Post90GMP_PreRetRev { get; set; } 
        public double Pre85Post78XS_PreRetRev { get; set; } 
        public double Pre88Post85XS_PreRetRev { get; set; } 
        public double Pre90Post88XS_PreRetRev { get; set; } 
        public double Pre97Post90XS_PreRetRev { get; set; } 

        #endregion

        #region Mortaility
        public string sMort { get; set; } = null;
        public int iGtee { get; set; } 



        #endregion


        //constructor
        public TVOutBase()
        {
            
            //Most of the variables are already instantiated
        }

        /// <summary>
        /// This function uses actuarial functions to calacualte the TV
        /// </summary>
        public void StandardActuarialTVCalc()
        {
            //Do Calcs Here
            //Bespoke for each scheme

            RollBackValFromNPAtoDOC();
            ValueAtNPA();
            RollBackValFromNPAtoDOC();
        }

        /// <summary>
        /// TO BE COMPLETED - uses tables rather than actuarial functions
        /// </summary>
        public void StandardAdministrationVCalc()
        {
            //Do Calcs Here
            //Bespoke for each scheme

            RollBackValFromNPAtoDOC();
            ValueAtNPA();
            RollBackValFromNPAtoDOC();

        }

        #region Step 1 - Revalue Benefits to NPA
        /// <summary>
        /// Overloaded calculation to revalue all benefitsfrom DOL to NRD
        /// Use eg Pre88Post78GMP_Ben_DOL and write to Pre88Post78GMP_Ben_NPD
        /// Would use new GMNPXSReval Function
        /// 
        /// </summary>
        public void RevalueBenfitsFromDOLtoNPA()
        {
            //Do Calcs Here
            //Bespoke for each scheme
            //Revalue from DOC to NPA

            ///Instantiate 
                //myGMPXSReval  


        }
        #endregion

        #region Step 2 - VALUE Benefits at NPA
        /// <summary>
        /// Value benefits at NPA
        /// Use eg Pre88Post78GMP_Ben_NPD and write to Use eg Pre88Post78GMP_Ben_NPD
        /// May use ASL or Scheme Table
        /// </summary>
        public void ValueAtNPA()
        {


        }
        #endregion

        #region Step 3 - Roll back Value to DOC
        /// <summary>
        /// Overloaded calculation rollback the value at NPA to DOC
        /// Use eg Pre88Post78GMP_Val_NPD and write to Pre88Post78GMP_Val_DOC
        /// Could use VN or scheme table
        /// </summary>
        public void RollBackValFromNPAtoDOC()
        {
            //Do Calcs Here
            //Bespoke for each scheme
            //Roll back from NPA to DOC
            //
        }
        #endregion


        #region Other standard methods
        public void CalculateAges()
        {
            //Calculate Ages
            //Age_YD_DOC = AgeServiceEngine.AgeService_Engine(dtDOB, dtDOC, PTXGlobals.sAge, PTXGlobals.sDay);
            //Age_YD_DOL = AgeServiceEngine.AgeService_Engine(dtDOB, dtDOL, PTXGlobals.sAge, PTXGlobals.sDay);
            //Age_YD_NPD = AgeServiceEngine.AgeService_Engine(dtDOB, dtNPD, PTXGlobals.sAge, PTXGlobals.sDay);
            //CalcAuditObject.CalcAuditAddRow(functionName + " : CalculateAges.", "Pass");
        }

        #endregion




    }
}
