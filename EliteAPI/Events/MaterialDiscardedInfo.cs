using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MaterialDiscardedInfo : EventBase
    {
        internal static MaterialDiscardedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMaterialDiscardedEvent(JsonConvert.DeserializeObject<MaterialDiscardedInfo>(json, JsonSettings.Settings));

        [JsonProperty("Category")]
        public string Category { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }
}
