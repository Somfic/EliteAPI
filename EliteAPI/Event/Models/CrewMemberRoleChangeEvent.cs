using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CrewMemberRoleChangeEvent : EventBase
    {
        internal CrewMemberRoleChangeEvent() { }

        public static CrewMemberRoleChangeEvent FromJson(string json) => JsonConvert.DeserializeObject<CrewMemberRoleChangeEvent>(json);


        [JsonProperty("Crew")]
        public string Crew { get; internal set; }

        [JsonProperty("Role")]
        public string Role { get; internal set; }

        
    }
}