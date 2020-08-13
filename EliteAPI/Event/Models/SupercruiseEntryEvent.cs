using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SupercruiseEntryEvent : EventBase
    {
        internal SupercruiseEntryEvent() { }
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        
    }
}