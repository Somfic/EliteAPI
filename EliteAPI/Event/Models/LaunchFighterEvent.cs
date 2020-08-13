using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class LaunchFighterEvent : EventBase
    {
        internal LaunchFighterEvent() { }
        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }

        
    }
}