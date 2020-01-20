using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class Active
    {
        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("PassengerMission")]
        public bool PassengerMission { get; internal set; }
        [JsonProperty("Expires")]
        public long Expires { get; internal set; }
    }
}