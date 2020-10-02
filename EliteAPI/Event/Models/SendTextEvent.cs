using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SendTextEvent : EventBase
    {
        internal SendTextEvent() { }

        public static SendTextEvent FromJson(string json) => JsonConvert.DeserializeObject<SendTextEvent>(json);


        [JsonProperty("To")]
        public string To { get; internal set; }

        [JsonProperty("To_Localised")]
        public string ToLocalised { get; internal set; }

        [JsonProperty("Message")]
        public string Message { get; internal set; }

        [JsonProperty("Sent")]
        public bool Sent { get; internal set; }

        
    }
}