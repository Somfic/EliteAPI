using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CrewLaunchFighterEvent : EventBase
    {
        internal CrewLaunchFighterEvent() { }
        [JsonProperty("Crew")]
        public string Crew { get; internal set; }

        
    }
}