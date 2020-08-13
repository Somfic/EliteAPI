using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SupercruiseExitEvent : EventBase
    {
        internal SupercruiseExitEvent() { }
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Body")]
        public string Body { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        [JsonProperty("BodyType")]
        public string BodyType { get; internal set; }

        
    }
}