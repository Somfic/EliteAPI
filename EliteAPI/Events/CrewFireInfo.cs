using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CrewFireInfo : IEvent
    {
        internal static CrewFireInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewFireEvent(JsonConvert.DeserializeObject<CrewFireInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("CrewID")]
        public long CrewId { get; internal set; }
    }
}
