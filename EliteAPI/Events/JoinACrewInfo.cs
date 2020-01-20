using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class JoinACrewInfo : IEvent
    {
        internal static JoinACrewInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeJoinACrewEvent(JsonConvert.DeserializeObject<JoinACrewInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Captain")]
        public string Captain { get; internal set; }
    }
}
