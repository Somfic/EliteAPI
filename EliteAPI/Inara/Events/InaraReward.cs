using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class InaraReward
    {
        [JsonProperty("itemName")]
        public string ItemName { get; set; }
        [JsonProperty("itemCount")]
        public long ItemCount { get; set; }
    }
}