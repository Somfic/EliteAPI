using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class NpcCrewPaidWageEvent : EventBase
    {
        internal NpcCrewPaidWageEvent() { }

        public static NpcCrewPaidWageEvent FromJson(string json) => JsonConvert.DeserializeObject<NpcCrewPaidWageEvent>(json);


        [JsonProperty("NpcCrewName")]
        public string NpcCrewName { get; internal set; }

        [JsonProperty("NpcCrewId")]
        public long NpcCrewId { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        
    }
}