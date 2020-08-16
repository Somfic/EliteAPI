using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class EscapeInterdictionEvent : EventBase
    {
        internal EscapeInterdictionEvent() { }

        public static EscapeInterdictionEvent FromJson(string json) => JsonConvert.DeserializeObject<EscapeInterdictionEvent>(json);


        [JsonProperty("Interdictor")]
        public string Interdictor { get; internal set; }

        [JsonProperty("Interdictor_Localised")]
        public string InterdictorLocalised { get; internal set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; internal set; }

        
    }
}