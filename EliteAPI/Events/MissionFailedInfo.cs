using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MissionFailedInfo : IEvent
    {
        internal static MissionFailedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMissionFailedEvent(JsonConvert.DeserializeObject<MissionFailedInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }
    }
}
