using System;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class LeaveBodyInfo : IEvent
    {
        internal static LeaveBodyInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLeaveBodyEvent(JsonConvert.DeserializeObject<LeaveBodyInfo>(json, EliteAPI.Events.LeaveBodyConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
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