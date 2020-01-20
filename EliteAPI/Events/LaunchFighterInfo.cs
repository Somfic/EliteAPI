using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class LaunchFighterInfo : IEvent
    {
        internal static LaunchFighterInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLaunchFighterEvent(JsonConvert.DeserializeObject<LaunchFighterInfo>(json, EliteAPI.Events.LaunchFighterConverter.Settings));

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
