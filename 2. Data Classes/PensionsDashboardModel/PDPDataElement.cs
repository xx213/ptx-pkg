//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************


using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /* This class is use to hold data about each of the Pension Dashboard Data Elements
     * PDF Dec 2020
    */
    public class PDPDataElement
    {
        [JsonProperty("CalcAudit")]
        public double CalcAudit { get; set; }  //Format 3DP
        //Defines each of the PDP data elements and can be used as a library item.  It doesn't contains member data
        [JsonProperty("RefNumber")]
        public Double RefNumber { get; set; }  //Format 3DP
        [JsonProperty("PDPLevel1")]
        public string PDPLevel1 { get; set; } //PDPLevel1List
        [JsonProperty("PDPLevel2")]
        public string PDPLevel2 { get; set; } //PDPLevel2List
        [JsonProperty("Name")]
        public String Name { get; set; }
        [JsonProperty("Purpose")]
        public String Purpose { get; set; }
        [JsonProperty("Description")]
        public String Description { get; set; }
        [JsonProperty("Format")]
        public String Format { get; set; } = null;
        [JsonProperty("PTXDataTypeName")]
        public string DataType { get; set; } = null; //  Double etc
        [JsonProperty("MinimumLength")]
        public int MinimumLength { get; set; }
        [JsonProperty("MaximumLength")]
        public int MaximumLength { get; set; }
        public string Validation { get; set; } = null;
        public string Optionality { get; set; } //Optional, Mandatory, Conditional, PDPOptionalityList
        public string OptionalityNotes { get; set; } = null;
        public String Multiplicity { get; set; } //1..* etc
        public String MultiplicityNotes { get; set; } = null;


        //Fixed newValue(s)
        public String FixedValue { get; set; }//YesNoList
        public String FixedValueList1 { get; set; } = null; //Comma Separated
        public String FixedValueList2 { get; set; } = null;//Comma Separated
        //public String List[][] FixedValues { get; set; }
        public String FixedValuesString { get; set; } = null;

        //Required to map to PTXApp Sytem variables
        public String PTXSystemName { get; set; } = null;



        //Errors
        internal string sError { get; set; }
        internal double dError { get; set; }

        //Contains Infos about this class and a description 
        public string PDPStandardDataElementDescription { get; set; }

        //PDP Statement
        public string PDPStatement { get; set; }



        //Allowable ref number are stored in he list             PDPRefNumberList
        //Constructor to return the Data Element by refNumber 
        public PDPDataElement()
        {
            PDPStatement = "This information is based on the document Data Standards Guide, Dec 2020 produced by the Pensions Dashboard Programme.  " +
                "Whilst all reasonable efforts have been made to ensure the accuracy of this website, errors may sometimes occur.  Please report any issues to RPM IT Consulting as soon as possible.  RPM IT Consulting accepts no liability arising from inaccuracies or omissions in this this website, blog and attached documents, and reserves the right to revise the contents without Notice.";
        }
    }


}
