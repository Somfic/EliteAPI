using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class FighterRebuiltEvent : EventBase
    {
        internal FighterRebuiltEvent() { }
        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        
    }
}