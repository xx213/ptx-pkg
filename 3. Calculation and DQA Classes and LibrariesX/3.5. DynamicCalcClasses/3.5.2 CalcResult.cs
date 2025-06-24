using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace PTXClassLibrary
{
    /// <summary>
    /// This class contains the details for the Calcs/DQA CalcResultsDataS class.
    // Reqs/Notes
    /// 1.   CalcResult 
    /// 1.0  A singular CalcResult is the result from a dataUID and incalcUID/DQAUID
    ///      So if a Calc with UID = "TVCalc" and MemberUID = "Mem132465", then
    ///      the CalcResult is the "result of TV Calc being done on MEM132456.
    /// 1.2  A CalcResult  will contain a 
    /// 
    /// : this audit for that calc and is based on calc steps etc.
    /// 
    ///       


    ///Inputs Data for ref 
    /// List of member and scheme data required for the DQA and calcs.
    /// Format CalcsDataModels <string, dynamic>.
    /// PTXUID                                      |  memDOB                  | memNino             | Pre88GMPTotDOL.
    /// PTXUID000654                                |  string "25/01/1977"}    | string "AB12345A"   | string "500.00".
    /// A42564                                      |  string "Blah Blah"}     | string "999.99"     | string "SomeText".
    ///
    /// Row 1 = valid Fieldnames.
    /// Column 1 = Unique Identifier.
    /// Col 2+ and Row 2+ Dynamic values.
    ///
    /// 
    /// 



    /// <summary>
    /// Model to represent a single calculation result.
    /// </summary>
    public class CalcResult
    {
        /// <summary>
        /// Unique identifier for the calculation result.
        /// </summary>
        public string calcUID { get; set; }

        /// <summary>
        /// Unique identifier for the dataUID result.
        /// </summary>
        public string dataUID { get; set; }

        /// <summary>
        /// Calculation result data.
        /// </summary>
        public ResultDataModel ResultDataModel { get; set; }

        /// <summary>
        /// Audit details for the single calculation result.
        /// </summary>
        public CalcDetailedAudit calcDetailedAudit { get; set; }

        /// <summary>
        /// Audit details for the single calculation instance.
        /// </summary>
        public CalcInstanceAudit calcInstanceAudit { get; set; }

        /// <summary>
        /// Error, Warning, Message.
        /// </summary>
        public string calcMessageEWM { get; set; }
        public List<string> listCalcMessageEWM { get; set; }

        /// <summary>
        /// Default constructor for CalcResult.
        /// </summary>

        public CalcResult()
        {
            // Initialize the Audit details
            calcDetailedAudit = new CalcDetailedAudit();
            calcInstanceAudit = new CalcInstanceAudit();
        }

        /// <summary>
        /// Constructor for CalcResult with specified properties.
        /// </summary>
        /// <param name="incalcUID">Unique identifier for the calculation result.</param>
        /// <param name="indataUID">Unique identifier for the dataUID result.</param>
        /// <param name="resultData">Calculation result data.</param>
        /// <param name="calcDetailedAudit">Audit details for the calculation result.</param>
        /// <param name="calcInstanceAudit">Audit details for the calculation instance.</param>
        /// <param name="messageEWM">Error, Warning, Message.</param>
        public CalcResult(string incalcUID, string indataUID, ResultDataModel resultData, CalcDetailedAudit calcDetailedAudit, CalcInstanceAudit calcInstanceAudit, string messageEWM)
        
        {
            calcUID = incalcUID;
            dataUID = indataUID;
            ResultDataModel = resultData;
            calcDetailedAudit = calcDetailedAudit ?? new CalcDetailedAudit(); // Assign a new instance if null
            calcInstanceAudit = calcInstanceAudit ?? new CalcInstanceAudit(); // Assign a new instance if null
            calcMessageEWM = messageEWM;
        }

        /// <summary>
        /// Constructor for CalcResult with specified properties, use to 
        /// </summary>
        /// <param name="calcUID">Unique identifier for the calculation result.</param>
        /// <param name="dataUID">Unique identifier for the dataUID result.</param>
        public CalcResult(string incalcUID, string indataUID)
        {
            calcUID = incalcUID;
            dataUID = indataUID;
            calcDetailedAudit = new CalcDetailedAudit(); // Assign a new instance if null
            calcInstanceAudit = new CalcInstanceAudit(); // Assign a new instance if null
            ResultDataModel = new ResultDataModel();
            calcMessageEWM = "";
        }

        //public static explicit operator CalcResult(Microsoft.CodeAnalysis.Scripting.ScriptVariable v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
