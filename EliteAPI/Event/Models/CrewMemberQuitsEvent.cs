using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CrewMemberQuitsEvent : EventBase
    {
        internal CrewMemberQuitsEvent() { }

        public static CrewMemberQuitsEvent FromJson(string json) => JsonConvert.DeserializeObject<CrewMemberQuitsEvent>(json);


        [JsonProperty("Crew")]
        public string Crew { get; internal set; }

        
    }
}