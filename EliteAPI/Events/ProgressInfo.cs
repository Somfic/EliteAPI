using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ProgressInfo : EventBase
    {
        [JsonProperty("Combat")]
        public long Combat { get; internal set; }

        [JsonProperty("Trade")]
        public long Trade { get; internal set; }

        [JsonProperty("Explore")]
        public long Explore { get; internal set; }

        [JsonProperty("Empire")]
        public long Empire { get; internal set; }

        [JsonProperty("Federation")]
        public long Federation { get; internal set; }

        [JsonProperty("CQC")]
        public long Cqc { get; internal set; }

        internal static ProgressInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeProgressEvent(JsonConvert.DeserializeObject<ProgressInfo>(json, JsonSettings.Settings));
        }
    }
}