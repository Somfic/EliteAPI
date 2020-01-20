using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ChangeCrewRoleInfo : EventBase
    {
        internal static ChangeCrewRoleInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeChangeCrewRoleEvent(JsonConvert.DeserializeObject<ChangeCrewRoleInfo>(json, JsonSettings.Settings));

        [JsonProperty("Role")]
        public string Role { get; internal set; }
    }
}
