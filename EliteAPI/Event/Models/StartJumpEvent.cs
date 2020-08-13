using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class StartJumpEvent : EventBase
    {
        internal StartJumpEvent() { }
        [JsonProperty("JumpType")]
        public string JumpType { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("StarClass")]
        public string StarClass { get; internal set; }

        
    }
}