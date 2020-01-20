using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SearchAndRescueInfo : EventBase
    {
        internal static SearchAndRescueInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSearchAndRescueEvent(JsonConvert.DeserializeObject<SearchAndRescueInfo>(json, JsonSettings.Settings));

        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
        [JsonProperty("Reward")]
        public long Reward { get; internal set; }
    }
}
