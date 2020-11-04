using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class FSSAllBodiesFoundEvent : EventBase
    {
        internal FSSAllBodiesFoundEvent() { }

        public static FSSAllBodiesFoundEvent FromJson(string json) => JsonConvert.DeserializeObject<FSSAllBodiesFoundEvent>(json);


        [JsonProperty("SystemName")]
        public string SystemName { get; internal set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        
    }
}