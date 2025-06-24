//********************************
//Copyright RPM IT Consulting Ltd
//WWW.RPMITConsulting.com  + //https://randomwalk.visualstudio.com/PTX
//********************************

using System.Collections.Generic;

namespace PTXClassLibrary
{

    //List all Global Variables used int PTXClassLibrary

    internal class Lists : PTXGlobals
    {
        //Lists uded for validation, drop downs etc

        public List<string> YesNoList = new List<string>() { "Yes", "No", "Days" };

        public List<string> YMDList = new List<string>() { "Years", "Months", "Days" };
        public List<string> GenderList = new List<string>() { "Male", "Female", "Other" };
        public List<string> DropDownDummy = new List<string>() { "Dummy" };
        public List<string> Mort1dList = new List<string>() { "PMA92_B_1977", "CFA00LC Floor of 0pc", "AM80", "CMA00LCFloorof0_B_1977", "PNMA00", "PNFA00", "All1", "AllZero", };


        //PensionsDashboards
        public List<string> PDPOptionalityList = new List<string>() { "Years", "Months", "Days" };
        public static List<string> PDPRefNumberList = new List<string>()
        {
            "1.001","1.002","1.003","1.004","1.005","1.006","1.007","1.008","1.009","1.01","1.011","1.012","1.013","1.014","1.015","1.016","1.017","1.018","1.019","1.02","1.021","2.001","2.002","2.003","2.004","2.005","2.006","2.007","2.008","2.101","2.102","2.103","2.104","2.105","2.106","2.107","2.108","2.109","2.11","2.111","2.112","2.113","2.114","2.201","2.202","2.203","2.301","2.302","2.303","2.304","2.305","2.306","2.307","2.308","2.401","2.402","2.403","2.404","2.405","2.406","2.407","2.501","2.502","2.503","2.504"
        };
        public List<string> PDPLevel1List = new List<string>()
        {
            "1.### Find Data",
            "2.### View"
        };
        public List<string> PDPLevel2List = new List<string>()
        {
            "1.0## Find Data",
            "2.0## Pension Arrangement Data",
            "2.1## Pension Administrator Details",
            "2.2## Employer Details",
            "2.3## Estimated Retirement Income (ERI) Data",
            "2.4## Accrued Pension Data",
            "2.5## Additional Data (Signposts)"
        };




    }
}