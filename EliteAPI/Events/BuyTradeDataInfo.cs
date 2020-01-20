using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class BuyTradeDataInfo : IEvent
    {
        internal static BuyTradeDataInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeBuyTradeDataEvent(JsonConvert.DeserializeObject<BuyTradeDataInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("System")]
        public string System { get; internal set; }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
    }
}
