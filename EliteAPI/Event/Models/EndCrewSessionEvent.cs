using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class EndCrewSessionEvent : EventBase
    {
        internal EndCrewSessionEvent() { }
        [JsonProperty("OnCrime")]
        public bool OnCrime { get; internal set; }

        
    }
}