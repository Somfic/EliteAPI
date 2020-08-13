using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ShipyardTransferEvent : EventBase
    {
        internal ShipyardTransferEvent() { }
        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("ShipMarketID")]
        public long ShipMarketId { get; internal set; }

        [JsonProperty("Distance")]
        public float Distance { get; internal set; }

        [JsonProperty("TransferPrice")]
        public long TransferPrice { get; internal set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        
    }
}