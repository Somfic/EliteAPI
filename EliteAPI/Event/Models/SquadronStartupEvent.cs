using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SquadronStartupEvent : EventBase
    {
        internal SquadronStartupEvent() { }

        public static SquadronStartupEvent FromJson(string json) => JsonConvert.DeserializeObject<SquadronStartupEvent>(json);


        [JsonProperty("SquadronName")]
        public string SquadronName { get; set; }

        [JsonProperty("CurrentRank")]
        public long CurrentRank { get; set; }

        
    }
}