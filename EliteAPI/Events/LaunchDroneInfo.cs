using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class LaunchDroneInfo : IEvent
    {
        internal static LaunchDroneInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLaunchDroneEvent(JsonConvert.DeserializeObject<LaunchDroneInfo>(json, EliteAPI.Events.LaunchDroneConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Type")]
        public string Type { get; internal set; }
    }
}
