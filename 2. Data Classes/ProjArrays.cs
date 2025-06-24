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
    /// 1D Array doubles 151 values, 
    /// </summary>
    public class ProjArrayDoubles1D
    //Single benefit class
    {
        [JsonProperty("Array1D")]
        public List<double> Array1D = new List<double>();

        [JsonProperty("CalcAudit")]
        public CalcAudit CalcAudit { get; set; }


        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Commpc")]
        public int Commpc { get; set; }

        //LS, Ben ,Pot etc
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("TRA")]
        public int TRA { get; set; }

        [JsonProperty("AgeDOLDOC")]
        public int AgeDOLDOC { get; set; }

        /// <summary>
        /// Default constructor, sets up with zeros
        /// </summary>
        public ProjArrayDoubles1D()
        {
            for (int i = 0; i <= PTXGlobals.iMaxAge; i++)
            {
                Array1D.Add(new double { });
                Description = "ProjArrayDoubles1D : Initialised.  ";
            }
        }
        /// <summary>
        /// Set up a new array with NumProjections 
        /// eg from age 45 to 120 would be (120 - 45 +  = 76)
        /// </summary>
        /// <param name="NumProjections"></param>
        public ProjArrayDoubles1D(int NumProjections)
        {
            for (int i = 0; i <= NumProjections; i++)
            {
                Array1D.Add(new int { });
                Description = "ProjArrayDoubles1D : Initialised.  ";
            }
        }
    }


    /// <summary>
    /// 1D Array integer 151 values, 
    /// </summary>
    public class ProjArrayInt1D
    //Single benefit class
    {
        [JsonProperty("Array1D")]
        public List<int> Array1D = new List<int>();

        [JsonProperty("CalcAudit")]
        public CalcAudit CalcAudit { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Commpc")]
        public int Commpc { get; set; }

        //LS, Ben ,Pot etc
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("TRA")]
        public int TRA { get; set; }

        [JsonProperty("AgeDOLDOC")]
        public int AgeDOLDOC { get; set; }

        /// <summary>
        /// Default constructor, sets up with zeros
        /// </summary>
        public ProjArrayInt1D()
        {
            for (int i = 0; i <= PTXGlobals.iMaxAge; i++)
            {
                Array1D.Add(new int { });
                Description = "ProjArrayInt1D : Initialised.  ";
            }
        }
        /// <summary>
        /// Set up a new array with NumProjections 
        /// eg from age 45 to 120 would be (120 - 45 +  = 76)
        /// </summary>
        /// <param name="NumProjections"></param>
        public ProjArrayInt1D(int NumProjections)
        {
            for (int i = 0; i <= NumProjections; i++)
            {
                Array1D.Add(new int { });
                Description = "ProjArrayInt1D : Initialised.  ";
            }
        }
    }




    /// <summary>
    /// 1D Array string 151 values, 
    /// </summary>
    public class ProjArrayString1D
    //Single benefit class
    {
        [JsonProperty("Array1D")]
        public List<string> Array1D = new List<string>();

        //    [JsonProperty("Description")]
        //   public string Description { get; set; }
        /// <summary>
        /// Default constructor, sets up with ""
        /// </summary>
        public ProjArrayString1D()
        {
            for (int i = 0; i <= PTXGlobals.iMaxAge; i++)
            {

                Array1D.Add("");
                //   Description = i.ToString();

            }

        }

    }

    #region 2D arrays
    /// <summary>
    /// 2D Array of double with 151 ProjArratDoubles1D objects, 
    /// </summary>
    public class ProjArrayDoubles2D
    //Single benefit class
    {
        [JsonProperty("CalcAudit")]
        public CalcAudit CalcAudit = new CalcAudit();

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Array2D")]
        public List<ProjArrayDoubles1D> Array2D = new List<ProjArrayDoubles1D>();

        /// <summary>
        /// Default constructor, sets up with ""
        /// </summary>
        public ProjArrayDoubles2D()
        {
            for (int i = 0; i <= PTXGlobals.iMaxAge; i++)
            {
                Array2D.Add(new ProjArrayDoubles1D { });
            }

        }
        /// <summary>
        /// Add projArrayDoubles1D to 2D array
        /// </summary>
        /// <param name="projArrayDoubles1D"></param>
        internal void Add(ProjArrayDoubles1D projArrayDoubles1D)
        {
            Array2D.Add(new ProjArrayDoubles1D { });
        }
    }


    /// <summary>
    /// 2D Array of double with 'N' ProjArrayDoubles1D  objects, 
    /// </summary>
    public class ArrayDoubles2D
    //Single benefit class
    {
        [JsonProperty("CalcAudit")]
        public CalcAudit CalcAudit = new CalcAudit();

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Array2D")]
        public List<ProjArrayDoubles1D> Array2D = new List<ProjArrayDoubles1D>();


        /// <summary>
        /// Default constructor, sets up with ""
        /// </summary>
        public ArrayDoubles2D(int NumProjArrayDoubles1D)
        {
            for (int i = 0; i <= NumProjArrayDoubles1D; i++)
            {
                Array2D.Add(new ProjArrayDoubles1D { });
            }

        }
        /// <summary>
        /// Default Constructor add in 151 values
        /// </summary>
        public ArrayDoubles2D()
        {
            //Add in 151 rows
            //for (int i = 0; i <= PTXGlobals.iMaxAge; i++)
            //{
            //    Array2D.Add(new ProjArrayDoubles1D { });
            //}
        }



        /// <summary>
        /// Add projArrayDoubles1D to 2D array
        /// </summary>
        /// <param name="projArrayDoubles1D"></param>
        internal void Add(ProjArrayDoubles1D projArrayDoubles1D)
        {
            Array2D.Add(projArrayDoubles1D);
        }

    }


    /// <summary>
    /// 2D Array of double with 'N' ProjArrayDoubles1D  objects, 
    /// </summary>
    public class ArrayInt2D
    //Single benefit class
    {
        [JsonProperty("CalcAudit")]
        public CalcAudit CalcAudit = new CalcAudit();

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Array2D")]
        public List<ProjArrayInt1D> Array2D = new List<ProjArrayInt1D>();


        /// <summary>
        /// Default constructor, sets up with ""
        /// </summary>
        public ArrayInt2D(int NumProjArrayDoubles1D)
        {
            for (int i = 0; i <= NumProjArrayDoubles1D; i++)
            {
                Array2D.Add(new ProjArrayInt1D { });
            }

        }
        /// <summary>
        /// Default Constructor add in 151 values
        /// </summary>
        public ArrayInt2D()
        {
            //Add in 151 rows
            //for (int i = 0; i <= PTXGlobals.iMaxAge; i++)
            //{
            //    Array2D.Add(new ProjArrayDoubles1D { });
            //}
        }



        /// <summary>
        /// Add projArrayDoubles1D to 2D array
        /// </summary>
        /// <param name="projArrayDoubles1D"></param>
        internal void Add(ProjArrayInt1D projArrayInt1D)
        {
            Array2D.Add(projArrayInt1D);
        }

    }

    #endregion
}
