using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class LeftSquadronEvent : EventBase
    {
        internal LeftSquadronEvent() { }
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }

        
    }
}