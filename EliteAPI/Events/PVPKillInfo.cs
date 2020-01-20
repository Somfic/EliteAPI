using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PVPKillInfo : EventBase
    {
        internal static PVPKillInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePVPKillEvent(JsonConvert.DeserializeObject<PVPKillInfo>(json, JsonSettings.Settings));

        [JsonProperty("Victim")]
        public string Victim { get; internal set; }
        [JsonProperty("CombatRank")]
        public long CombatRank { get; internal set; }
    }
}
