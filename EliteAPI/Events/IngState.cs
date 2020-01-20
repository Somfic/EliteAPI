using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class IngState
    {
        [JsonProperty("State")]
        public string State { get; internal set; }
        [JsonProperty("Trend")]
        public long Trend { get; internal set; }
    }
}