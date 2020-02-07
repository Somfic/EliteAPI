using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// Contains statistics on the commander's searches and rescues.
    /// </summary>
    /// <see cref="StatisticsInfo"/>
    public class StatisticsSearchAndRescue
    {
        internal StatisticsSearchAndRescue() { }

        /// <summary>
        /// The amount of search and rescues traded.
        /// </summary>
        [JsonProperty("SearchRescue_Traded")]
        public int SearchRescueTraded { get; internal set; }

        /// <summary>
        /// The total amount of profit made from search and rescue.
        /// </summary>
        [JsonProperty("SearchRescue_Profit")]
        public long SearchRescueProfit { get; internal set; }

        /// <summary>
        /// The total amount of search and rescue.
        /// </summary>
        [JsonProperty("SearchRescue_Count")]
        public int SearchRescueCount { get; internal set; }
    }
}