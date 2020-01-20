using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class SellExplorationDataInfo : IEvent
    {
        internal static SellExplorationDataInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSellExplorationDataEvent(JsonConvert.DeserializeObject<SellExplorationDataInfo>(json, EliteAPI.Events.SellExplorationDataConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Systems")]
        public List<string> Systems { get; internal set; }
        [JsonProperty("Discovered")]
        public List<string> Discovered { get; internal set; }
        [JsonProperty("BaseValue")]
        public long BaseValue { get; internal set; }
        [JsonProperty("Bonus")]
        public long Bonus { get; internal set; }
        [JsonProperty("TotalEarnings")]
        public long TotalEarnings { get; internal set; }
    }
}
