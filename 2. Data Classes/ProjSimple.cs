//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************

///Two function used to make projecting benefits and salaries easier to move around.

using Newtonsoft.Json;
using System.Collections.Generic;

namespace PTXClassLibrary
{
    /// <summary>
    /// Simplified Projection of Benefits or Salaries, anything with 151 values
    /// Used in projections for simplicity
    /// Used to assign and retrieve single projection
    /// Can use Either Benefits or Earnings - or both
    /// Based around Age projections
    /// </summary>
    public class ProjSimple
    //Single benefit class
    {
        /// <summary>
        // Class that contains details about the 1 dimensional projections 
        // Contains 3 projections for Benefits, Salary and Pot/DC
        /// 
        /// 
        /// </summary>
        [JsonProperty("ProjName")]
        public string ProjName { get; set; }

        [JsonProperty("Age")]
        public int Age { get; set; }

        [JsonProperty("InfoYear")]
        public int InfoYear { get; set; }

        [JsonProperty("TRA")]
        public int TRA { get; set; }

        [JsonProperty("Commpc")]
        public int Commpc { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        #region List of variables
        [JsonProperty("BenefitSimpleList")]
        public List<BenefitSimple> BenefitSimpleList = new List<BenefitSimple>();


        [JsonProperty("SalaryList")]
        public List<SalarySimple> SalaryList = new List<SalarySimple>();

        [JsonProperty("PotList")]
        public List<PotSimple> PotList = new List<PotSimple>();

        #endregion

        //USed for single return
        [JsonProperty("ProjArrayDoubles1D")]
        public ProjArrayDoubles1D ProjArrayDoubles1D { get; set; }


        //Generic Descriptor used for variable
        [JsonProperty("IndicatorInteger1")]
        public int IndicatorInteger1;
        [JsonProperty("IndicatorIntegerDescription1")]
        public string IndicatorIntegerDescription1;


        [JsonProperty("CalcAudit")]
        public CalcAudit CalcAudit = new CalcAudit();


        [JsonProperty("sError")]
        string sError;

        [JsonProperty("dError")]
        double dError;




        // Default constructor: 
        /// <summary>
        /// Default constructor, creates blank objects of the correct size.
        /// </summary>
        public ProjSimple()
        {
            //CalcAudit.AddRow("Initialised.", "");
            for (int i = 0; i <= PTXGlobals.iMaxAge; i++)
            {
                BenefitSimpleList.Add(new BenefitSimple { });
                SalaryList.Add(new SalarySimple { });
                PotList.Add(new PotSimple { });
                ProjName = "Temp_ProjSimple";

                InfoYear = 2000;
                IndicatorInteger1 = 0;
                IndicatorIntegerDescription1 = "Default description of IndicatorInteger1";
            }
        }

    }




    /// <summary>
    /// Simplified 2D list of Projection of ProjSimple objects Salaries, anything with 151 values
    /// 2D With Age or scenario on the column
    /// 
    /// Not can be used as 3D if created that way

    /// Example of how this could be used
    ///XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    ///Projection of ages and different scenarios -->>
    ///ProjSimple2D.ProjectionGroupName = "Projections varying by target pension ages"
    ///ProjSimple2D.ProjectionGroupDescription = " Matrix of future projection based on NPA = index for ProjSimpleList, list starts a 55.  
    ///                                            ProjSimpleList[0-150]"

    ///                            .BenefitSimpleList[index : 0 to 150]    0  .... 55       56       57       58        ... 150
    ///----------------------------------------------------------------------------------------------------------------------------------------
    ///ProjSimple2D.ProjSimpleList[000].ProjName = "Post Ret Projections From Age 00"
    ///ProjSimple2D.ProjSimpleList[000].InfoAge = 00  
    ///ProjSimple2D.ProjSimpleList[000].BenefitSimpleList[index].Pen    |  0.00    0.00     0.00     0.00     0.00  
    ///ProjSimple2D.ProjSimpleList[000].BenefitSimpleList[index].LS     |  0.00    0.00     0.00     0.00     0.00 
    ///ProjSimple2D.ProjSimpleList[000].SalarySimple[index].Sal         |  0.00    0.00     0.00     0.00     0.00 
    ///ProjSimple2D.ProjSimpleList[000].PotSimple[index].PotEOY         |  0.00    0.00     0.00     0.00     0.00 
    ///    
    ///...
    ///ProjSimple2D.ProjSimpleList[055].ProjName = "Post Ret Projections From Age 55"
    ///ProjSimple2D.ProjSimpleList[055].InfoAge = 55 
    ///ProjSimple2D.ProjSimpleList[055].BenefitSimpleList[index].Pen    |  0.00    1234.00  1233.33  1234.00  1233.33  ... 1234.00
    ///ProjSimple2D.ProjSimpleList[055].BenefitSimpleList[index].LS     |  0.00    3000.00  3000.00  3000.00  3000.00  ... 3000.00 

    /// etc   
    ///ProjSimple2D.ProjSimpleList[056].BenefitSimpleList[index].Pen    |  0.00    0.00     1233.33  1222.55  1233.33  ... 1234.00
    ///ProjSimple2D.ProjSimpleList[056].BenefitSimpleList[index].LS     |  0.00    0.00     3000.00  3000.00  3000.00  ... 3000.00
    ///
    ///ProjSimple2D.ProjSimpleList[057].BenefitSimpleList[index].Pen    |  0.00    0.00     0.00     1233.33  1234.00  ... 1234.00
    ///ProjSimple2D.ProjSimpleList[057].BenefitSimpleList[index].LS     |  0.00    0.00     0.00     3000.00  3000.00  ... 3000.00 
    ///...
    ///ProjSimple2D.ProjSimpleList[150].BenefitSimpleList[index].Pen    |  0.00    0.00     0.00     0.00     0.00     ... 1234.00 
    ///ProjSimple2D.ProjSimpleList[150].BenefitSimpleList[index].LS     |  0.00    0.00     0.00     0.00     0.00     ... 3000.00 
    ///----------------------------------------------------------------------------------------------------------------------------------------   
    ///XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    /// </summary>
    /// <summary>
    /// 2D Array of double with 'N' ProjArrayDoubles1D  objects, 
    /// </summary>
    public class ProjSimple2D
    //Single benefit class
    {
        [JsonProperty("CalcAudit")]
        public CalcAudit CalcAudit = new CalcAudit();

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("TRA")]
        public int TRA { get; set; }

        [JsonProperty("Commpc")]
        public int Commpc { get; set; }


        [JsonProperty("ProjSimpleArray2D")]
        //public List<ProjSimple> ProjSimpleArray2D = new List<ProjSimple>();
        public List<dynamic> ProjSimpleArray2D = new List<dynamic>();

        /// <summary>
        /// Default constructor, sets up with 'N' ProjSimples
        /// </summary>
        public ProjSimple2D(int NumProjSimple)
        {
            for (int i = 0; i < NumProjSimple; i++)
            {
                ProjSimpleArray2D.Add(new ProjSimple { });
            }

        }
        /// <summary>
        /// Default Constructor add in 151 ProjSimples
        /// </summary>
        public ProjSimple2D()
        {
            //Add in 151 rows
            for (int i = 0; i <= PTXGlobals.iMaxAge; i++)
            {
                ProjSimpleArray2D.Add(new ProjSimple { });
            }
        }


        /// <summary>
        /// Add projArrayDoubles1D to 2D array
        /// </summary>
        /// <param name="projArrayDoubles1D"></param>
        internal void Add(ProjArrayDoubles1D projArrayDoubles1D)
        {
            ProjSimpleArray2D.Add(new ProjSimple { });
        }

    }
}
