using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class JoinACrewEvent : EventBase
    {
        internal JoinACrewEvent() { }
        [JsonProperty("Captain")]
        public string Captain { get; internal set; }

        
    }
}