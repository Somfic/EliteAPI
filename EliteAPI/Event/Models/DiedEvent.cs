using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class DiedEvent : EventBase
    {
        internal DiedEvent() { }

        public static DiedEvent FromJson(string json) => JsonConvert.DeserializeObject<DiedEvent>(json);


        [JsonProperty("KillerName")]
        public string KillerName { get; internal set; }

        [JsonProperty("KillerName_Localised")]
        public string KillerNameLocalised { get; internal set; }

        [JsonProperty("KillerShip")]
        public string KillerShip { get; internal set; }

        [JsonProperty("KillerRank")]
        public string KillerRank { get; internal set; }

        
    }
}