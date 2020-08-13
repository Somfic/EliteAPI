using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class KickCrewMemberEvent : EventBase
    {
        internal KickCrewMemberEvent() { }
        [JsonProperty("Crew")]
        public string Crew { get; internal set; }

        [JsonProperty("OnCrime")]
        public bool OnCrime { get; internal set; }

        
    }
}