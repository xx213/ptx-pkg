using System.Collections.Generic;
using System.Linq;

namespace PTXClassLibrary
{
    /// <summary>
    /// This class contains the details for the Calcs/DQA CalcResultsDataS class.
    // Reqs/Notes
    /// 2   CalcResultsModel - a class to capture the resuls for calc combining the dataUID(MemUID) and calcUID.
    ///     This combination/
    // 2.1  Contains a calcInstanceAudit : this is the transactional Audit of the instance of the calc.
    ///      The CalcInstanceAudit contains a (CalcResult)UID which is unique to that calc.
    ///      The 
    /// 




    /// <summary>
    /// List of calculation results each member for calcUID
    /// First string = dataUID
    /// Second String = calcUID
    /// public List<Dictionary<CalcResult, CalcInstances>> CalcResultsDataS { get; set; }
    /// 
    ///
    /// Model to represent DataUID_CalcUID calc results
    ///     /// 
    /// | Data/PTXUID | calcUID             | Calculation CalcResultsDataS | Calc Instance       |
    /// +-------------+---------------------+---------------------+---------------------+
    /// | Mem1321     | CalcUID001          | <CalcResult>        | <CalcInstanceAudit> |
    /// | Mem1321     | CalcUID001          | <CalcResult>        | <CalcInstanceAudit> |
    /// ......
    /// | Mem5555     | CalcUID001          | <CalcResult>        | <CalcInstanceAudit> |
    /// | Mem5555     | CalcUID002          | <CalcResult>        | <CalcInstanceAudit> |
    /// .....
    /// +-------------+---------------------+---------------------+
    /// </summary>
    /// <summary>
    /// Model to represent calculation results for a specific member/data.
    /// </summary>
    public class CalcResultsModel
    {
        /// <summary>
        /// List of CalcResults
        /// </summary>
        public List<CalcResult> CalcResults { get; set; }

        /// <summary>
        /// Constructor to initialize the CalcResultsDataS list with existing data.
        /// </summary>
        /// <param name="calcResults">Initial list of calculation results.</param>
        public CalcResultsModel(List<CalcResult> calcResults)
        {
            CalcResults = calcResults ?? new List<CalcResult>();
        }

        public CalcResultsModel() 
        {
            CalcResults = new List<CalcResult>();
        }

        /// <summary>
        /// Function to retrieve calculation results and audit instances given a dataUID and calcUID.
        /// </summary>
        /// <param name="dataUID">The UID of the member/data.</param>
        /// <param name="calcUID">The UID of the calculation.</param>
        /// <returns>A list of calculation results matching the provided dataUID and calcUID.</returns>
        public List<CalcResult> GetCalculationResults(string dataUID, string calcUID)
        {
            List<CalcResult> resultList = new List<CalcResult>();

            foreach (var result in CalcResults)
            {
                bool dataMatch = string.IsNullOrEmpty(dataUID) || result.dataUID == dataUID;
                bool calcMatch = string.IsNullOrEmpty(calcUID) || result.calcUID == calcUID;

                if ((string.IsNullOrEmpty(dataUID) && !string.IsNullOrEmpty(calcUID)) ||
                    (string.IsNullOrEmpty(calcUID) && !string.IsNullOrEmpty(dataUID)))
                {
                    continue; // Skip if one of the IDs is specified and the other is not
                }

                if (dataMatch && calcMatch)
                {
                    resultList.Add(result);
                }
            }

            if (resultList.Count == 0)
            {
                // No matching items found
                // You can log a message here if needed
            }

            return resultList;
        }

        /// <summary>
        /// Gets the ResultDataModel object for a specific dataUID and calcUID.
        /// </summary>
        /// <param name="dataUID">The dataUID to search for.</param>
        /// <param name="calcUID">The calcUID to search for.</param>
        /// <returns>The CalcResult object if found, otherwise null.</returns>
        public ResultDataModel GetCalcResultData_dataUID_calcUID(string dataUID, string calcUID)
        {
            // Find the CalcResult based on dataUID and calcUID
            CalcResult calcResult = CalcResults.FirstOrDefault(result => result.dataUID == dataUID && result.calcUID == calcUID);

            // If CalcResult is found, return its ResultDataModel; otherwise, return null
            return calcResult?.ResultDataModel;
        }

        public ResultDataModel GetCalcResultData_dataUID_fieldName(string dataUID, string fieldName)
        {
            // Find the CalcResult based on dataUID
            CalcResult calcResult = CalcResults.FirstOrDefault(result => result.dataUID == dataUID);

            // If CalcResult is found, search for the ResultDataModel with the matching fieldName
            if (calcResult != null)
            {
                ResultDataModel resultData = calcResult.ResultDataModel;
                if (resultData != null && resultData.StrFN001 == fieldName)
                {
                    return resultData;
                }
            }

            // If CalcResult is not found or if ResultDataModel with the matching fieldName is not found, return null
            return null;
        }



        /// <summary>
        /// Function to add a new calculation result to the list of calculation results.
        /// </summary>
        /// <param name="calcResult">The calculation result to add.</param>
        public void AddNewCalcInstance(CalcResult calcResult)
        {
            if (CalcResults == null)
                CalcResults = new List<CalcResult>();

            CalcResults.Add(calcResult);
        }

    }
}



///// <summary>
///// Model to store bulk calculation results.
///// 2.0 BulkCalcResultsModel represents a matrix structure that cross-references a dataUID with calculation results.
///// <remarks>
///// 2.1 BulkCalcResultsModel contains a NotUSedBulkCalcInstanceAudit to record the calculations that have been performed.
///// Format of BulkCalcResultsModel: List<Dictionary<string, CalcResultsModel>>
///// String = Mem/dataUID
///// Header = calcUID, Data = CalcResults (see <see cref="CalcResultsModel"/>)
///// 
///// List<Dictionary<string, CalcResultsModel>>
///// | dataUID(string)    | <CalcResultsModel>A     | calcUID="CalcABC" |
///// | Mem1321           | <CalcResultsModel>      | <CalcResultsModel>      |
///// | Mem1321           | <CalcResultsModel>      | <CalcResultsModel>      |
///// </remarks>
///// </summary>
//public class BulkCalcResultsModel
//{
//    /// <summary>
//    /// Dictionary to store bulk calculation results.
//    /// Key: UID of the member/data.
//    /// newValue: List of calculation results for this member/data.
//    /// </summary>
//    public Dictionary<string, List<CalcResultsModel>> bulkCalcResults { get; set; }

//    public NotUSedBulkCalcInstanceAudit bulkCalcInstanceAudit { get; set; };

//    /// <summary>
//    /// Initializes a new instance of the <see cref="BulkCalcResultsModel"/> class.
//    /// </summary>
//    public BulkCalcResultsModel()
//    {
//        bulkCalcResults = new Dictionary<string, List<CalcResultsModel>>();
//    }

//}
