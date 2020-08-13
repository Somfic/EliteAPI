using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class USSDropEvent : EventBase
    {
        internal USSDropEvent() { }
        [JsonProperty("USSType")]
        public string UssType { get; internal set; }

        [JsonProperty("USSType_Localised")]
        public string UssTypeLocalised { get; internal set; }

        [JsonProperty("USSThreat")]
        public long UssThreat { get; internal set; }

        
    }
}