using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class Ring
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("RingClass")]
        public string RingClass { get; internal set; }

        [JsonProperty("MassMT")]
        public float MassMt { get; internal set; }

        [JsonProperty("InnerRad")]
        public float InnerRad { get; internal set; }

        [JsonProperty("OuterRad")]
        public float OuterRad { get; internal set; }
    }
}