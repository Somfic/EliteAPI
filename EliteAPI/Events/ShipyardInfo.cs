using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ShipyardInfo : EventBase
    {
        internal static ShipyardInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShipyardEvent(JsonConvert.DeserializeObject<ShipyardInfo>(json, JsonSettings.Settings));

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("StationName")]
        public string StationName { get; internal set; }
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }
    }
}
