using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class QuitACrewEvent : EventBase
    {
        internal QuitACrewEvent() { }
        [JsonProperty("Captain")]
        public string Captain { get; internal set; }

        
    }
}