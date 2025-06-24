using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    abstract public class DBBase
    {
        #region Properties

        [JsonProperty("GUID")]
        public Guid GUID { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("UID")]
        public string UID { get; set; }


        [JsonProperty("VersionUID")]
        public string VersionUID { get; set; }

        [JsonProperty("ObjectDBAudit")]
        public DBAudit ObjectDBAudit { get; set; }



        #endregion

        #region Constructors

        public DBBase()
        {
            Type = "BaseConstructor";
            GUID = CalculateGUID();
            ObjectDBAudit = new DBAudit();
            ID = CalculateID();
            VersionUID = CalculateVersionUID();
            UID = CalculateUID();
        }

        public DBBase(string iD)
        {
            Type = "BaseConstructor";
            GUID = CalculateGUID();
            ObjectDBAudit = new DBAudit();
            ID = iD;
            VersionUID = CalculateVersionUID();
            UID = CalculateUID();
        }

        public abstract void UpdateTypeAndID();

        #endregion

        #region Methods
        protected virtual void UpdateUID()
        {
            // Replace this with your actual logic to calculate UID
            // For now, returning a placeholder value.
            UID = ID + "_" + VersionUID;
        }
        private Guid CalculateGUID()
        {
            // Add your logic to calculate GUID here
            return Guid.NewGuid();
        }

        protected string CalculateID()
        {
            // Add your logic to calculate ID here
            return "Abstract Temp ID";
        }

        protected string CalculateUID()
        {
            // Add your logic to calculate UID here
            return ID + "_" + VersionUID;

        }

        protected string CalculateGroupUID()
        {
            // Add your logic to calculate GroupUID here
            return "Group UID";
        }

        protected string CalculateVersionUID()
        {
            // Add your logic to calculate VersionUID here
            string formattedDateTime = ObjectDBAudit?.UpdateDateTime.ToString("yyyyMMddHHmmss") ?? string.Empty;
            return $"Import:{formattedDateTime}";
        }

        #endregion
    }
}
