using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// Hold statistics on the commander's smuggling.
    /// </summary>
    /// <see cref="StatisticsInfo"/>
    public class SmugglingInfo
    {
        internal SmugglingInfo() { }

        /// <summary>
        /// The total amount of black markets interacted with.
        /// </summary>
        [JsonProperty("Black_Markets_Traded_With")]
        public int BlackMarketsTradedWith { get; internal set; }

        /// <summary>
        /// The total amount of profit made from black markets.
        /// </summary>
        [JsonProperty("Black_Markets_Profits")]
        public long BlackMarketsProfits { get; internal set; }

        /// <summary>
        /// The total amount of resources smuggled.
        /// </summary>
        [JsonProperty("Resources_Smuggled")]
        public int ResourcesSmuggled { get; internal set; }

        /// <summary>
        /// The average amount of profit made from smuggling.
        /// </summary>
        [JsonProperty("Average_Profit")]
        public long AverageProfit { get; internal set; }

        /// <summary>
        /// The highest transaction ever done by the commander while smuggling.
        /// </summary>
        [JsonProperty("Highest_Single_Transaction")]
        public long HighestSingleTransaction { get; internal set; }
    }
}