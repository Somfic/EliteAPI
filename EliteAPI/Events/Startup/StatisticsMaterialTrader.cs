using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// Contains statistics on the commander's material trades.
    /// </summary>
    /// <see cref="StatisticsInfo"/>
    public class StatisticsMaterialTrader
    {
        internal StatisticsMaterialTrader() { }

        /// <summary>
        /// The total amount of trades.
        /// </summary>
        [JsonProperty("Trades_Completed")]
        public int TradesCompleted { get; internal set; }

        /// <summary>
        /// The total amount of materials traded.
        /// </summary>
        [JsonProperty("Materials_Traded")]
        public int MaterialsTraded { get; internal set; }

        /// <summary>
        /// The total amount of encoded materials traded.
        /// </summary>
        [JsonProperty("Encoded_Materials_Traded")]
        public int EncodedMaterialsTraded { get; internal set; }

        /// <summary>
        /// The total amount of raw materials traded.
        /// </summary>
        [JsonProperty("Raw_Materials_Traded")]
        public int RawMaterialsTraded { get; internal set; }

        /// <summary>
        /// The total amount of grade 1 materials traded.
        /// </summary>
        [JsonProperty("Grade_1_Materials_Traded")]
        public int Grade1Traded { get; internal set; }

        /// <summary>
        /// The total amount of grade 2 materials traded.
        /// </summary>
        [JsonProperty("Grade_2_Materials_Traded")]
        public int Grade2Traded { get; internal set; }

        /// <summary>
        /// The total amount of grade 3 materials traded.
        /// </summary>
        [JsonProperty("Grade_3_Materials_Traded")]
        public int Grade3Traded { get; internal set; }

        /// <summary>
        /// The total amount of grade 4 materials traded.
        /// </summary>
        [JsonProperty("Grade_4_Materials_Traded")]
        public int Grade4Traded { get; internal set; }

        /// <summary>
        /// The total amount of grade 5 materials traded.
        /// </summary>
        [JsonProperty("Grade_5_Materials_Traded")]
        public int Grade5Traded { get; internal set; }
    }
}