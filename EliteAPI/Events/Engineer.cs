using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class Engineer
    {
        [JsonProperty("Engineer")]
        public string EngineerEngineer { get; internal set; }

        [JsonProperty("EngineerID")]
        public long EngineerId { get; internal set; }

        [JsonProperty("Progress")]
        public string Progress { get; internal set; }

        [JsonProperty("RankProgress", NullValueHandling = NullValueHandling.Ignore)]
        public long? RankProgress { get; internal set; }

        [JsonProperty("Rank", NullValueHandling = NullValueHandling.Ignore)]
        public long? Rank { get; internal set; }
    }
}