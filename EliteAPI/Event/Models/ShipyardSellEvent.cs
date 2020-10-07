using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ShipyardSellEvent : EventBase
    {
        internal ShipyardSellEvent() { }

        public static ShipyardSellEvent FromJson(string json) => JsonConvert.DeserializeObject<ShipyardSellEvent>(json);


        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("SellShipID")]
        public long SellShipId { get; internal set; }

        [JsonProperty("ShipPrice")]
        public long ShipPrice { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        
    }
}