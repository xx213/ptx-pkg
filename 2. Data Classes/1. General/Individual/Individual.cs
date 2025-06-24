//-----------------------------------------------------------------------------
// File: Individual.cs
//-----------------------------------------------------------------------------
// Namespace: PTXClassLibrary
//-----------------------------------------------------------------------------
// Description: This file contains the Individual abstract class.
//-----------------------------------------------------------------------------
// List of functions: N/A
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
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Standard Individual Abstract Class.
    /// </summary>
    /// <remarks>
    /// This abstract class defines the basic attributes and properties of an individual.
    /// </remarks>
    public abstract class Individual
    {
        /// <summary>
        /// Date of Birth of the individual.
        /// </summary>
        /// <remarks>
        /// Represents the individual's date of birth.
        /// </remarks>
        public DateTime DOB { get; set; }

        /// <summary>
        /// Sex of the individual.
        /// </summary>
        /// <remarks>
        /// Represents the individual's sex (e.g., male, female).
        /// </remarks>
        public string Sex { get; set; }

        /// <summary>
        /// Gender of the individual.
        /// </summary>
        /// <remarks>
        /// Represents the individual's gender (e.g., Male, Female, Non-binary).
        /// </remarks>
        public Gender Gender { get; set; }

        /// <summary>
        /// Date at which all benefits are calculated from.
        /// </summary>
        /// <remarks>
        /// Represents the date at which all benefits are calculated from.
        /// </remarks>
        public DateTime CalcDate { get; set; }

        /// <summary>
        /// First year earnings of the individual.
        /// </summary>
        /// <remarks>
        /// Represents the individual's first year earnings.
        /// </remarks>
        public EarningsSY FirstYearEarnings { get; set; }

        /// <summary>
        /// Unique ID created using SHA256 cryptography.
        /// </summary>
        /// <remarks>
        /// Represents the individual's unique ID generated using SHA256 cryptography.
        /// </remarks>
        public string IndividualID { get; set; }

        /// <summary>
        /// Default constructor for the Individual class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes a new instance of the Individual class with default values.
        /// </remarks>
        public Individual()
        {
            PTXCalc_ConstructorCalcs();
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




    } // END of Class
}
