using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class DatalinkScanEvent : EventBase
    {
        internal DatalinkScanEvent() { }

        public static DatalinkScanEvent FromJson(string json) => JsonConvert.DeserializeObject<DatalinkScanEvent>(json);


        [JsonProperty("Message")]
        public string Message { get; internal set; }

        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; internal set; }

        
    }
}