using Newtonsoft.Json;

namespace EliteAPI.Status.Modules
{
    public partial class Module
    {
        [JsonProperty("Slot")]
        public string Slot { get; internal set; }
        [JsonProperty("Item")]
        public string Item { get; internal set; }
        [JsonProperty("Power")]
        public float Power { get; internal set; }
        [JsonProperty("Priority", NullValueHandling = NullValueHandling.Ignore)]
        public long? Priority { get; internal set; }
    }
}