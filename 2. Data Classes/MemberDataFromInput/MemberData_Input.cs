//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PTXClassLibrary
{
    public class MemberData_Input

    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateJoinedScheme { get; set; }

        public string PempID { get; set; }
        public string SchemeID { get; set; }
        public string SchemeName { get; set; }
        public DateTime DateOfExtract { get; set; }
        public DateTime EffectiveDateOfPensionsInPayment { get; set; }
        public DateTime PaidUpToDate { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime CurrentStatusDate { get; set; }
        public string CurrentSubStatus { get; set; }
        public string NiNo { get; set; }
        public string Surname { get; set; }
        public string Initial { get; set; }
        public string CurrentCategory { get; set; }
        public string BenSpecCatGUID { get; set; }
        public string MemberGender { get; set; }
        public DateTime MemberDateOfBirth { get; set; }
        public string Dependant { get; set; }
        public bool LinkExistsToDeceasedRecord { get; set; }
        public string LinkedDeceasedMemberID { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string SpouseSex { get; set; }
        public DateTime DependantDateOfBirth { get; set; }
        public bool ChildsPensionIndicator { get; set; }
        public DateTime DateCommencedPensionableService { get; set; }





        public DateTime DateOfLeavingActiveStatus { get; set; }
        public DateTime DateOfReturn { get; set; }


        Dictionary<string, Type> fieldTypes = new Dictionary<string, Type>
        {
            { "PempID", typeof(int) },
            { "SchemeID", typeof(string) },
            { "SchemeName", typeof(string) },
            { "DateOfExtract", typeof(DateTime) },
            { "EffectiveDateOfPensionsInPayment", typeof(DateTime) },
            { "PaidUpToDate", typeof(DateTime) },
            { "CurrentStatus", typeof(string) },
            { "CurrentStatusDate", typeof(DateTime) },
            { "CurrentSubStatus", typeof(string) },
            { "NiNo", typeof(string) },
            { "Surname", typeof(string) },
            { "Initial", typeof(string) },
            { "CurrentCategory", typeof(string) },
            { "BenSpecCatGUID", typeof(string) },
            { "MemberGender", typeof(string) },
            { "MemberDateOfBirth", typeof(DateTime) },
            { "Dependant", typeof(string) },
            { "LinkExistsToDeceasedRecord", typeof(bool) },
            { "LinkedDeceasedMemberID", typeof(string) },
            { "DateOfDeath", typeof(DateTime) },
            { "SpouseSex", typeof(string) },
            { "DependantDateOfBirth", typeof(DateTime) },
            { "ChildsPensionIndicator", typeof(bool) },
            { "DateCommencedPensionableService", typeof(DateTime) },
            { "DateJoinedScheme", typeof(DateTime) },
            { "DateOfLeavingActiveStatus", typeof(DateTime) },
            // ... Add more field names and data types as needed
        };

        public MemberData_Input()
        {
        }

        // Example: Get the data type of the "PempID" field
        //        ErrMessage dataTypeOfPempID = fieldTypes["PempID"];

        //Console.WriteLine($"Data type of PempID: {dataTypeOfPempID}");
    }
}



