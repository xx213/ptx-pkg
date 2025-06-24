using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PTXClassLibrary
{
    /// <summary>
    /// Base class for various audit records.
    /// </summary>
    public abstract class AuditBase
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
        /// Error Message
        /// </summary>
        [JsonProperty("ErrMessage")]
        public string ErrMessage { get; set; }

        /// <summary>
        /// The type of the audit record.
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
        /// The description of the audit record.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// List of audit history items.
        /// </summary>
        [JsonProperty("AuditHistory")]
        public List<string> AuditHistory { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditBase"/> class with default values.
        /// </summary>
        protected AuditBase(string auditType)
        {
            GUID = Guid.NewGuid();
            AuditType = auditType;
            UpdateDateTime = DateTime.Now;
            UID = GenerateUID();
            UserID = string.Empty;
            Description = string.Empty;
            AuditHistory = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditBase"/> class with specified values.
        /// </summary>
        protected AuditBase(string auditType, DateTime updateDateTime, string userID, string description)
        {
            GUID = Guid.NewGuid();
            AuditType = auditType;
            UpdateDateTime = updateDateTime;
            UID = GenerateUID();
            UserID = userID;
            Description = description;
            AuditHistory = new List<string>();
        }

        /// <summary>
        /// Adds a new item to the AuditHistory list.
        /// </summary>
        /// <param name="historyItem">The item to add to the AuditHistory list.</param>
        public void AddToAuditHistory(string historyItem)
        {
            AuditHistory.Add(historyItem);
        }

        private string GenerateUID()
        {
            // Generate the UID by combining AuditType and UpdateDateTime
            return $"{AuditType}_{UpdateDateTime.ToString("yyyyMMddHHmmss")}";
        }
    }
}
