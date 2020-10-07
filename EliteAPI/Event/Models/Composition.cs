using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class Composition
    {
        [JsonProperty("Ice")]
        public float Ice { get; internal set; }

        [JsonProperty("Rock")]
        public float Rock { get; internal set; }

        [JsonProperty("Metal")]
        public float Metal { get; internal set; }
    }
}