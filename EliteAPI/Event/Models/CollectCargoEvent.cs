using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CollectCargoEvent : EventBase
    {
        internal CollectCargoEvent() { }

        public static CollectCargoEvent FromJson(string json) => JsonConvert.DeserializeObject<CollectCargoEvent>(json);


        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        [JsonProperty("Stolen")]
        public bool Stolen { get; internal set; }

        
    }
}