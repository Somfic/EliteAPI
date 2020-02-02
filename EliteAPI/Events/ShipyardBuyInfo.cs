using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ShipyardBuyInfo : EventBase
    {
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

        internal static ShipyardBuyInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeShipyardBuyEvent(JsonConvert.DeserializeObject<ShipyardBuyInfo>(json, JsonSettings.Settings));
        }
    }
}