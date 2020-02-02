using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class LeaveBodyInfo : EventBase
    {
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Body")]
        public string Body { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        internal static LeaveBodyInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeLeaveBodyEvent(JsonConvert.DeserializeObject<LeaveBodyInfo>(json, JsonSettings.Settings));
        }
    }
}