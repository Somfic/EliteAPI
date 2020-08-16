using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MissionAbandonedEvent : EventBase
    {
        internal MissionAbandonedEvent() { }

        public static MissionAbandonedEvent FromJson(string json) => JsonConvert.DeserializeObject<MissionAbandonedEvent>(json);


        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }

        
    }
}