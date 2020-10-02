using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PVPKillEvent : EventBase
    {
        internal PVPKillEvent() { }

        public static PVPKillEvent FromJson(string json) => JsonConvert.DeserializeObject<PVPKillEvent>(json);


        [JsonProperty("Victim")]
        public string Victim { get; internal set; }

        [JsonProperty("CombatRank")]
        public long CombatRank { get; internal set; }

        
    }
}