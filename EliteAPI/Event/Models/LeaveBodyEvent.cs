using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class LeaveBodyEvent : EventBase
    {
        internal LeaveBodyEvent() { }
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Body")]
        public string Body { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        
    }
}