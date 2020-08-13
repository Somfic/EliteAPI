using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MusicEvent : EventBase
    {
        internal MusicEvent() { }
        [JsonProperty("MusicTrack")]
        public string MusicTrack { get; internal set; }

        
    }
}