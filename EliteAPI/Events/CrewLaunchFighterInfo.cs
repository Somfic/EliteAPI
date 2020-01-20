using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CrewLaunchFighterInfo : EventBase
    {
        internal static CrewLaunchFighterInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewLaunchFighterEvent(JsonConvert.DeserializeObject<CrewLaunchFighterInfo>(json, JsonSettings.Settings));

        [JsonProperty("Crew")]
        public string Crew { get; internal set; }
    }
}
