using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ScientificResearchInfo : IEvent
    {
        internal static ScientificResearchInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeScientificResearchEvent(JsonConvert.DeserializeObject<ScientificResearchInfo>(json, EliteAPI.Events.ScientificResearchConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
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
