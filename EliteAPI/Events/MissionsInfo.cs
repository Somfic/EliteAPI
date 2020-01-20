using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MissionsInfo : EventBase
    {
        [JsonProperty("Active")]
        public List<ActiveMission> Active { get; internal set; }

        [JsonProperty("Failed")]
        public List<object> Failed { get; internal set; }

        [JsonProperty("Complete")]
        public List<object> Complete { get; internal set; }

        internal static MissionsInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMissionsEvent(JsonConvert.DeserializeObject<MissionsInfo>(json, JsonSettings.Settings));
        }
    }
}