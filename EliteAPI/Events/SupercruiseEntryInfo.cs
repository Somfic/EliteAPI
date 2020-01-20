using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SupercruiseEntryInfo : IEvent
    {
        internal static SupercruiseEntryInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSupercruiseEntryEvent(JsonConvert.DeserializeObject<SupercruiseEntryInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }
    }
}
