using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class LeftSquadronEvent : EventBase
    {
        internal LeftSquadronEvent() { }

        public static LeftSquadronEvent FromJson(string json) => JsonConvert.DeserializeObject<LeftSquadronEvent>(json);


        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }

        
    }
}