using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class RankInfo : IEvent
    {
        internal static RankInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRankEvent(JsonConvert.DeserializeObject<RankInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Combat")]
        public long Combat { get; internal set; }
        [JsonProperty("Trade")]
        public long Trade { get; internal set; }
        [JsonProperty("Explore")]
        public long Explore { get; internal set; }
        [JsonProperty("Empire")]
        public long Empire { get; internal set; }
        [JsonProperty("Federation")]
        public long Federation { get; internal set; }
        [JsonProperty("CQC")]
        public long Cqc { get; internal set; }
    }
}