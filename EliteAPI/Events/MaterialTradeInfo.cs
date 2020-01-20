using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MaterialTradeInfo : IEvent
    {
        internal static MaterialTradeInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMaterialTradeEvent(JsonConvert.DeserializeObject<MaterialTradeInfo>(json, EliteAPI.Events.MaterialTradeConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("TraderType")]
        public string TraderType { get; internal set; }
        [JsonProperty("Paid")]
        public Paid Paid { get; internal set; }
        [JsonProperty("Received")]
        public Paid Received { get; internal set; }
    }
}
