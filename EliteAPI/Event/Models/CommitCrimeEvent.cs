using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CommitCrimeEvent : EventBase
    {
        internal CommitCrimeEvent() { }
        [JsonProperty("CrimeType")]
        public string CrimeType { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Victim")]
        public string Victim { get; internal set; }

        [JsonProperty("Victim_Localised")]
        public string VictimLocalised { get; internal set; }

        [JsonProperty("Bounty")]
        public long Bounty { get; internal set; }

        
    }
}