using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PVPKillEvent : EventBase
    {
        internal PVPKillEvent() { }
        [JsonProperty("Victim")]
        public string Victim { get; internal set; }

        [JsonProperty("CombatRank")]
        public long CombatRank { get; internal set; }

        
    }
}