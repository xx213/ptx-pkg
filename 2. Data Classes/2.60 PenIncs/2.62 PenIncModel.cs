using Newtonsoft.Json;
using System;

namespace PTXClassLibrary
{
    /// <summary>
    /// Represents a pension increase model with various properties.
    /// </summary>
    public class PenIncModel
    {
        /// <summary>
        /// The GUID of the pension increase model.
        /// </summary>
        [JsonProperty("GUID")]
        public Guid GUID { get; set; }

        /// <summary>
        /// The name of the base table to use, e.g., StaatRPI0104.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the pension increase model.
        /// </summary>
        [JsonProperty("ID")]
        public string ID { get; set; }

        /// <summary>
        /// The description of the pension increase model.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// The associated pension increase data.
        /// </summary>
        [JsonProperty("PenIncData")]
        public PenIncData PenIncData { get; set; }

        /// <summary>
        /// The increase basis of the pension increase model.
        /// </summary>
        [JsonProperty("Increase Basis")]
        public string IncreaseBasis { get; set; }

        /// <summary>
        /// The fixed increase percentage of the pension increase model.
        /// </summary>
        [JsonProperty("Fixed Increase %")]
        public double FixedIncreasePercentage { get; set; }

        /// <summary>
        /// The reference month or look-back period of the pension increase model.
        /// </summary>
        [JsonProperty("Reference Month/Look Back")]
        public string ReferenceMonthOrLookBack { get; set; }

        /// <summary>
        /// The minimum value of the pension increase model.
        /// </summary>
        [JsonProperty("Minimum")]
        public double Minimum { get; set; }

        /// <summary>
        /// The maximum value of the pension increase model.
        /// </summary>
        [JsonProperty("Maximum")]
        public double Maximum { get; set; }

        /// <summary>
        /// The flag indicating if the first increase is proportionate or full increase.
        /// </summary>
        [JsonProperty("Proportionate 1st increase (No = Full Increase)")]
        public string ProportionateFirstIncrease { get; set; }

        /// <summary>
        /// Additional information about the pension increase model.
        /// </summary>
        [JsonProperty("Additional Info")]
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// The increase date of the pension increase model.
        /// </summary>
        [JsonProperty("Increase Date")]
        public string IncreaseDate { get; set; }

        /// <summary>
        /// The weighting of the pension increase in the overall calculation.
        /// </summary>
        [JsonProperty("Pension Increase Weighting")]
        public double PensionIncreaseWeighting { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PenIncModel"/> class.
        /// </summary>
        /// <param name="guid">The GUID of the pension increase model.</param>
        /// <param name="name">The name of the base table to use.</param>
        /// <param name="id">The ID of the pension increase model.</param>
        /// <param name="description">The description of the pension increase model.</param>
        /// <param name="penIncData">The associated pension increase data.</param>
        /// <param name="increaseBasis">The increase basis of the pension increase model.</param>
        /// <param name="fixedIncreasePercentage">The fixed increase percentage of the pension increase model.</param>
        /// <param name="referenceMonthOrLookBack">The reference month or look-back period of the pension increase model.</param>
        /// <param name="minimum">The minimum value of the pension increase model.</param>
        /// <param name="maximum">The maximum value of the pension increase model.</param>
        /// <param name="proportionateFirstIncrease">The flag indicating if the first increase is proportionate or full increase.</param>
        /// <param name="additionalInfo">Additional information about the pension increase model.</param>
        /// <param name="increaseDate">The increase date of the pension increase model.</param>
        /// <param name="pensionIncreaseWeighting">The weighting of the pension increase in the overall calculation.</param>
        public PenIncModel(Guid guid, string name, string id, string description,
            PenIncData penIncData, string increaseBasis, double fixedIncreasePercentage,
            string referenceMonthOrLookBack, double minimum, double maximum,
            string proportionateFirstIncrease, string additionalInfo, string increaseDate,
            double pensionIncreaseWeighting)
        {
            GUID = guid;
            Name = name;
            ID = id;
            Description = description;
            PenIncData = penIncData;
            IncreaseBasis = increaseBasis;
            FixedIncreasePercentage = fixedIncreasePercentage;
            ReferenceMonthOrLookBack = referenceMonthOrLookBack;
            Minimum = minimum;
            Maximum = maximum;
            ProportionateFirstIncrease = proportionateFirstIncrease;
            AdditionalInfo = additionalInfo;
            IncreaseDate = increaseDate;
            PensionIncreaseWeighting = pensionIncreaseWeighting;
        }
    }
}
