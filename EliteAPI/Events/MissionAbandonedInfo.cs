using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MissionAbandonedInfo : IEvent
    {
        internal static MissionAbandonedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMissionAbandonedEvent(JsonConvert.DeserializeObject<MissionAbandonedInfo>(json, JsonSettings.Settings));

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
