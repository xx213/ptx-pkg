//********************************
// Copyright RPM IT Consulting Ltd
// WWW.RPMITConsulting.com + //https://randomwalk.visualstudio.com/PTX
//********************************

using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Abstract Organizations
    /// </summary>
    public abstract class Organisation
    {
        protected Organisation()
        {
        }

        protected Organisation(string name, string id, string description, GenEmail email, GenPhone phone, GenAddress address, string genURL)
        {
            Name = name;
            ID = id;
            Description = description;
            Email = email;
            Phone = phone;
            Address = address;
            GenURL = genURL;
        }

        /// <summary>
        /// The GUID of the organization.
        /// </summary>
        [JsonProperty("GUID")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the organization.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the organization.
        /// </summary>
        [JsonProperty("ID")]
        public string ID { get; set; }

        /// <summary>
        /// The description of the organization.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// The email of the organization.
        /// </summary>
        [JsonProperty("Email")]
        public GenEmail Email { get; set; }

        /// <summary>
        /// The phone number of the organization.
        /// </summary>
        [JsonProperty("Phone")]
        public GenPhone Phone { get; set; }

        /// <summary>
        /// The address of the organization.
        /// </summary>
        [JsonProperty("Address")]
        public GenAddress Address { get; set; }

        /// <summary>
        /// The URL of the organization.
        /// </summary>
        [JsonProperty("GenURL")]
        public string GenURL { get; set; }


    }

    //public 
}
