using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CockpitBreachedInfo : IEvent
    {
        internal static CockpitBreachedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCockpitBreachedEvent(JsonConvert.DeserializeObject<CockpitBreachedInfo>(json, EliteAPI.Events.CockpitBreachedConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
    }
}
