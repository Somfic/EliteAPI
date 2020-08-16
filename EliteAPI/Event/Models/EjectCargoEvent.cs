using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class EjectCargoEvent : EventBase
    {
        internal EjectCargoEvent() { }

        public static EjectCargoEvent FromJson(string json) => JsonConvert.DeserializeObject<EjectCargoEvent>(json);


        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("Abandoned")]
        public bool Abandoned { get; internal set; }

        
    }
}