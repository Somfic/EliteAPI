using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class NewCommanderInfo : IEvent
    {
        internal static NewCommanderInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeNewCommanderEvent(JsonConvert.DeserializeObject<NewCommanderInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("Package")]
        public string Package { get; internal set; }
    }
}
