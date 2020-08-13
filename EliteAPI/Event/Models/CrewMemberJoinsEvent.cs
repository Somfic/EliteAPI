using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CrewMemberJoinsEvent : EventBase
    {
        internal CrewMemberJoinsEvent() { }
        [JsonProperty("Crew")]
        public string Crew { get; internal set; }

        
    }
}