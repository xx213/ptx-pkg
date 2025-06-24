using System;
using System.Collections.Generic;
namespace PTXClassLibrary
{
    /// <summary>
    /// Represents beneficiary specifications.
    /// </summary>
    public class BenSpec
    {
        /// <summary>
        /// The GUID of the beneficiary specification.
        /// </summary>
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the beneficiary specification.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ID of the beneficiary specification.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// The description of the beneficiary specification.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The categories associated with the beneficiary specification.
        /// </summary>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Default constructor for the BenSpec class.
        /// </summary>
        public BenSpec()
        {
            // Initialize any default values here
        }

        /// <summary>
        /// Constructor for the BenSpec class with parameters.
        /// </summary>
        /// <param name="guid">The GUID of the beneficiary specification.</param>
        /// <param name="name">The name of the beneficiary specification.</param>
        /// <param name="id">The ID of the beneficiary specification.</param>
        /// <param name="description">The description of the beneficiary specification.</param>
        /// <param name="categories">The categories associated with the beneficiary specification.</param>
        public BenSpec(string name, string id, string description, List<Category> categories)
        {
            GUID = Guid.NewGuid();
            Name = name;
            ID = id;
            Description = description;
            Categories = categories;
        }
        public BenSpec(string name, string id, string description)
        {
            GUID = Guid.NewGuid();
            Name = name;
            ID = id;
            Description = description;

            PTXCalc_ConstructorCalcs();
        }

        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
            // Override this if required
        }

    }
}
