using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MissionRedirectedEvent : EventBase
    {
        internal MissionRedirectedEvent() { }
        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("NewDestinationStation")]
        public string NewDestinationStation { get; internal set; }

        [JsonProperty("NewDestinationSystem")]
        public string NewDestinationSystem { get; internal set; }

        [JsonProperty("OldDestinationStation")]
        public string OldDestinationStation { get; internal set; }

        [JsonProperty("OldDestinationSystem")]
        public string OldDestinationSystem { get; internal set; }

        
    }
}