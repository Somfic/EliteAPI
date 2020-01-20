using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DockSRVInfo : IEvent
    {
        internal static DockSRVInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDockSRVEvent(JsonConvert.DeserializeObject<DockSRVInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
    }
}
