using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CrewMemberJoinsInfo : EventBase
    {
        internal static CrewMemberJoinsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewMemberJoinsEvent(JsonConvert.DeserializeObject<CrewMemberJoinsInfo>(json, JsonSettings.Settings));

        [JsonProperty("Crew")]
        public string Crew { get; internal set; }
    }
}
