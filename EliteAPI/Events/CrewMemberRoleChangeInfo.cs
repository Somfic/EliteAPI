using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CrewMemberRoleChangeInfo : IEvent
    {
        internal static CrewMemberRoleChangeInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewMemberRoleChangeEvent(JsonConvert.DeserializeObject<CrewMemberRoleChangeInfo>(json, EliteAPI.Events.CrewMemberRoleChangeConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Crew")]
        public string Crew { get; internal set; }
        [JsonProperty("Role")]
        public string Role { get; internal set; }
    }
}
