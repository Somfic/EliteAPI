using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MaterialTradeInfo : EventBase
    {
        internal static MaterialTradeInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMaterialTradeEvent(JsonConvert.DeserializeObject<MaterialTradeInfo>(json, JsonSettings.Settings));

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
