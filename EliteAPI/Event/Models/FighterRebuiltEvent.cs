using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class FighterRebuiltEvent : EventBase
    {
        internal FighterRebuiltEvent() { }

        public static FighterRebuiltEvent FromJson(string json) => JsonConvert.DeserializeObject<FighterRebuiltEvent>(json);


        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        
    }
}