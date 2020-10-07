using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class JoinedSquadronEvent : EventBase
    {
        internal JoinedSquadronEvent() { }

        public static JoinedSquadronEvent FromJson(string json) => JsonConvert.DeserializeObject<JoinedSquadronEvent>(json);


        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }

        
    }
}