using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MissionAbandonedEvent : EventBase
    {
        internal MissionAbandonedEvent() { }
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }

        
    }
}