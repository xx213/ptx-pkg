using PTXClassLibrary;

namespace PTX.ClassLibrary
{
    public class PenInc_Model : DBBase
    {
        public string SomePenIncProperty { get; set; }
        // Add other properties specific to PenInc_Model

        // Constructor
        public PenInc_Model(string iD)
            : base(iD)
        {
            // Generate UID
            UID = $"{ID}_{VersionUID}";
        }

        public override void UpdateTypeAndID()
        {
            // Implement logic to update ErrMessage and ID if needed
        }
    }
}
