using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CrewFireEvent : EventBase
    {
        internal CrewFireEvent() { }

        public static CrewFireEvent FromJson(string json) => JsonConvert.DeserializeObject<CrewFireEvent>(json);


        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("CrewID")]
        public long CrewId { get; internal set; }

        
    }
}