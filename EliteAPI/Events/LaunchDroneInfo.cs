using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class LaunchDroneInfo : EventBase
    {
        internal static LaunchDroneInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLaunchDroneEvent(JsonConvert.DeserializeObject<LaunchDroneInfo>(json, JsonSettings.Settings));

        [JsonProperty("Type")]
        public string Type { get; internal set; }
    }
}
