using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CrewAssignInfo : EventBase
    {
        internal static CrewAssignInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewAssignEvent(JsonConvert.DeserializeObject<CrewAssignInfo>(json, JsonSettings.Settings));

        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("CrewID")]
        public long CrewId { get; internal set; }
        [JsonProperty("Role")]
        public string Role { get; internal set; }
    }
}
