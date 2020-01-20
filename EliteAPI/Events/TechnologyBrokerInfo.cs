using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class TechnologyBrokerInfo : IEvent
    {
        internal static TechnologyBrokerInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeTechnologyBrokerEvent(JsonConvert.DeserializeObject<TechnologyBrokerInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("BrokerType")]
        public string BrokerType { get; internal set; }
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("ItemsUnlocked")]
        public List<ItemsUnlocked> ItemsUnlocked { get; internal set; }
        [JsonProperty("Commodities")]
        public List<Commodity> Commodities { get; internal set; }
        [JsonProperty("Materials")]
        public List<Commodity> Materials { get; internal set; }
    }
}
