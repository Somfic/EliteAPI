using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class Ring
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("RingClass")]
        public string RingClass { get; internal set; }
        [JsonProperty("MassMT")]
        public double MassMt { get; internal set; }
        [JsonProperty("InnerRad")]
        public double InnerRad { get; internal set; }
        [JsonProperty("OuterRad")]
        public double OuterRad { get; internal set; }
    }
}