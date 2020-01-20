using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MaterialDiscoveredInfo : EventBase
    {
        internal static MaterialDiscoveredInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMaterialDiscoveredEvent(JsonConvert.DeserializeObject<MaterialDiscoveredInfo>(json, JsonSettings.Settings));

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
