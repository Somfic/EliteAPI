using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CrewAssignEvent : EventBase
    {
        internal CrewAssignEvent() { }

        public static CrewAssignEvent FromJson(string json) => JsonConvert.DeserializeObject<CrewAssignEvent>(json);


        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("CrewID")]
        public long CrewId { get; internal set; }

        [JsonProperty("Role")]
        public string Role { get; internal set; }

        
    }
}