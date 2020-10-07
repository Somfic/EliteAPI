using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class OutfittingEvent : EventBase
    {
        internal OutfittingEvent() { }

        public static OutfittingEvent FromJson(string json) => JsonConvert.DeserializeObject<OutfittingEvent>(json);


        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        
    }
}