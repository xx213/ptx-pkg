
//using System.Collections.Generic;



//namespace PTXClassLibrary
//{
//    public class ResultDataModel
//    {
//        /// <summary>
//        /// Indicates whether the calculation passed or failed.
//        /// </summary>
//        public bool Pass { get; set; } = false;

////**************************** simple section
// ///<summary>
//        /// A double result value.
//        /// </summary>
//        public double DblRes001 { get; set; } = 0;

//        /// <summary>
//        /// A dynamic result value.
//        /// </summary>
//        public dynamic DynRes001 { get; set; }

//        /// <summary>
//        /// A string result specifically for a field name.
//        /// </summary>
//        public dynamic StrFN001 { get; set; }

//        /// <summary>
//        /// A dynamic result specifically for a field name value.
//        /// </summary>
//        public dynamic DynFN001 { get; set; }

//        /// <summary>
//        /// The double result value.
//        /// </summary>
//        public double DblRes002 { get; set; } = 0;

//        /// <summary>
//        /// A string value.
//        /// </summary>
//        public double StrRes001 { get; set; } = 0;

//        //**************************** END simple section

//        //CalcResultsDataS arrays
//        /// <summary>
//        /// An array of results containing generic values.
//        /// The first column relates to the field name or result, and the second column to the value <dynamic>.
//        /// | Result/FieldName          | newValue <dynamic>
//        /// +-------------+-------------------------------------------+-------------------------------------+---------------------+
//        /// | PenDOL                    | 100.00    (double)
//        /// | PenSal                    | [500,200,300]
//        /// 
//        /// 
//        /// 

//        public CalcResultDataArray ResultDataArray { get; set; }

//        public class CalcResultData
//        {
//            public bool testPass { get; set; }

//            public string OrigValue { get; set; }
//            public string FieldName { get; set; }

//            public string[] FieldNamesMissing { get; set; }
//            public dynamic NewValue { get; set; }
//            public string Notes { get; set; }
//            public List<string> ewmListMessage { get; set; }
//        }

//        public class CalcResultDataArray
//        {
//            public List<CalcResultData> CalcResultsDataS { get; set; } = new List<CalcResultData>();

//            // Add a new row to the array with the specified field name and value
//            public void AddRow(string fieldName, string origValue, dynamic newValue, bool testPass = false, string notes = "", List<string> EwmListMessage=null)
//            {
//                CalcResultsDataS.Add(new CalcResultData
//                {
//                    FieldName = fieldName,
//                    OrigValue = origValue,
//                    NewValue = newValue,
//                    testPass = testPass,
//                    Notes = notes,
//                    ewmListMessage = EwmListMessage
//                });
//                ;
//            }

//            //<summary>
//            /// Simple Constructor
//            /// </summary>
//            /// <param name="fieldName"></param>
//            public void AddRow(string fieldName)
//            {
//                CalcResultsDataS.Add(new CalcResultData
//                {
//                    FieldName = fieldName

//                });
//            }
//        }

//        /// <summary>
//        /// Constructor with parameters to initialize Pass, DblRes001, and DblRes002.
//        /// Implementation:
//        /// ResultDataModel resultModel = new ResultDataModel();
//        /// resultModel.ResultDataArray.AddRow("PenDOL", 100.00);
//        /// resultModel.ResultDataArray.AddRow("PenSal", new List<int> { 500, 200, 300 });
//        /// </summary>
//        /// <param name="passFail">Indicates whether the calculation passed or failed.</param>
//        /// <param name="result1">The first result value.</param>
//        /// <param name="result2">The second result value.</param>
//        public ResultDataModel(bool passFail, double result1, double result2)
//        {
//            Pass = passFail;
//            DblRes001 = result1;
//            DblRes002 = result2;
//            ResultDataArray = new CalcResultDataArray();
//        }

//        /// <summary>
//        /// Default constructor.
//        /// </summary>
//        public ResultDataModel()
//        {
//            ResultDataArray = new CalcResultDataArray();
//        }
//    }
//}


using System.Collections.Generic;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents the result data model including pass/fail status and various result values.
    /// </summary>
    public class ResultDataModel
    {
        /// <summary>
        /// Indicates whether the calculation passed or failed.
        /// </summary>
        public bool Pass { get; set; } = false;

        //**************************** Simple section *******************************

        /// <summary>
        /// A double result value.
        /// </summary>
        public double DblRes001 { get; set; } = 0;

        /// <summary>
        /// A dynamic result value.
        /// </summary>
        public dynamic DynRes001 { get; set; }

        /// <summary>
        /// A string result specifically for a field name.
        /// </summary>
        public dynamic StrFN001 { get; set; }

        /// <summary>
        /// A dynamic result specifically for a field name value.
        /// </summary>
        public dynamic DynFN001 { get; set; }

        /// <summary>
        /// The double result value.
        /// </summary>
        public double DblRes002 { get; set; } = 0;

        /// <summary>
        /// A string value.
        /// </summary>
        public double StrRes001 { get; set; } = 0;

        //**************************** END Simple section *******************************

        /// <summary>
        /// An array of results containing generic values.
        /// </summary>
        public CalcResultDataArray ResultDataArray { get; set; }

        /// <summary>
        /// Constructor with parameters to initialize Pass, DblRes001, and DblRes002.
        /// </summary>
        /// <param name="passFail">Indicates whether the calculation passed or failed.</param>
        /// <param name="result1">The first result value.</param>
        /// <param name="result2">The second result value.</param>
        public ResultDataModel(bool passFail, double result1, double result2)
        {
            Pass = passFail;
            DblRes001 = result1;
            DblRes002 = result2;
            ResultDataArray = new CalcResultDataArray();
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ResultDataModel()
        {
            ResultDataArray = new CalcResultDataArray();
        }

        /// <summary>
        /// Represents a single calculation result data including various properties.
        /// </summary>
        public class CalcResultData
        {
            public bool testPass { get; set; }
            public string OrigValue { get; set; }
            public string FieldName { get; set; }
            public string[] FieldNamesMissing { get; set; }
            public dynamic NewValue { get; set; }
            public string Notes { get; set; }
            public List<string> ewmListMessage { get; set; }
        }

        /// <summary>
        /// Represents an array of calculation result data.
        /// An array of results containing generic values.
        /// The first column relates to the field name or result, and the second column to the value <dynamic>.
        /// | Result/FieldName          | newValue <dynamic>
        /// +-------------+-------------------------------------------+-------------------------------------+---------------------+
        /// | PenDOL                    | 100.00    (double)
        /// | PenSal                    | [500,200,300]
        /// </summary>
        public class CalcResultDataArray
        {
            public List<CalcResultData> CalcResultsDataS { get; set; } = new List<CalcResultData>();

            // Add a new row to the array with the specified field name and value
            public void AddRow(string fieldName, string origValue, dynamic newValue, bool testPass = false, string notes = "", List<string> ewmListMessage = null)
            {
                CalcResultsDataS.Add(new CalcResultData
                {
                    FieldName = fieldName,
                    OrigValue = origValue,
                    NewValue = newValue,
                    testPass = testPass,
                    Notes = notes,
                    ewmListMessage = ewmListMessage
                });
            }

            // Simple constructor with just field name
            public void AddRow(string fieldName)
            {
                CalcResultsDataS.Add(new CalcResultData
                {
                    FieldName = fieldName
                });
            }
        }
    }
}
