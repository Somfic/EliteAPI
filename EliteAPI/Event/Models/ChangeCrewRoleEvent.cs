using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ChangeCrewRoleEvent : EventBase
    {
        internal ChangeCrewRoleEvent() { }

        public static ChangeCrewRoleEvent FromJson(string json) => JsonConvert.DeserializeObject<ChangeCrewRoleEvent>(json);


        [JsonProperty("Role")]
        public string Role { get; internal set; }

        
    }
}