using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MarketInfo : EventBase
    {
        internal static MarketInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMarketEvent(JsonConvert.DeserializeObject<MarketInfo>(json, JsonSettings.Settings));

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("StationName")]
        public string StationName { get; internal set; }
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }
    }
}
