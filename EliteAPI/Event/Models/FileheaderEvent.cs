using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class FileheaderEvent : EventBase
    {
        internal FileheaderEvent() { }
        [JsonProperty("part")]
        public long Part { get; internal set; }

        [JsonProperty("language")]
        public string Language { get; internal set; }

        [JsonProperty("gameversion")]
        public string Gameversion { get; internal set; }

        [JsonProperty("build")]
        public string Build { get; internal set; }

        
    }
}