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

    public class InaraEngineering
    {
        [JsonProperty("blueprintName")]
        public string BlueprintName { get; internal set; }

        [JsonProperty("blueprintLevel")]
        public long BlueprintLevel { get; internal set; }

        [JsonProperty("blueprintQuality")]
        public long BlueprintQuality { get; internal set; }

        [JsonProperty("experimentalEffect")]
        public string ExperimentalEffect { get; internal set; }
    }
}
