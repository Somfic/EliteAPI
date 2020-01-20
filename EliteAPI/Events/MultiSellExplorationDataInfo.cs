using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class MultiSellExplorationDataInfo : IEvent
    {
        internal static MultiSellExplorationDataInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMultiSellExplorationDataEvent(JsonConvert.DeserializeObject<MultiSellExplorationDataInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Discovered")]
        public List<Discovered> Discovered { get; internal set; }
        [JsonProperty("BaseValue")]
        public long BaseValue { get; internal set; }
        [JsonProperty("Bonus")]
        public long Bonus { get; internal set; }
        [JsonProperty("TotalEarnings")]
        public long TotalEarnings { get; internal set; }
    }
}
