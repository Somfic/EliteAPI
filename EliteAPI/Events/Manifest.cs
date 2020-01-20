using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public partial class Manifest
    {
        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }
        [JsonProperty("Type")]
        public string Type { get; internal set; }
        [JsonProperty("VIP")]
        public bool Vip { get; internal set; }
        [JsonProperty("Wanted")]
        public bool Wanted { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }
}