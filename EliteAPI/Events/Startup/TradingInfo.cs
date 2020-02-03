using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// Holds statistics on the commander's trading.
    /// </summary>
    /// <see cref="StatisticsInfo"/>
    public class TradingInfo
    {
        internal TradingInfo() { }

        /// <summary>
        /// The total amount of markets traded with.
        /// </summary>
        [JsonProperty("Markets_Traded_With")]
        public int MarketsTradedWith { get; internal set; }

        /// <summary>
        /// The total amount of profit made from trading.
        /// </summary>
        [JsonProperty("Market_Profits")]
        public long MarketProfits { get; internal set; }

        /// <summary>
        /// The total amount of resources traded.
        /// </summary>
        [JsonProperty("Resources_Traded")]
        public int ResourcesTraded { get; internal set; }

        /// <summary>
        /// The average profit made while trading.
        /// </summary>
        [JsonProperty("Average_Profit")]
        public float AverageProfit { get; internal set; }

        /// <summary>
        /// The highest transaction ever made while trading by the commander.
        /// </summary>
        [JsonProperty("Highest_Single_Transaction")]
        public long HighestSingleTransaction { get; internal set; }
    }
}