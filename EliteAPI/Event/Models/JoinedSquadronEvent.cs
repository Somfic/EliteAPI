using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class JoinedSquadronEvent : EventBase
    {
        internal JoinedSquadronEvent() { }
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }

        
    }
}