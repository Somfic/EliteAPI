using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PVPKillInfo : IEvent
    {
        internal static PVPKillInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePVPKillEvent(JsonConvert.DeserializeObject<PVPKillInfo>(json, EliteAPI.Events.PVPKillConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Victim")]
        public string Victim { get; internal set; }
        [JsonProperty("CombatRank")]
        public long CombatRank { get; internal set; }
    }
}
