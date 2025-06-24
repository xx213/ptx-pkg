//-----------------------------------------------------------------------------
// File: Assumptions.cs
//-----------------------------------------------------------------------------
// Namespace: PTXClassLibrary
//-----------------------------------------------------------------------------
// Description: This file contains the Assumptions class with CARE-related variables.
//-----------------------------------------------------------------------------
// Author: RPM IT Consulting Ltd
// Website: https://www.rpmitconsulting.com
// Website: https://www.pentechx.com
// Repository: https://randomwalk.visualstudio.com/PTX
//-----------------------------------------------------------------------------
// Version History:
//-----------------------------------------------------------------------------
// Version    | Author and Date    | Checker and Date | Description
//-----------------------------------------------------------------------------
// 1.000 #DEV | RPMIT dd/mm/yyyy   | USER dd/mm/yyyy  | Initial version
//-----------------------------------------------------------------------------

namespace PTXClassLibrary
{
    /// <summary>
    /// Assumptions class containing CARE-related variables.
    /// </summary>
    internal class Assumptions : PTXGlobals
    {
        /// <summary>
        /// Minimum Normal Pension Age (NPA) for CARE calculations.
        /// </summary>
        internal static double dCAREMinNPA = 55;

        /// <summary>
        /// Maximum Normal Pension Age (NPA) for CARE calculations.
        /// </summary>
        internal static double dCAREMaxNPA = 75;

        /// <summary>
        /// Minimum CARE salary for calculations.
        /// </summary>
        internal static double dCAREMinSalary = 0;

        /// <summary>
        /// Maximum CARE salary for calculations.
        /// </summary>
        internal static double dCAREMaxSalary = 150000;

        /// <summary>
        /// Minimum CARE accrual rate for calculations.
        /// </summary>
        internal static double dCAREMinAccrualRate = 0;

        /// <summary>
        /// Maximum CARE accrual rate for calculations.
        /// </summary>
        internal static double dCAREMaxAccrualRate = 0.15;

        /// <summary>
        /// Minimum CARE inflation for calculations.
        /// </summary>
        internal static double dCAREMinInfl = -0.25;

        /// <summary>
        /// Maximum CARE inflation for calculations.
        /// </summary>
        internal static double dCAREMaxInfl = 0.25;

        /// <summary>
        /// Minimum CARE joint pension percentage for calculations.
        /// </summary>
        internal static double dCAREMinJPen = -0.25;

        /// <summary>
        /// Maximum CARE joint pension percentage for calculations.
        /// </summary>
        internal static double dCAREMaxJPen = 0.25;

        /// <summary>
        /// Minimum CARE joint active percentage for calculations.
        /// </summary>
        internal static double dCAREMinJAct = -0.25;

        /// <summary>
        /// Maximum CARE joint active percentage for calculations.
        /// </summary>
        internal static double dCAREMaxJAct = 0.25;
    }
}
