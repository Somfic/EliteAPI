using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CrewMemberQuitsEvent : EventBase
    {
        internal CrewMemberQuitsEvent() { }
        [JsonProperty("Crew")]
        public string Crew { get; internal set; }

        
    }
}