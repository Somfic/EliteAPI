using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class QuitACrewInfo : IEvent
    {
        internal static QuitACrewInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeQuitACrewEvent(JsonConvert.DeserializeObject<QuitACrewInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Captain")]
        public string Captain { get; internal set; }
    }
}
