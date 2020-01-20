using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ShutdownInfo : IEvent
    {
        internal static ShutdownInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShutdownEvent(JsonConvert.DeserializeObject<ShutdownInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
    }
}
