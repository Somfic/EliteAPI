using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ScientificResearchInfo : EventBase
    {
        internal static ScientificResearchInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeScientificResearchEvent(JsonConvert.DeserializeObject<ScientificResearchInfo>(json, JsonSettings.Settings));

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("Category")]
        public string Category { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }
}
