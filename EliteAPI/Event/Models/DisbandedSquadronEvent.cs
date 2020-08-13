using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class DisbandedSquadronEvent : EventBase
    {
        internal DisbandedSquadronEvent() { }
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }

        
    }
}