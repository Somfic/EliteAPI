using System;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class LeaveBodyInfo : EventBase
    {
        internal static LeaveBodyInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLeaveBodyEvent(JsonConvert.DeserializeObject<LeaveBodyInfo>(json, JsonSettings.Settings));

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }
        [JsonProperty("Body")]
        public string Body { get; internal set; }
        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }
    }
}