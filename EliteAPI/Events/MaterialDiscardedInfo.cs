using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MaterialDiscardedInfo : IEvent
    {
        internal static MaterialDiscardedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMaterialDiscardedEvent(JsonConvert.DeserializeObject<MaterialDiscardedInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Category")]
        public string Category { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }
}
