using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ShipyardTransferInfo : EventBase
    {
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
        public double Distance { get; internal set; }

        [JsonProperty("TransferPrice")]
        public long TransferPrice { get; internal set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        internal static ShipyardTransferInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeShipyardTransferEvent(JsonConvert.DeserializeObject<ShipyardTransferInfo>(json, JsonSettings.Settings));
        }
    }
}