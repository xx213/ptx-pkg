using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PTXClassLibrary
{
    /// <summary>
    /// Base class for various instances audit records, used to track changes or events in the system.
    /// </summary>
    public abstract class AuditInstanceBase
    {
        /// <summary>
        /// The GUID of the audit record.
        /// </summary>
        [JsonProperty("GUID")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The UID (User ID) associated with the audit record.
        /// </summary>
        [JsonProperty("UID")]
        public string UID { get; set; }

        /// <summary>
        /// Error Message associated with the audit record, if any.
        /// </summary>
        [JsonProperty("ErrMessage")]
        public string ErrMessage { get; set; }

        /// <summary> 
        /// 
        /// 
        ///  minnieX
        /// The type of the audit record, indicating the process or action that triggered the audit.
        /// </summary>
        [JsonProperty("AuditType")]
        public string AuditType { get; set; }

        /// <summary>
        /// The time stamp of when the audit record was updated.
        /// </summary>
        [JsonProperty("UpdateDateTime")]
        public DateTime UpdateDateTime { get; set; }

        /// <summary>
        /// The user who made the audit record.
        /// </summary>
        [JsonProperty("UserID")]
        public string UserID { get; set; }

        /// <summary>
        /// The description of the audit record, providing additional context about the action or event.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// List of audit history items, recording the chronological sequence of events related to the audit.
        /// </summary>
        [JsonProperty("AuditInstanceHistory")]
        public List<string> AuditInstanceHistory { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditInstanceBase"/> class with default values.
        /// </summary>
        /// <param name="auditType">The type of audit record indicating the process or action.</param>
        protected AuditInstanceBase(string auditType)
        {
            GUID = Guid.NewGuid();
            AuditType = auditType;
            UpdateDateTime = DateTime.Now;
            UID = GenerateUID();
            UserID = string.Empty;
            Description = string.Empty;
            AuditInstanceHistory = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditInstanceBase"/> class with specified values.
        /// </summary>
        /// <param name="auditType">The type of audit record indicating the process or action.</param>
        /// <param name="auditTypeDescription">The description of the audit type.</param>
        protected AuditInstanceBase(string auditType, string auditTypeDescription)
        {
            GUID = Guid.NewGuid();
            AuditType = auditType;
            UpdateDateTime = DateTime.Now;
            UID = GenerateUID();
            UserID = "User Unknown";
            Description = auditTypeDescription;
            AuditInstanceHistory = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditInstanceBase"/> class with specified values.
        /// </summary>
        /// <param name="auditType">The type of audit record indicating the process or action.</param>
        /// <param name="updateDateTime">The time stamp of when the audit record was updated.</param>
        /// <param name="userID">The user who made the audit record.</param>
        /// <param name="description">The description of the audit record.</param>
        protected AuditInstanceBase(string auditType, DateTime updateDateTime, string userID, string description)
        {
            GUID = Guid.NewGuid();
            AuditType = auditType;
            UpdateDateTime = updateDateTime;
            UID = GenerateUID();
            UserID = userID;
            Description = description;
            AuditInstanceHistory = new List<string>();
        }

        /// <summary>
        /// Adds a new item to the AuditInstanceHistory list, representing a chronological event or action.
        /// </summary>
        /// <param name="historyItem">The item to add to the AuditInstanceHistory list.</param>
        public void AddToAuditHistory(string historyItem)
        {
            AuditInstanceHistory.Add(historyItem);
        }

        private string GenerateUID()
        {
            // Generate the UID by combining AuditType and UpdateDateTime
            return $"{AuditType}_{UpdateDateTime.ToString("yyyyMMddHHmmss")}";
        }
    }
}
