using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ReputationInfo : EventBase
    {
        [JsonProperty("Empire")]
        public double Empire { get; internal set; }

        [JsonProperty("Federation")]
        public double Federation { get; internal set; }

        [JsonProperty("Independent")]
        public double Independent { get; internal set; }

        [JsonProperty("Alliance")]
        public double Alliance { get; internal set; }

        internal static ReputationInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeReputationEvent(JsonConvert.DeserializeObject<ReputationInfo>(json, JsonSettings.Settings));
        }
    }
}