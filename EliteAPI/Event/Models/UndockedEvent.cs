using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class UndockedEvent : EventBase
    {
        internal UndockedEvent() { }

        public static UndockedEvent FromJson(string json) => JsonConvert.DeserializeObject<UndockedEvent>(json);


        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        public string StationType { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        
    }
}