using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents a group of pension increase models available to the scheme.
    /// </summary>
    public class PenIncTable
    {
        /// <summary>
        /// The GUID of the pension increase table.
        /// </summary>
        [JsonProperty("GUID")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the pension increase table.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the pension increase table (defined in the Pen inc table as 'row').
        /// </summary>
        [JsonProperty("ID")]
        public string ID { get; set; }

        /// <summary>
        /// The description of the pension increase table.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Retrieves a PenInc_Model by its ID.
        /// </summary>
        /// <param name="penIncModelID">The ID of the PenInc_Model to retrieve.</param>
        /// <returns>The PenInc_Model with the specified ID, or null if not found.</returns>
        public PenIncModel GetPenIncModelByID(string PenIncModelID)
        {
            return PenIncModels.Find(PenIncModel => PenIncModel.ID == PenIncModelID);
        }

        /// <summary>
        /// The collection of pension increase models in the table.
        /// </summary>
        [JsonProperty("PenInc_Model")]
        public List<PenIncModel> PenIncModels { get; set; }

        /// <summary>
        /// Default constructor for the PenIncTable class.
        /// </summary>
        public PenIncTable()
        {
            GUID = Guid.NewGuid();
            Name = string.Empty;
            ID = string.Empty;
            Description = string.Empty;
            PenIncModels = new List<PenIncModel>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PenIncTable"/> class.
        /// </summary>
        /// <param name="guid">The GUID of the pension increase table.</param>
        /// <param name="name">The name of the pension increase table.</param>
        /// <param name="id">The ID of the pension increase table.</param>
        /// <param name="description">The description of the pension increase table.</param>
        /// <param name="penIncModels">The collection of pension increase models in the table.</param>
        public PenIncTable(Guid guid, string name, string id, string description, List<PenIncModel> penIncModels)
        {
            GUID = guid;
            Name = name;
            ID = id;
            Description = description;
            PenIncModels = penIncModels;
            PTXCalc_ConstructorCalcs();
        }

        public void PTXCalc_ConstructorCalcs()
        {
            // This is used to calculate anything required using PTXCalc
            // Override this if required
        }
    }
}
