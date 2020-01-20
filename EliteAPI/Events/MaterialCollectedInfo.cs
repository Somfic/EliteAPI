using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MaterialCollectedInfo : IEvent
    {
        internal static MaterialCollectedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMaterialCollectedEvent(JsonConvert.DeserializeObject<MaterialCollectedInfo>(json, JsonSettings.Settings));

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
        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }
}
