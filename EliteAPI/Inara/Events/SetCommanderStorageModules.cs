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
        public string ItemName { get; set; }
        [JsonProperty("itemValue")]
        public long ItemValue { get; set; }
        [JsonProperty("isHot")]
        public bool IsHot { get; set; }
        [JsonProperty("starsystemName")]
        public string StarsystemName { get; set; }
        [JsonProperty("stationName")]
        public string StationName { get; set; }
        [JsonProperty("marketID")]
        public long MarketId { get; set; }
        [JsonProperty("engineering")]
        public InaraEngineering Engineering { get; set; }
    }
    public class InaraEngineering
    {
        [JsonProperty("blueprintName")]
        public string BlueprintName { get; set; }
        [JsonProperty("blueprintLevel")]
        public long BlueprintLevel { get; set; }
        [JsonProperty("blueprintQuality")]
        public long BlueprintQuality { get; set; }
        [JsonProperty("experimentalEffect")]
        public string ExperimentalEffect { get; set; }
    }
}
