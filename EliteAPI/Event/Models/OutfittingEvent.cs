using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class OutfittingEvent : EventBase
    {
        internal OutfittingEvent() { }
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        
    }
}