using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class AppliedToSquadronEvent : EventBase
    {
        internal AppliedToSquadronEvent() { }

        public static AppliedToSquadronEvent FromJson(string json) => JsonConvert.DeserializeObject<AppliedToSquadronEvent>(json);


        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }

        
    }
}