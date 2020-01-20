using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MarketInfo : IEvent
    {
        internal static MarketInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMarketEvent(JsonConvert.DeserializeObject<MarketInfo>(json, EliteAPI.Events.MarketConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("StationName")]
        public string StationName { get; internal set; }
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }
    }
}
