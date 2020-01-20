using Newtonsoft.Json;
namespace EliteAPI.Inara.Events
{
    public class SetCommanderStorageModules : IInaraEventData
    {
        public SetCommanderStorageModules(string itemName)
        {
            ItemName = itemName;
        }
        [JsonProperty("itemName")]
        public string ItemName { get; internal set; }
        [JsonProperty("itemValue")]
        public long ItemValue { get; internal set; }
        [JsonProperty("isHot")]
        public bool IsHot { get; internal set; }
        [JsonProperty("starsystemName")]
        public string StarsystemName { get; internal set; }
        [JsonProperty("stationName")]
        public string StationName { get; internal set; }
        [JsonProperty("marketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("engineering")]
        public InaraEngineering Engineering { get; internal set; }
    }
}
