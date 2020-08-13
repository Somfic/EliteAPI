using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MissionFailedEvent : EventBase
    {
        internal MissionFailedEvent() { }
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }

        
    }
}