using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MarketEvent : EventBase
    {
        internal MarketEvent() { }

        public static MarketEvent FromJson(string json) => JsonConvert.DeserializeObject<MarketEvent>(json);


        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        
    }
}