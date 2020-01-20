using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MaterialDiscoveredInfo : IEvent
    {
        internal static MaterialDiscoveredInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMaterialDiscoveredEvent(JsonConvert.DeserializeObject<MaterialDiscoveredInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Category")]
        public string Category { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }
        [JsonProperty("DiscoveryNumber")]
        public long DiscoveryNumber { get; internal set; }
    }
}
