using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SellDronesInfo : EventBase
    {
        internal static SellDronesInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSellDronesEvent(JsonConvert.DeserializeObject<SellDronesInfo>(json, JsonSettings.Settings));

        [JsonProperty("Type")]
        public string Type { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
        [JsonProperty("SellPrice")]
        public long SellPrice { get; internal set; }
        [JsonProperty("TotalSale")]
        public long TotalSale { get; internal set; }
    }
}
