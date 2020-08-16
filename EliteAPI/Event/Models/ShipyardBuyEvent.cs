using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ShipyardBuyEvent : EventBase
    {
        internal ShipyardBuyEvent() { }

        public static ShipyardBuyEvent FromJson(string json) => JsonConvert.DeserializeObject<ShipyardBuyEvent>(json);


        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("ShipPrice")]
        public long ShipPrice { get; internal set; }

        [JsonProperty("StoreOldShip")]
        public string StoreOldShip { get; internal set; }

        [JsonProperty("StoreShipID")]
        public long StoreShipId { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        
    }
}