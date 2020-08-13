using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class EngineerApplyEvent : EventBase
    {
        internal EngineerApplyEvent() { }
        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("Blueprint")]
        public string Blueprint { get; internal set; }

        [JsonProperty("Level")]
        public long Level { get; internal set; }

        [JsonProperty("Override")]
        public string Override { get; internal set; }

        
    }
}