using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ChangeCrewRoleEvent : EventBase
    {
        internal ChangeCrewRoleEvent() { }
        [JsonProperty("Role")]
        public string Role { get; internal set; }

        
    }
}