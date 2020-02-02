using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class TechnologyBrokerInfo : EventBase
    {
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

        internal static TechnologyBrokerInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeTechnologyBrokerEvent(JsonConvert.DeserializeObject<TechnologyBrokerInfo>(json, JsonSettings.Settings));
        }
    }
}