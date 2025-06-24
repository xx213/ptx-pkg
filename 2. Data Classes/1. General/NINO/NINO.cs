//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************


using System;
namespace PTXClassLibrary
{
    /// <summary>
    /// /// NINO Class can be used
    /// Format : AA######A
    /// </summary>
    public class GenNINO
    {
        //NINO include last character
        public string NINO { get; set; }
        //Excludes last character
        public string NINOShort { get; set; }
        public string NINOAssertion { get; set; }

        public GenNINO()
        {
            NINO = null;
            NINOShort = null;
            NINOAssertion = null;
        }


        public GenNINO(string SetNINO)
        {
            NINO = SetNINO;
            NINOShort = SetNINO.Substring(0, Math.Min(8, SetNINO.Length));
            NINOAssertion = "A";//.List.
        }
    }
}
