using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CrewLaunchFighterInfo : IEvent
    {
        internal static CrewLaunchFighterInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewLaunchFighterEvent(JsonConvert.DeserializeObject<CrewLaunchFighterInfo>(json, EliteAPI.Events.CrewLaunchFighterConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Crew")]
        public string Crew { get; internal set; }
    }
}
