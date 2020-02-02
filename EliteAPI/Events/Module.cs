using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class Module
    {
        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        [JsonProperty("Item")]
        public string Item { get; internal set; }

        [JsonProperty("On")]
        public bool On { get; internal set; }

        [JsonProperty("Priority")]
        public long Priority { get; internal set; }

        [JsonProperty("AmmoInClip", NullValueHandling = NullValueHandling.Ignore)]
        public long? AmmoInClip { get; internal set; }

        [JsonProperty("AmmoInHopper", NullValueHandling = NullValueHandling.Ignore)]
        public long? AmmoInHopper { get; internal set; }

        [JsonProperty("Health")]
        public double Health { get; internal set; }

        [JsonProperty("Value", NullValueHandling = NullValueHandling.Ignore)]
        public long? Value { get; internal set; }

        [JsonProperty("Engineering", NullValueHandling = NullValueHandling.Ignore)]
        public Engineering Engineering { get; internal set; }
    }
}