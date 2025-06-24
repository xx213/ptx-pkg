using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents a tranche with various properties and conditions.
    /// Standard XPS BenSpc.CategoryTracnches are:
    /// 1. tran78to88StatPre88GMP
    /// 2. tran88to97StatPost88GMP
    /// 3. tranPre97XS1
    /// 4. tranPre97XS2
    /// 5. tranPre97XS3
    /// </summary>
    public class Tranche
    {
        /// <summary>
        /// The GUID of the tranche.
        /// </summary>
        [JsonProperty("GUID")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the tranche.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the tranche.
        /// </summary>
        [JsonProperty("ID")]
        public string ID { get; set; }

        /// <summary>
        /// The description of the tranche.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// The option for GMP (Guaranteed Minimum Pension) revaluation.
        /// Allowed values: GMPRevaluation options (e.g., "Pre88GMP").
        /// </summary>
        public string GMPDefRev { get; set; }

        /// <summary>
        /// The option for excess revaluation.
        /// Allowed values: XSRevaluation options (e.g., "Pre88GMP").
        /// </summary>
        public string XSDefRev { get; set; }

        /// <summary>
        /// The option for excess revaluation when DOR (Date of Retirement) is under GMP Age.
        /// Allowed values: GMPRevaluationDORUnderGMPA options.
        /// </summary>
        public string XSDefRevDORUnderGMPA { get; set; }

        private DateTime accrualStartDate;
        /// <summary>
        /// The start date of the accrual period.
        /// </summary>
        [JsonProperty("AccrualStartDate")]
        public DateTime AccStartDate
        {
            get { return accrualStartDate; }
            set
            {
                accrualStartDate = value;
                RecalculateNumDays();
            }
        }

        private DateTime accrualEndDate;
        /// <summary>
        /// The end date of the accrual period.
        /// Must be greater than or equal to the AccStartDate.
        /// </summary>
        [JsonProperty("AccrualEndDate")]
        public DateTime AccEndDate
        {
            get { return accrualEndDate; }
            set
            {
                accrualEndDate = value;
                RecalculateNumDays();
            }
        }

        /// <summary>
        /// The option for statutory GMP (Guaranteed Minimum Pension) increases.
        /// Allowed values: Apply Scheme or Statutory GMP LRF.
        /// </summary>
        public string ScmorStatLRF { get; set; }

        /// <summary>
        /// The option for non-statutory excess increase XS element.
        /// </summary>
        public string NonStatXS { get; set; }

        /// <summary>
        /// The pension increase table associated with the tranche.
        /// </summary>
        [JsonProperty("PenIncTable")]
        public PenIncTable PenIncTable { get; set; }

        private int numDays;
        /// <summary>
        /// The number of days between the start and end dates.
        /// </summary>
        [JsonProperty("NumDays")]
        public int NumDays
        {
            get { return numDays; }
            private set { numDays = value; }
        }

        /// <summary>
        /// Default constructor for the Tranche class.
        /// </summary>
        public Tranche()
        {
            GUID = Guid.NewGuid();
            Name = string.Empty;
            ID = string.Empty;
            Description = string.Empty;
            PenIncTable = new PenIncTable();
            AccStartDate = new DateTime(1900, 1, 1);
            AccEndDate = new DateTime(2099, 12, 31);
            RecalculateNumDays();
        }

        /// <summary>
        /// Creates a new instance of the Tranche class with the specified name and ID.
        /// </summary>
        /// <param name="name">The name of the tranche.</param>
        /// <param name="id">The ID of the tranche.</param>
        public Tranche(string name, string id, string description)
        {
            GUID = Guid.NewGuid();
            Name = name;
            ID = id;
            PenIncTable = new PenIncTable();
            Description = string.Empty;
            AccStartDate = new DateTime(1900, 1, 1);
            AccEndDate = new DateTime(2099, 12, 31);
            RecalculateNumDays();
        }

        /// <summary>
        /// Creates a new instance of the Tranche class with the specified parameters.
        /// </summary>
        /// <param name="name">The name of the tranche.</param>
        /// <param name="id">The ID of the tranche.</param>
        /// <param name="accrualStartDate">The start date of the accrual period.</param>
        /// <param name="accrualEndDate">The end date of the accrual period.</param>
        /// <param name="penIncTable">The pension increase table associated with the tranche.</param>
        public Tranche(string name, string id, DateTime accrualStartDate, DateTime accrualEndDate, PenIncTable penIncTable)
        {
            GUID = Guid.NewGuid();
            Name = name;
            ID = id;
            PenIncTable = penIncTable;
            Description = string.Empty;
            AccStartDate = accrualStartDate;
            AccEndDate = accrualEndDate;
            RecalculateNumDays();
        }

        /// <summary>
        /// Creates a new instance of the Tranche class with the specified parameters.
        /// </summary>
        /// <param name="name">The name of the tranche.</param>
        /// <param name="id">The ID of the tranche.</param>
        /// <param name="accrualStartDate">The start date of the accrual period.</param>
        /// <param name="accrualEndDate">The end date of the accrual period.</param>

        public Tranche(string name, string id, DateTime accrualStartDate, DateTime accrualEndDate)
        {
            GUID = Guid.NewGuid();
            Name = name;
            ID = id;

            Description = string.Empty;
            AccStartDate = accrualStartDate;
            AccEndDate = accrualEndDate;
            RecalculateNumDays();
            PTXCalc_ConstructorCalcs();
        }

        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
            // Override this if required
        }

        /// <summary>
        /// Recalculates the number of days between the start and end dates.
        /// </summary>
        private void RecalculateNumDays()
        {
            NumDays = (AccEndDate - AccStartDate).Days;
        }


    }
}
