using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SquadronCreatedEvent : EventBase
    {
        internal SquadronCreatedEvent() { }

        public static SquadronCreatedEvent FromJson(string json) => JsonConvert.DeserializeObject<SquadronCreatedEvent>(json);


        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }

        
    }
}