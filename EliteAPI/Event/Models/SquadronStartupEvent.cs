using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SquadronStartupEvent : EventBase
    {
        internal SquadronStartupEvent() { }
        [JsonProperty("SquadronName")]
        public string SquadronName { get; set; }

        [JsonProperty("CurrentRank")]
        public long CurrentRank { get; set; }

        
    }
}