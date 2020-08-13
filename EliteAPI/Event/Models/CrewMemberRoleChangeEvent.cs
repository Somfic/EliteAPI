using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CrewMemberRoleChangeEvent : EventBase
    {
        internal CrewMemberRoleChangeEvent() { }
        [JsonProperty("Crew")]
        public string Crew { get; internal set; }

        [JsonProperty("Role")]
        public string Role { get; internal set; }

        
    }
}