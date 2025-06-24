using System;
using System.Collections.Generic;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents a category with various properties and associated objects.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// The GUID of the category.
        /// </summary>
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ID of the category.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// The description of the category.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The retirement ages associated with the category.
        /// </summary>
        public RetirementAges RetirementAges { get; set; }

        /// <summary>
        /// The equalisation data associated with the category.
        /// </summary>
        public Equalisation Equalisation { get; set; }

        /// <summary>
        /// Retrieves a PenIncTable by its ID.
        /// </summary>
        /// <param name="PenIncTableID">The ID of the PenIncTable to retrieve.</param>
        /// <returns>The PenIncTable with the specified ID, or null if not found.</returns>
        public PenIncTable PenIncTableID(string PenIncsTableID)
        {
            return PenIncTables.Find(PenIncTable => PenIncTable.ID == PenIncsTableID);
        }

        /// <summary>
        /// The collection of pension increases associated with the category.
        /// </summary>
        public List<PenIncTable> PenIncTables { get; set; }

        public Tranche TrancheID(string TrancheID)
        {
            return Tranches.Find(Tranche => Tranche.ID == TrancheID);
        }
        /// <summary>
        /// The collection of tranches associated with the category.
        /// </summary>
        public List<Tranche> Tranches { get; set; }

        /// <summary>
        /// The franking data associated with the category.
        /// </summary>
        /// 

        public Franking Franking { get; set; }

        /// <summary>
        /// The death data associated with the category.
        /// </summary>
        public Death Death { get; set; }

        /// <summary>
        /// The LEA (Late Entry Age) data associated with the category.
        /// </summary>
        public LEA LEA { get; set; }

        /// <summary>
        /// The CO (Conversion Option) data associated with the category.
        /// </summary>
        public COut CO { get; set; }

        /// <summary>
        /// The account cessation data associated with the category.
        /// </summary>
        public Accrual Accrual { get; set; }

        /// <summary>
        /// The salary link data associated with the category.
        /// </summary>
        public SalLink SalLink { get; set; }

        /// <summary>
        /// The underpin data associated with the category.
        /// </summary>
        public Underpin Underpin { get; set; }

        /// <summary>
        /// The LumpSum (Lump sum) data associated with the category.
        /// </summary>
        public LumpSum LumpSum { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        public Category()
        {
            // Set default values for properties
            GUID = Guid.NewGuid();
            Name = string.Empty;
            ID = string.Empty;
            Description = string.Empty;
            RetirementAges = new RetirementAges();
            Equalisation = new Equalisation();
            PenIncTables = new List<PenIncTable>();
            Tranches = new List<Tranche>();
            Franking = new Franking();
            Death = new Death();
            LEA = new LEA();
            CO = new COut();
            Accrual = new Accrual();
            SalLink = new SalLink();
            Underpin = new Underpin();
            LumpSum = new LumpSum();
        }




        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="guid">The GUID of the category.</param>
        /// <param name="name">The name of the category.</param>
        /// <param name="id">The ID of the category.</param>
        /// <param name="description">The description of the category.</param>
        /// <param name="retirementAges">The RetirementAges object.</param>
        /// <param name="equalisation">The Equalisation object.</param>
        /// <param name="pensionIncreases">The list of PensionIncrease objects.</param>
        /// <param name="tranches">The list of Tranche objects.</param>
        /// <param name="franking">The Franking object.</param>
        /// <param name="death">The Death object.</param>
        /// <param name="lea">The LEA object.</param>
        /// <param name="co">The CO object.</param>
        /// <param name="accrual">The Accrual object.</param>
        /// <param name="salLink">The SalLink object.</param>
        /// <param name="underpin">The Underpin object.</param>
        /// <param name="lumpSum">The LumpSum object.</param>
        public Category(string name, string id, string description,
                        RetirementAges retirementAges, Equalisation equalisation,
                        List<PenIncTable> pensionIncreases, List<Tranche> tranches,
                        Franking franking, Death death, LEA lea,
                        COut co, Accrual accrual, SalLink salLink, Underpin underpin,
                        LumpSum lumpSum)
        {
            GUID = Guid.NewGuid();
            Name = name;
            ID = id;
            Description = description;
            RetirementAges = retirementAges;
            Equalisation = equalisation;
            PenIncTables = pensionIncreases;
            Tranches = tranches;
            Franking = franking;
            Death = death;
            LEA = lea;
            CO = co;
            Accrual = accrual;
            SalLink = salLink;
            Underpin = underpin;
            LumpSum = lumpSum;
            PTXCalc_ConstructorCalcs();
        }

        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
            // Override this if required
        }
    }
}
