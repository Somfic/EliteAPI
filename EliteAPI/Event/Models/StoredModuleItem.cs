using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class StoredModuleItem
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("StorageSlot")]
        public long StorageSlot { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("TransferCost")]
        public long TransferCost { get; internal set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; internal set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; internal set; }

        [JsonProperty("Hot")]
        public bool Hot { get; internal set; }

        [JsonProperty("EngineerModifications", NullValueHandling = NullValueHandling.Ignore)]
        public string EngineerModifications { get; internal set; }

        [JsonProperty("Level", NullValueHandling = NullValueHandling.Ignore)]
        public long? Level { get; internal set; }

        [JsonProperty("Quality", NullValueHandling = NullValueHandling.Ignore)]
        public float? Quality { get; internal set; }
    }
}