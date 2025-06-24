//********************************
// Copyright RPM IT Consulting Ltd
// WWW.RPMITConsulting.com + //https://randomwalk.visualstudio.com/PTX
//********************************

using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Employer class based on Organisation
    /// </summary>
    public class Employer : Organisation
    {
        /// <summary>
        /// The start date of the employment.
        /// </summary>
        [JsonProperty("EmploymentStartDate")]
        public DateTime EmploymentStartDate { get; set; }

        /// <summary>
        /// The end date of the employment.
        /// </summary>
        [JsonProperty("EmploymentEndDate")]
        public DateTime EmploymentEndDate { get; set; }

        /// <summary>
        /// Default constructor for the Employer class.
        /// </summary>
        public Employer()
        {
            // Initialize properties
            EmploymentStartDate = DateTime.MinValue;
            EmploymentEndDate = DateTime.MinValue;
        }

        /// <summary>
        /// Parameterized constructor for the Employer class.
        /// </summary>
        /// <param name="name">The name of the employer.</param>
        /// <param name="id">The ID of the employer.</param>
        /// <param name="description">The description of the employer.</param>
        /// <param name="email">The email of the employer.</param>
        /// <param name="phone">The phone number of the employer.</param>
        /// <param name="address">The address of the employer.</param>
        /// <param name="genURL">The URL of the employer.</param>
        /// <param name="employmentStartDate">The start date of the employment.</param>
        /// <param name="employmentEndDate">The end date of the employment.</param>
        public Employer(string name, string id, string description, GenEmail email, GenPhone phone, GenAddress address, string genURL, DateTime employmentStartDate, DateTime employmentEndDate)
            : base(name, id, description, email, phone, address, genURL)
        {
            EmploymentStartDate = employmentStartDate;
            EmploymentEndDate = employmentEndDate;
        }
    }
}
