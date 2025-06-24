//********************************
// Copyright RPM IT Consulting Ltd
// WWW.RPMITConsulting.com
// https://randomwalk.visualstudio.com/PTX
//********************************
using System.Collections.Generic;
using System.Linq;

namespace PTXClassLibrary
{
    public class BulkDataTypeCorrectionResult
    {
        public  List<dynamic[]> dynFinalData { get; set; } // Object to summarize the updated Data in 2D Format
        public  List<string[]> strFinalData { get; set; } // Object to summarize the updated Data in 2D Format
        public  List<dynamic[]> typeFinalData { get; set; } // Object to summarize the updated Data in 2D Format
        public  List<string[]> htmlFinalData { get; set; } // Object to summarize the updated Data in 2D Format
        public  List<dynamic[]> errFinalData { get; set; } // Object to summarize the updated Data in 2D Format
        public  string strFinalData_Encrypted { get; set; }

        // Initialize and populate final data lists
        public void InitialiseFinalData(List<string[]> inlistData)
        {
            dynFinalData = new List<dynamic[]>(1) { inlistData.First() };
            strFinalData = new List<string[]>(1) { inlistData.First() };
            typeFinalData = new List<dynamic[]>(1) { inlistData.First() };
            errFinalData = new List<dynamic[]>(1) { inlistData.First() };
            htmlFinalData = new List<string[]>(1) { inlistData.First() };
        }
    }
}
