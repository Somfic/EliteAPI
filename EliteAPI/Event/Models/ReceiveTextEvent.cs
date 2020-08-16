using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ReceiveTextEvent : EventBase
    {
        internal ReceiveTextEvent() { }

        public static ReceiveTextEvent FromJson(string json) => JsonConvert.DeserializeObject<ReceiveTextEvent>(json);


        [JsonProperty("From")]
        public string From { get; internal set; }

        [JsonProperty("From_Localised")]
        public string FromLocalised { get; internal set; }

        [JsonProperty("Message")]
        public string Message { get; internal set; }

        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; internal set; }

        [JsonProperty("Channel")]
        public string Channel { get; internal set; }

        
    }
}