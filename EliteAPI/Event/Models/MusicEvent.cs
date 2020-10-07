using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MusicEvent : EventBase
    {
        internal MusicEvent() { }

        public static MusicEvent FromJson(string json) => JsonConvert.DeserializeObject<MusicEvent>(json);


        [JsonProperty("MusicTrack")]
        public string MusicTrack { get; internal set; }

        
    }
}