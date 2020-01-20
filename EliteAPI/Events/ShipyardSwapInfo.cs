using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ShipyardSwapInfo : EventBase
    {
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

        internal static ShipyardSwapInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeShipyardSwapEvent(JsonConvert.DeserializeObject<ShipyardSwapInfo>(json, JsonSettings.Settings));
        }
    }
}