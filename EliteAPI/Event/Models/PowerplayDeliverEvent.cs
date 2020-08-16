using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PowerplayDeliverEvent : EventBase
    {
        internal PowerplayDeliverEvent() { }

        public static PowerplayDeliverEvent FromJson(string json) => JsonConvert.DeserializeObject<PowerplayDeliverEvent>(json);


        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        
    }
}