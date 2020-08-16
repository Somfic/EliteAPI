using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ScannedEvent : EventBase
    {
        internal ScannedEvent() { }

        public static ScannedEvent FromJson(string json) => JsonConvert.DeserializeObject<ScannedEvent>(json);


        [JsonProperty("ScanType")]
        public string ScanType { get; internal set; }

        
    }
}