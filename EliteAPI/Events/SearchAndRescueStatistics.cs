using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SearchAndRescueStatistics
    {
        [JsonProperty("SearchRescue_Traded")]
        public long SearchRescueTraded { get; internal set; }

        [JsonProperty("SearchRescue_Profit")]
        public long SearchRescueProfit { get; internal set; }

        [JsonProperty("SearchRescue_Count")]
        public long SearchRescueCount { get; internal set; }
    }
}