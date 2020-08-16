using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CrewMemberJoinsEvent : EventBase
    {
        internal CrewMemberJoinsEvent() { }

        public static CrewMemberJoinsEvent FromJson(string json) => JsonConvert.DeserializeObject<CrewMemberJoinsEvent>(json);


        [JsonProperty("Crew")]
        public string Crew { get; internal set; }

        
    }
}