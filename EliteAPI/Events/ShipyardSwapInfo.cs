using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ShipyardSwapInfo : IEvent
    {
        internal static ShipyardSwapInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShipyardSwapEvent(JsonConvert.DeserializeObject<ShipyardSwapInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
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
