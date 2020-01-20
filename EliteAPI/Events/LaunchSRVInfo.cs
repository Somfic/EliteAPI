using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class LaunchSRVInfo : IEvent
    {
        internal static LaunchSRVInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLaunchSRVEvent(JsonConvert.DeserializeObject<LaunchSRVInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }
        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }
    }
}
