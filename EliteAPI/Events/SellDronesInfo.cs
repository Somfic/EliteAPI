using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SellDronesInfo : IEvent
    {
        internal static SellDronesInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSellDronesEvent(JsonConvert.DeserializeObject<SellDronesInfo>(json, EliteAPI.Events.SellDronesConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
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
