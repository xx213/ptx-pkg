// DIDModel.cs

using PTXClassLibrary;

namespace PTX.ClassLibrary
{
    public class DIS_Model : DBBase
    {
        public string EWM { get; set; }
        // Add other properties specific to DID_Model

        // Constructor
        public DIS_Model(string iD)
        {
            // Generate UID
            ID = iD;
            UID = $"{ID}_{VersionUID}";
        }

        public override void UpdateTypeAndID()
        {
            // Implement logic to update ErrMessage and ID if needed
        }
    }
}
