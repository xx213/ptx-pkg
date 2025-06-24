// DARModel.cs

using PTXClassLibrary;

namespace PTX.ClassLibrary
{
    public class DAR_Model : DBBase
    {


        public string EWM { get; set; }
        public double Spspc { get; set; }
        public string Gtee { get; set; }


        // Constructor
        public DAR_Model(string iD)
        {
            // Generate UID
            ID = iD;
            UID = $"{ID}_{VersionUID}";
        }



        public override void UpdateTypeAndID()
        {
            {
                throw new System.NotImplementedException();
            }


        }
    }
}
