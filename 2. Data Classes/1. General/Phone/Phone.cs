//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************

namespace PTXClassLibrary
{/// <summary>
/// Phone Class
/// Could add in type (mobile etc)
/// </summary>
    public class GenPhone
    {
        //NINO include last character
        public string Phone { get; set; }
        public string PhoneAssertion { get; set; }
        public string PhoneType { get; set; } //Mobile etc

        public GenPhone()
        {

        }

        public GenPhone(string SetPhone)
        {

            Phone = SetPhone;
            PhoneAssertion = "A";
        }
    }

    public class Phones
    {
        public string Phone { get; set; }
        public string PhoneAssertion { get; set; }
        public string PhoneType { get; set; }
    }
}
