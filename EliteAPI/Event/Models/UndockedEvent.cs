using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class UndockedEvent : EventBase
    {
        internal UndockedEvent() { }
        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        public string StationType { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        
    }
}