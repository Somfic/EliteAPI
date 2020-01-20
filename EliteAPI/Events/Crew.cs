using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class Crew
    {
        [JsonProperty("NpcCrew_TotalWages")]
        public long NpcCrewTotalWages { get; internal set; }
        [JsonProperty("NpcCrew_Hired")]
        public long NpcCrewHired { get; internal set; }
        [JsonProperty("NpcCrew_Fired")]
        public long NpcCrewFired { get; internal set; }
        [JsonProperty("NpcCrew_Died")]
        public long NpcCrewDied { get; internal set; }
    }
}