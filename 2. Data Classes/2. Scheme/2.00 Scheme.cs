using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents a scheme with its associated details.
    /// </summary>
    public class Scheme
    {
        /// <summary>
        /// The GUID of the scheme.
        /// </summary>
        [JsonProperty("GUID")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the scheme.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the scheme.
        /// </summary>
        [JsonProperty("ID")]
        public string ID { get; set; }

        /// <summary>
        /// Retrieves a BenSpec by its ID.
        /// </summary>
        /// <param name="BenSpecID">The ID of the BenSpec to retrieve.</param>
        /// <returns>The BenSpec with the specified ID, or null if not found.</returns>
        public BenSpec BenSpecID(string BenSpecID)
        {
            return BenSpecs.Find(BenSpec => BenSpec.ID == BenSpecID);
        }

        /// <summary>
        /// The list of benefit specifications associated with the scheme.
        /// </summary>
        [JsonProperty("BenSpecs")]
        public List<BenSpec> BenSpecs { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Scheme"/> class.
        /// </summary>
        public Scheme()
        {
            GUID = Guid.NewGuid();
            Name = string.Empty;
            ID = string.Empty;
            BenSpecs = new List<BenSpec>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Scheme"/> class with the specified parameters.
        /// </summary>
        /// <param name="name">The name of the scheme.</param>
        /// <param name="id">The ID of the scheme.</param>
        public Scheme(string name, string id)
        {
            GUID = Guid.NewGuid();
            Name = name;
            ID = id;
            BenSpecs = new List<BenSpec>();
            PTXCalc_ConstructorCalcs();
        }

        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
            // Override this if required
        }

        /// <summary>
        /// Adds a new benefit specification to the scheme.
        /// </summary>
        /// <param name="benSpec">The benefit specification to add.</param>
        public void AddBenSpec(BenSpec benSpec)
        {
            if (string.IsNullOrEmpty(benSpec.Name))
                throw new ArgumentException("The identifier cannot be null or empty.", nameof(benSpec.Name));

            if (benSpec == null)
                throw new ArgumentNullException(nameof(benSpec));

            BenSpecs.Add(benSpec);
        }
    }
}
