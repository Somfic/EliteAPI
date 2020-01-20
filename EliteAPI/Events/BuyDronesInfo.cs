using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class BuyDronesInfo : IEvent
    {
        internal static BuyDronesInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeBuyDronesEvent(JsonConvert.DeserializeObject<BuyDronesInfo>(json, EliteAPI.Events.BuyDronesConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Type")]
        public string Type { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; internal set; }
        [JsonProperty("TotalCost")]
        public long TotalCost { get; internal set; }
    }
}
