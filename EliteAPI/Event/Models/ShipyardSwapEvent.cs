using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ShipyardSwapEvent : EventBase
    {
        internal ShipyardSwapEvent() { }

        public static ShipyardSwapEvent FromJson(string json) => JsonConvert.DeserializeObject<ShipyardSwapEvent>(json);


        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("StoreOldShip")]
        public string StoreOldShip { get; internal set; }

        [JsonProperty("StoreShipID")]
        public long StoreShipId { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        
    }
}