using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MissionFailedEvent : EventBase
    {
        internal MissionFailedEvent() { }

        public static MissionFailedEvent FromJson(string json) => JsonConvert.DeserializeObject<MissionFailedEvent>(json);


        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }

        
    }
}