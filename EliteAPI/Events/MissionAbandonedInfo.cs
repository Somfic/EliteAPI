using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MissionAbandonedInfo : EventBase
    {
        internal static MissionAbandonedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMissionAbandonedEvent(JsonConvert.DeserializeObject<MissionAbandonedInfo>(json, JsonSettings.Settings));

        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }
    }
}
