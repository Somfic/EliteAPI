using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class Multicrew
    {
        [JsonProperty("Multicrew_Time_Total")]
        public long MulticrewTimeTotal { get; internal set; }

        [JsonProperty("Multicrew_Gunner_Time_Total")]
        public long MulticrewGunnerTimeTotal { get; internal set; }

        [JsonProperty("Multicrew_Fighter_Time_Total")]
        public long MulticrewFighterTimeTotal { get; internal set; }

        [JsonProperty("Multicrew_Credits_Total")]
        public long MulticrewCreditsTotal { get; internal set; }

        [JsonProperty("Multicrew_Fines_Total")]
        public long MulticrewFinesTotal { get; internal set; }
    }
}