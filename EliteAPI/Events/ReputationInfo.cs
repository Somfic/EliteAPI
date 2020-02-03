using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ReputationInfo : EventBase
    {
        [JsonProperty("Empire")]
        public float Empire { get; internal set; }

        [JsonProperty("Federation")]
        public float Federation { get; internal set; }

        [JsonProperty("Independent")]
        public float Independent { get; internal set; }

        [JsonProperty("Alliance")]
        public float Alliance { get; internal set; }

        internal static ReputationInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeReputationEvent(JsonConvert.DeserializeObject<ReputationInfo>(json, JsonSettings.Settings));
        }
    }
}