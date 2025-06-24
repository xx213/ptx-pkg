namespace PTXClassLibrary
{
    internal abstract class Calc
    {
        public string RunID { get; private set; }
        public string ScmUID { get; private set; }
        public string MemUID { get; private set; }
        public string VersionUID { get; private set; }

        public string Inputs { get; set; }
        public string Outputs { get; set; }
        public string EWM { get; set; }

        public CalcDetailedAudit calcAudit { get; set; }

        // Abstract method to be implemented by derived classes
        public abstract void DoCalc();

        // Full constructor using strings
        public Calc(string runID, string scmUID, string memUID, string versionUID)
        {
            RunID = runID;
            ScmUID = scmUID;
            MemUID = memUID;
            VersionUID = versionUID;

            // Initialize Inputs, Outputs, and EWM
            Inputs = string.Empty;
            Outputs = string.Empty;
            EWM = string.Empty;

            // Generate RunUID
            GenerateRunUID();

        }

        private void GenerateRunUID()
        {
            RunID = $"{ScmUID}_{MemUID}_{VersionUID}";
        }
    }
}
