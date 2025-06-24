namespace PTXClassLibrary
{
    public class GenAddress
    {
        //public variables
        public string foreignIDentificator;
        //public List <string> AddressLineList { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; } = null;
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string AddressLine5 { get; set; }
        public string AddressLine6 { get; set; }
        public string Town { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; } //From ISOCountryCodes
        public string ISOCountryCode { get; set; }  //From ISOCountryCodes

        public string AddressAssertion { get; set; }
        //Other Like three word reference, Map function for tracing?

        public GenAddress()
        {
            AddressAssertion = "A";
        }

    }






}
