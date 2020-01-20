using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SRVDestroyedInfo : IEvent
    {
        internal static SRVDestroyedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSRVDestroyedEvent(JsonConvert.DeserializeObject<SRVDestroyedInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
    }
}
