using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MissionRedirectedInfo : IEvent
    {
        internal static MissionRedirectedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMissionRedirectedEvent(JsonConvert.DeserializeObject<MissionRedirectedInfo>(json, EliteAPI.Events.MissionRedirectedConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("NewDestinationStation")]
        public string NewDestinationStation { get; internal set; }
        [JsonProperty("NewDestinationSystem")]
        public string NewDestinationSystem { get; internal set; }
        [JsonProperty("OldDestinationStation")]
        public string OldDestinationStation { get; internal set; }
        [JsonProperty("OldDestinationSystem")]
        public string OldDestinationSystem { get; internal set; }
    }
}
