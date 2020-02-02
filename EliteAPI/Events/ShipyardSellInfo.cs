using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ShipyardSellInfo : EventBase
    {
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

        internal static ShipyardSellInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeShipyardSellEvent(JsonConvert.DeserializeObject<ShipyardSellInfo>(json, JsonSettings.Settings));
        }
    }
}