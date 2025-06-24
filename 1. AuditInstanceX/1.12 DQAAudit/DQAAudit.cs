//using Newtonsoft.Json;
//using System;

//namespace PTXClassLibrary
//{
//    /// <summary>
//    /// Data Quality Assurance audit class used to replicate the table: DQAAudit.dbo
//    /// </summary>
//    public class DQAAudit
//    {
//        /// <summary>
//        /// The GUID of the DQAAudit record.
//        /// </summary>
//        [JsonProperty("DQAUID")]
//        public Guid DQAUID { get; set; }

//        /// <summary>
//        /// The UID (User ID) associated with the audit record.
//        /// </summary>
//        [JsonProperty("UID")]
//        public string UID { get; set; }

//        /// <summary>
//        /// The type of the audit record.
//        /// CalcAudit, DQAAudit, DBAuditInstance
//        /// </summary>
//        [JsonProperty("ErrMessage")]
//        public string ErrMessage { get; set; }

//        /// <summary>
//        /// The time stamp of when the audit record was updated.
//        /// </summary>
//        [JsonProperty("UpdateDateTime")]
//        public DateTime UpdateDateTime { get; set; }

//        /// <summary>
//        /// The user who made the audit record.
//        /// </summary>
//        [JsonProperty("UserID")]
//        public string UserID { get; set; }

//        /// <summary>
//        /// The description of the audit record.
//        /// </summary>
//        [JsonProperty("DQADescription")]
//        public string DQADescription { get; set; }

//        /// <summary>
//        /// The error message associated with the audit record.
//        /// </summary>
//        [JsonProperty("DQAErrMessage")]
//        public string DQAErrMessage { get; set; }

//        /// <summary>
//        /// Initializes a new instance of the <see cref="DQAAudit"/> class with default values.
//        /// </summary>
//        public DQAAudit()
//        {
//            DQAUID = Guid.NewGuid();
//            ErrMessage = "UnknownAuditType";
//            UpdateDateTime = DateTime.Now;
//            UID = GenerateUID();
//            UserID = string.Empty;
//            DQADescription = string.Empty;
//            DQAErrMessage = string.Empty;
//        }

//        public DQAAudit(string dqaType)
//        {
//            DQAUID = Guid.NewGuid();
//            ErrMessage = dqaType;
//            UpdateDateTime = DateTime.Now;
//            UID = GenerateUID();
//            UserID = string.Empty;
//            DQADescription = string.Empty;
//            DQAErrMessage = string.Empty;
//        }

//        /// <summary>
//        /// Initializes a new instance of the <see cref="DQAAudit"/> class with specified values.
//        /// </summary>
//        public DQAAudit(string dqaType, DateTime updateDateTime, string userID, string dqaDescription, string dqaErrMessage = null)
//        {
//            DQAUID = Guid.NewGuid();
//            ErrMessage = dqaType;
//            UpdateDateTime = updateDateTime;
//            UID = GenerateUID();
//            UserID = userID;
//            DQADescription = dqaDescription;
//            DQAErrMessage = dqaErrMessage;
//        }

//        private string GenerateUID()
//        {
//            // Generate the UID by combining ErrMessage and UpdateDateTime
//            return $"{ErrMessage}_{UpdateDateTime.ToString("yyyyMMddHHmmss")}";
//        }
//    }
//}
using PTXClassLibrary;

using System;

/// <summary>
/// Child class for DQAAudit.
/// </summary>
public class DQAAudit : AuditBase
{
    // Properties specific to DQAAudit

    public DQAAudit() : base("DQAAudit") { }

    public DQAAudit(DateTime updateDateTime, string userID, string dqaDescription, string dqaErrMessage = null)
        : base("DQAAudit", updateDateTime, userID, dqaDescription)
    {
        // Additional initialization if needed
    }
}