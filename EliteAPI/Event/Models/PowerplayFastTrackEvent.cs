using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PowerplayFastTrackEvent : EventBase
    {
        internal PowerplayFastTrackEvent() { }
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        
    }
}