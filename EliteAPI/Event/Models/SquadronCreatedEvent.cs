using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SquadronCreatedEvent : EventBase
    {
        internal SquadronCreatedEvent() { }
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }

        
    }
}