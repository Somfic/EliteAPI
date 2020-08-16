using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SellDronesEvent : EventBase
    {
        internal SellDronesEvent() { }

        public static SellDronesEvent FromJson(string json) => JsonConvert.DeserializeObject<SellDronesEvent>(json);


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