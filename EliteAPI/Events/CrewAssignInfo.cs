using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CrewAssignInfo : IEvent
    {
        internal static CrewAssignInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewAssignEvent(JsonConvert.DeserializeObject<CrewAssignInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("CrewID")]
        public long CrewId { get; internal set; }
        [JsonProperty("Role")]
        public string Role { get; internal set; }
    }
}
