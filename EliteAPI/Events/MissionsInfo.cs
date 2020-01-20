using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class MissionsInfo : IEvent
    {
        internal static MissionsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMissionsEvent(JsonConvert.DeserializeObject<MissionsInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Active")]
        public List<Active> Active { get; internal set; }
        [JsonProperty("Failed")]
        public List<object> Failed { get; internal set; }
        [JsonProperty("Complete")]
        public List<object> Complete { get; internal set; }
    }
}
