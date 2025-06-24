using Newtonsoft.Json;
using PTXClassLibrary;
using System;

/// <summary>
/// Child class for CalcAudit.
/// </summary>
public class CalcAudit : AuditBase
{
    // Properties specific to CalcAudit

    /// <summary>
    /// Gets or sets additional row information for CalcAudit.
    /// </summary>
    [JsonProperty("CalcAuditAddRow")]
    public string CalcAuditAddRow { get; set; }

    [JsonProperty("CalcAuditString")]
    public string CalcAuditString { get; set; }

    public CalcAudit() : base("CalcAudit") { }

    public CalcAudit(DateTime updateDateTime, string userID, string description, string calcAuditAddRow = null)
        : base("CalcAudit", updateDateTime, userID, description)
    {
        CalcAuditAddRow = calcAuditAddRow;
        // Additional initialization if needed
    }
}
