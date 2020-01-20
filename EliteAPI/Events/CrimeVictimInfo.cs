using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CrimeVictimInfo : EventBase
    {
        internal static CrimeVictimInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrimeVictimEvent(JsonConvert.DeserializeObject<CrimeVictimInfo>(json, JsonSettings.Settings));

        [JsonProperty("Offender")]
        public string Offender { get; internal set; }
        [JsonProperty("CrimeType")]
        public string CrimeType { get; internal set; }
        [JsonProperty("Bounty")]
        public long Bounty { get; internal set; }
    }
}
