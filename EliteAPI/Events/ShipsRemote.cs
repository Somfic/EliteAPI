using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ShipsRemote
    {
        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("ShipMarketID")]
        public long ShipMarketId { get; internal set; }

        [JsonProperty("TransferPrice")]
        public long TransferPrice { get; internal set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; internal set; }

        [JsonProperty("Value")]
        public long Value { get; internal set; }

        [JsonProperty("Hot")]
        public bool Hot { get; internal set; }

        [JsonProperty("ShipType_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; internal set; }
    }
}