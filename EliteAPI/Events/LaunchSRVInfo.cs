using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class LaunchSRVInfo : EventBase
    {
        internal static LaunchSRVInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLaunchSRVEvent(JsonConvert.DeserializeObject<LaunchSRVInfo>(json, JsonSettings.Settings));

        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }
        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }
    }
}
