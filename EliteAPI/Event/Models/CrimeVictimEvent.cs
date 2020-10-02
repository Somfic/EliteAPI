using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CrimeVictimEvent : EventBase
    {
        internal CrimeVictimEvent() { }

        public static CrimeVictimEvent FromJson(string json) => JsonConvert.DeserializeObject<CrimeVictimEvent>(json);


        [JsonProperty("Offender")]
        public string Offender { get; internal set; }

        [JsonProperty("CrimeType")]
        public string CrimeType { get; internal set; }

        [JsonProperty("Bounty")]
        public long Bounty { get; internal set; }

        
    }
}