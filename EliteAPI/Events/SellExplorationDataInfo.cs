using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class SellExplorationDataInfo : EventBase
    {
        internal static SellExplorationDataInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSellExplorationDataEvent(JsonConvert.DeserializeObject<SellExplorationDataInfo>(json, JsonSettings.Settings));

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
