using Newtonsoft.Json;

namespace EliteAPI.Status
{
    public partial class Module
    {
        [JsonProperty("Slot")]
        public string Slot { get; internal set; }
        [JsonProperty("Item")]
        public string Item { get; internal set; }
        [JsonProperty("Power")]
        public double Power { get; internal set; }
        [JsonProperty("Priority", NullValueHandling = NullValueHandling.Ignore)]
        public long? Priority { get; internal set; }
    }
}