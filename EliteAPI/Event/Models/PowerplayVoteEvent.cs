using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PowerplayVoteEvent : EventBase
    {
        internal PowerplayVoteEvent() { }
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Votes")]
        public long Votes { get; internal set; }

        [JsonProperty("VoteToConsolidate")]
        public long VoteToConsolidate { get; internal set; }

        
    }
}