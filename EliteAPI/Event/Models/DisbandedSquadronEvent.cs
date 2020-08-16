using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class DisbandedSquadronEvent : EventBase
    {
        internal DisbandedSquadronEvent() { }

        public static DisbandedSquadronEvent FromJson(string json) => JsonConvert.DeserializeObject<DisbandedSquadronEvent>(json);


        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }

        
    }
}