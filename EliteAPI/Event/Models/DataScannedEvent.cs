using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class DataScannedEvent : EventBase
    {
        internal DataScannedEvent() { }
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        
    }
}