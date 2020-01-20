using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MaterialCollectedInfo : EventBase
    {
        internal static MaterialCollectedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMaterialCollectedEvent(JsonConvert.DeserializeObject<MaterialCollectedInfo>(json, JsonSettings.Settings));

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
