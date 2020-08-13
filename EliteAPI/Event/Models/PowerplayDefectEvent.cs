using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PowerplayDefectEvent : EventBase
    {
        internal PowerplayDefectEvent() { }
        [JsonProperty("FromPower")]
        public string FromPower { get; internal set; }

        [JsonProperty("ToPower")]
        public string ToPower { get; internal set; }

        
    }
}