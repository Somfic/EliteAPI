using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class BuyDronesEvent : EventBase
    {
        internal BuyDronesEvent() { }
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