using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class LaunchFighterEvent : EventBase
    {
        internal LaunchFighterEvent() { }

        public static LaunchFighterEvent FromJson(string json) => JsonConvert.DeserializeObject<LaunchFighterEvent>(json);


        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }

        
    }
}