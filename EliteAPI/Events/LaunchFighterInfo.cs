using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class LaunchFighterInfo : EventBase
    {
        internal static LaunchFighterInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLaunchFighterEvent(JsonConvert.DeserializeObject<LaunchFighterInfo>(json, JsonSettings.Settings));

        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }
        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }
    }
}
