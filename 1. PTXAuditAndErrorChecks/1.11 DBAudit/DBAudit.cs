using Newtonsoft.Json;
using PTXClassLibrary;
using System;

public class DBAudit : AuditBase
{
    /// <summary>
    /// Gets or sets the filename associated with the audit record (optional).
    /// </summary>
    [JsonProperty("Filename")]
    public string Filename { get; set; }

    /// <summary>
    /// Gets or sets the file location of the audit record (optional).
    /// </summary>
    [JsonProperty("FileLocation")]
    public string FileLocation { get; set; }

    /// <summary>
    /// Gets or sets the file version of the audit record (optional).
    /// </summary>
    [JsonProperty("FileVersion")]
    public string FileVersion { get; set; }

    /// <summary>
    /// Gets or sets the type associated with the audit record (optional).
    /// </summary>
    [JsonProperty("Type")]
    public string Type { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DBAuditInstance"/> class with default values.
    /// </summary>
    public DBAudit() : base("AuditBase") { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DBAuditInstance"/> class with specified values.
    /// </summary>
    /// <param name="updateDateTime">The time stamp of when the audit record was updated.</param>
    /// <param name="userID">The user who made the audit record.</param>
    /// <param name="description">The description of the audit record.</param>
    /// <param name="filename">The filename associated with the audit record (optional).</param>
    /// <param name="fileLocation">The file location of the audit record (optional).</param>
    /// <param name="fileVersion">The file version of the audit record (optional).</param>
    public DBAudit(DateTime updateDateTime, string userID, string description, string filename = null, string fileLocation = null, string fileVersion = null, string type=null)
        : base("DBAudit", updateDateTime, userID, description)
    {
        Filename = filename;
        FileLocation = fileLocation;
        FileVersion = fileVersion;
        Type = Type;
    }
}
