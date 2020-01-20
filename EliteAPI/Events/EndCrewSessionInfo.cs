using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class EndCrewSessionInfo : IEvent
    {
        internal static EndCrewSessionInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEndCrewSessionEvent(JsonConvert.DeserializeObject<EndCrewSessionInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("OnCrime")]
        public bool OnCrime { get; internal set; }
    }
}
