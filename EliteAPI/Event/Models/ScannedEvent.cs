using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ScannedEvent : EventBase
    {
        internal ScannedEvent() { }
        [JsonProperty("ScanType")]
        public string ScanType { get; internal set; }

        
    }
}