using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class BuyTradeDataInfo : EventBase
    {
        internal static BuyTradeDataInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeBuyTradeDataEvent(JsonConvert.DeserializeObject<BuyTradeDataInfo>(json, JsonSettings.Settings));

        [JsonProperty("System")]
        public string System { get; internal set; }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
    }
}
