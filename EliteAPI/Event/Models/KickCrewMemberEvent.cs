using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class KickCrewMemberEvent : EventBase
    {
        internal KickCrewMemberEvent() { }

        public static KickCrewMemberEvent FromJson(string json) => JsonConvert.DeserializeObject<KickCrewMemberEvent>(json);


        [JsonProperty("Crew")]
        public string Crew { get; internal set; }

        [JsonProperty("OnCrime")]
        public bool OnCrime { get; internal set; }

        
    }
}