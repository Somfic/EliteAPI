using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ShipyardBuyInfo : EventBase
    {
        internal static ShipyardBuyInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShipyardBuyEvent(JsonConvert.DeserializeObject<ShipyardBuyInfo>(json, JsonSettings.Settings));

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
