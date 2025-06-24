//********************************
// Copyright RPM IT Consulting Ltd
// WWW.RPMITConsulting.com  + https://randomwalk.visualstudio.com/PTX
//********************************

namespace PTXClassLibrary
{
    /// <summary>
    /// Public class to project Benefits - 
    /// ErrMessage of benefit is defined in the class   
    /// </summary>
    public abstract class BenefitProjection
    {
        #region Defaults - Developer input required
        string functionName = "BenefitsProjection";

        string sError;
        double dError;

        public CalcAudit CalcAuditObject = new CalcAudit();
        #endregion

        #region Basic Projection Info
        /// <summary>
        /// Gets or sets the projection name.
        /// </summary>
        /// <remarks>
        /// Represents the name of the benefit projection.
        /// </remarks>
        public string ProjName { get; set; }

        /// <summary>
        /// Gets or sets the Benefit_ProjSimple object.
        /// </summary>
        /// <remarks>
        /// Represents the ProjSimple object associated with the benefit projection.
        /// </remarks>
        public ProjSimple Benefit_ProjSimple { get; set; }
        #endregion

        #region Benefit Specific
        /// <summary>
        /// Gets or sets the type of benefit (e.g., CARE, DC, FS).
        /// </summary>
        /// <remarks>
        /// Represents the type of benefit, which determines the calculations to be performed.
        /// </remarks>
        public string BenefitType { get; set; }

        /// <summary>
        /// Gets or sets the accrual rate.
        /// </summary>
        /// <remarks>
        /// Represents the accrual rate for benefits, such as CARE and DB, as a fraction (e.g., 0.125 not 80ths).
        /// </remarks>
        public double AccrualRate { get; set; }

        /// <summary>
        /// Gets or sets the CARE starting balance.
        /// </summary>
        /// <remarks>
        /// Represents the starting balance for CARE benefits at the beginning of the projection (e.g., £1000).
        /// </remarks>
        public double CAREStartingBalance { get; set; }

        /// <summary>
        /// Gets or sets the starting salary.
        /// </summary>
        /// <remarks>
        /// Represents the starting salary for CARE, FS, and DC benefits (e.g., £1000).
        /// This property can be an input or a ProjSimple object.
        /// If it's an input, create the Salary_ProjSimple projection using SalaryProjections.
        /// </remarks>
        public double StartingSalary { get; set; }

        /// <summary>
        /// Gets or sets the Salary_ProjSimple object.
        /// </summary>
        /// <remarks>
        /// Represents the ProjSimple object associated with the starting salary projection.
        /// </remarks>
        public ProjSimple Salary_ProjSimple { get; set; }

        /// <summary>
        /// Gets or sets the DC starting balance.
        /// </summary>
        /// <remarks>
        /// Represents the starting balance for DC benefits at the beginning of the projection (e.g., £10000).
        /// </remarks>
        public double DCStartingBalance { get; set; }

        /// <summary>
        /// Gets or sets the starting service Y+fraction (e.g., 24.25).
        /// </summary>
        /// <remarks>
        /// Represents the starting service Y+fraction for FS benefits.
        /// </remarks>
        double StartingService { get; set; }
        #endregion

        #region Projection fields
        double AgeFrom = 0;
        double AgeTo = 121;
        #endregion

        /// <summary>
        /// Default constructor for the BenefitProjection class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes a new instance of the BenefitProjection class with default values.
        /// </remarks>
        public BenefitProjection()
        {
        }

        /// <summary>
        /// Method to perform constructor calculations using PTXCalc.
        /// </summary>
        /// <remarks>
        /// This method is used to calculate anything required using PTXCalc.
        /// </remarks>
        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
        }

        /// <summary>
        /// Method to calculate the benefit projection.
        /// </summary>
        /// <remarks>
        /// This method is used to calculate the benefit projection, determining the projection type, and assigning it to BenefitProjection.
        /// </remarks>
        public void CalcBenefitProjection()
        {
            // Use engine at this point
            // This is used to 
            // Step 1 Determine projection type

            // If CARE Run CalcCAREProjection
            // If DC Run CalcDCProjection
            // IF FS Run CalcFSProjection

            // Assign to BenefitProjection
        }

        /// <summary>
        /// Method to perform CARE benefit projections.
        /// </summary>
        /// <remarks>
        /// This method is used as an overload to perform CARE benefit projections.
        /// The actual calculations are done in the engine.
        /// </remarks>
        public void CalcCAREProjection()
        {

        }

        /// <summary>
        /// Method to perform FS benefit projections.
        /// </summary>
        /// <remarks>
        /// This method is used as an overload to perform FS benefit projections.
        /// The actual calculations are done in the engine.
        /// </remarks>
        public void CalcFSProjection()
        {

        }

        /// <summary>
        /// Method to perform DC benefit projections.
        /// </summary>
        /// <remarks>
        /// This method is used as an overload to perform DC benefit projections.
        /// The actual calculations are done in the engine.
        /// </remarks>
        public void CalcDCProjection()
        {

        }
    }
}
