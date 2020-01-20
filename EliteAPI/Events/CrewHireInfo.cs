using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CrewHireInfo : EventBase
    {
        internal static CrewHireInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewHireEvent(JsonConvert.DeserializeObject<CrewHireInfo>(json, JsonSettings.Settings));

        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("CrewID")]
        public long CrewId { get; internal set; }
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
        [JsonProperty("CombatRank")]
        public long CombatRank { get; internal set; }
    }
}
