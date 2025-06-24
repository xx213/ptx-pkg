//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************

namespace PTXClassLibrary
{/// <summary>
/// Email Class
/// 
/// </summary>
    public class GenEmail
    {
        //NINO include last character
        public string Email { get; set; }
        //Excludes last character
        public string EmailAssertion { get; set; }

        public GenEmail()
        {

        }

        public GenEmail(string SetEmail)
        {
            //Check email contain @INO = SetNINO;
            Email = SetEmail;
            EmailAssertion = "A";
        }
    }
}
