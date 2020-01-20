using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class MissionsInfo : EventBase
    {
        internal static MissionsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMissionsEvent(JsonConvert.DeserializeObject<MissionsInfo>(json, JsonSettings.Settings));

        [JsonProperty("Active")]
        public List<ActiveMission> Active { get; internal set; }
        [JsonProperty("Failed")]
        public List<object> Failed { get; internal set; }
        [JsonProperty("Complete")]
        public List<object> Complete { get; internal set; }
    }
}
