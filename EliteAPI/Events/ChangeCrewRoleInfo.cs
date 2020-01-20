using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ChangeCrewRoleInfo : IEvent
    {
        internal static ChangeCrewRoleInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeChangeCrewRoleEvent(JsonConvert.DeserializeObject<ChangeCrewRoleInfo>(json, EliteAPI.Events.ChangeCrewRoleConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Role")]
        public string Role { get; internal set; }
    }
}
