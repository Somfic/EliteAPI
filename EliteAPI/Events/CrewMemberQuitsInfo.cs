using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CrewMemberQuitsInfo : IEvent
    {
        internal static CrewMemberQuitsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewMemberQuitsEvent(JsonConvert.DeserializeObject<CrewMemberQuitsInfo>(json, EliteAPI.Events.CrewMemberQuitsConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Crew")]
        public string Crew { get; internal set; }
    }
}
