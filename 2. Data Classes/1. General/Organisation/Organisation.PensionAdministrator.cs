//********************************
// Copyright RPM IT Consulting Ltd
// WWW.RPMITConsulting.com + //https://randomwalk.visualstudio.com/PTX
//********************************

using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Pension Administrator based on Organisation
    /// </summary>
    public class PensionAdministrator : Organisation
    {
        /// <summary>
        /// The reference of the administrator.
        /// </summary>
        public string AdministratorReference { get; set; }

        /// <summary>
        /// The name of the administrator.
        /// </summary>
        public string AdministratorName { get; set; }

        /// <summary>
        /// The contact preference of the administrator.
        /// </summary>
        public string AdminContactPreference { get; set; }

        /// <summary>
        /// The postal name of the administrator.
        /// </summary>
        public string AdminPostalName { get; set; }

        /// <summary>
        /// Default constructor for the PensionAdministrator class.
        /// </summary>
        public PensionAdministrator()
           : base()
        {

        }

        /// <summary>
        /// Parameterized constructor for the PensionAdministrator class.
        /// </summary>
        /// <param name="name">The name of the administrator.</param>
        /// <param name="id">The ID of the administrator.</param>
        /// <param name="description">The description of the administrator.</param>
        /// <param name="email">The email of the administrator.</param>
        /// <param name="phone">The phone number of the administrator.</param>
        /// <param name="address">The address of the administrator.</param>
        /// <param name="genURL">The URL of the administrator.</param>
        /// <param name="administratorReference">The reference of the administrator.</param>
        /// <param name="administratorName">The name of the administrator.</param>
        /// <param name="adminContactPreference">The contact preference of the administrator.</param>
        /// <param name="adminPostalName">The postal name of the administrator.</param>
        public PensionAdministrator(string name, string id, string description, GenEmail email, GenPhone phone, GenAddress address, string genURL, string administratorReference, string administratorName, string adminContactPreference, string adminPostalName)
            : base(name, id, description, email, phone, address, genURL)
        {
            AdministratorReference = administratorReference;
            AdministratorName = administratorName;
            AdminContactPreference = adminContactPreference;
            AdminPostalName = adminPostalName;
        }

        /// <summary>
        /// Implicit conversion from PDPPension.PDPPensionArrangement to PensionAdministrator.
        /// </summary>
        /// <param name="v">The PDPPension.PDPPensionArrangement instance to convert.</param>
        public static implicit operator PensionAdministrator(PDPPension.PDPPensionArrangement v)
        {
            throw new NotImplementedException();
        }
    }
}
