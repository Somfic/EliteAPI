using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CrewFireEvent : EventBase
    {
        internal CrewFireEvent() { }
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("CrewID")]
        public long CrewId { get; internal set; }

        
    }
}