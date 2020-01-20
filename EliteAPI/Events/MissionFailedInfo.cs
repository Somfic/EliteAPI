using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MissionFailedInfo : EventBase
    {
        internal static MissionFailedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMissionFailedEvent(JsonConvert.DeserializeObject<MissionFailedInfo>(json, JsonSettings.Settings));

        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }
    }
}
