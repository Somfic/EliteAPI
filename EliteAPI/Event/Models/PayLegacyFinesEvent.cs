using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PayLegacyFinesEvent : EventBase
    {
        internal PayLegacyFinesEvent() { }

        public static PayLegacyFinesEvent FromJson(string json) => JsonConvert.DeserializeObject<PayLegacyFinesEvent>(json);


        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("BrokerPercentage")]
        public float BrokerPercentage { get; internal set; }

        
    }
}