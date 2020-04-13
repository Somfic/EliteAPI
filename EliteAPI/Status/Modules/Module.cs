using Newtonsoft.Json;

namespace EliteAPI.Status.Modules
{
    public class Module
    {
        internal Module() { }

        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        [JsonProperty("Item")]
        public string Item { get; internal set; }

        [JsonProperty("Power")]
        public double Power { get; internal set; }

        [JsonProperty("Priority", NullValueHandling = NullValueHandling.Ignore)]
        public int? Priority { get; internal set; }
    }
}