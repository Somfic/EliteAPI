using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CrewMemberRoleChangeInfo : EventBase
    {
        internal static CrewMemberRoleChangeInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewMemberRoleChangeEvent(JsonConvert.DeserializeObject<CrewMemberRoleChangeInfo>(json, JsonSettings.Settings));

        [JsonProperty("Crew")]
        public string Crew { get; internal set; }
        [JsonProperty("Role")]
        public string Role { get; internal set; }
    }
}
