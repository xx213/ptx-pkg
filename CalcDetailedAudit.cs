using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PTXClassLibrary
{
    public class CalcDetailedAudit
    {
        [JsonProperty("CalcDetailedAuditList")]
        public List<CalcAuditRow> CalcDetailedAuditList = new List<CalcAuditRow>();

        //[JsonProperty("intCalcDetailedAuditString")]
        //private string intCalcDetailedAuditString { get; set; }

        //Kept for historic reasons
        public string CalcAuditString { get; set; }


        //[JsonProperty("intCalcDetailedAuditStringHTML")]
        //private string intCalcDetailedAuditStringHTML { get; set; }

        //// New private field to store the JSON representation of CalcDetailedAuditList
        //private string CalcDQADetailedAuditJson;





        //Constructor
        public CalcDetailedAudit()
        {
            AddRow("CalcAudit Initialised. ", "Initialised", DateTime.Now);
        }

        /// <summary>
        /// Used to add a row to the calc audit
        /// If AuditTime is empty then use now()
        /// </summary>
        public void AddRow(string inCalcDescription, string inCalcValue, DateTime? inAuditTime = null)
        {
            if (inAuditTime == null)
            {
                inAuditTime = DateTime.Now;
            }

            CalcAuditRow CalcAuditObjectRow = new CalcAuditRow()
            {
                Description = inCalcDescription,
                Value = inCalcValue,
                AuditTime = inAuditTime
            };

            CalcDetailedAuditList.Add(CalcAuditObjectRow);
            //GenerateStringHTML(CalcAuditObjectRow);
        }

        /// <summary>
        /// Used to concatenate all the list items into a single string if CalcDQADetailedAuditString is not null or empty
        /// </summary>
        /// <summary>
        /// Used to concatenate all the list items into a single string if CalcDQADetailedAuditString is not null or empty
        /// </summary>
        private string GenerateStringHTML()
        {
            string CalcDQADetailedAuditStringHTML = "#Empty";

            if (CalcDetailedAuditList != null && CalcDetailedAuditList.Count > 0)
            {
                CalcDQADetailedAuditStringHTML = "<table>"; // Start the table
                foreach (var CalcAuditObjectRow in CalcDetailedAuditList)
                {
                    CalcDQADetailedAuditStringHTML += "<tr>"; // Start a new row
                    CalcDQADetailedAuditStringHTML += $"<td>{CalcAuditObjectRow.AuditTime}</td>"; // Audit Time
                    CalcDQADetailedAuditStringHTML += $"<td>{CalcAuditObjectRow.Description}</td>"; // Description
                    CalcDQADetailedAuditStringHTML += $"<td>{CalcAuditObjectRow.Value}</td>"; // newValue
                    CalcDQADetailedAuditStringHTML += "</tr>"; // End the row
                }
                CalcDQADetailedAuditStringHTML += "</table>"; // End the table
            }

            return CalcDQADetailedAuditStringHTML;
        }

        /// <summary>
        /// Used to concatenate all the list items into a single string if CalcDQADetailedAuditString is not null or empty
        /// </summary>
        private string GenerateString()
        {
            string CalcDQADetailedAuditString = "#Empty";

            if (CalcDetailedAuditList != null && CalcDetailedAuditList.Count > 0)
            {
                CalcDQADetailedAuditString = ""; // Reset the string
                foreach (var CalcAuditObjectRow in CalcDetailedAuditList)
                {
                    CalcDQADetailedAuditString += CalcAuditObjectRow.AuditTime.ToString();
                    CalcDQADetailedAuditString += " -:- ";
                    CalcDQADetailedAuditString += CalcAuditObjectRow.Description.ToString();
                    CalcDQADetailedAuditString += " [ ";
                    CalcDQADetailedAuditString += CalcAuditObjectRow.Value.ToString();
                    CalcDQADetailedAuditString += " ] ";
                    CalcDQADetailedAuditString += '\n';
                }
            }
            return CalcDQADetailedAuditString;
        }


        // Update CalcDQADetailedAuditJson with the JSON representation of CalcDetailedAuditList
        private string GenerateJson()
        {
            string CalcDQADetailedAuditJson = "{\"#empty\"}";

            if (CalcDetailedAuditList != null && CalcDetailedAuditList.Count > 0)
            {
                CalcDQADetailedAuditJson = JsonConvert.SerializeObject(CalcDetailedAuditList);
            }
            return CalcDQADetailedAuditJson;
        }

        // Public function to return CalcDQADetailedAuditJson
        public string GetJson()
        {
            // Ensure CalcDQADetailedAuditJson is up-to-date
            return GenerateJson();
            //return CalcDQADetailedAuditJson;
        }

        // Public getter method for CalcDQADetailedAuditString
        public string GetAuditString()
        {
            return GenerateString();
            //return CalcDQADetailedAuditString;
        }

        // Public getter method for CalcDQADetailedAuditString
        public string GetAuditStringHMTL()
        {
            return GenerateStringHTML();
            //return CalcDQADetailedAuditStringHTML;
        }


        // Public getter method for CalcDetailedAuditList
        public List<CalcAuditRow> GetAuditList()
        {
            return CalcDetailedAuditList;
        }
    }

    public class CalcAuditRow
    {
        [JsonProperty("AuditTime")]
        public DateTime? AuditTime { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("newValue")]
        public string Value { get; set; }

        [JsonProperty("ErrorCode")]
        public double ErrorCode { get; set; }

        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }
    }
}
