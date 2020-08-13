using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class AppliedToSquadronEvent : EventBase
    {
        internal AppliedToSquadronEvent() { }
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }

        
    }
}