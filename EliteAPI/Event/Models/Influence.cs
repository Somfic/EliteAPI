using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class Influence
    {
        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; internal set; }

        [JsonProperty("Trend")]
        public string Trend { get; internal set; }

        [JsonProperty("Influence")]
        public string InfluenceInfluence { get; internal set; }
    }
}