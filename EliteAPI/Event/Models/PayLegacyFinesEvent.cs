using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PayLegacyFinesEvent : EventBase
    {
        internal PayLegacyFinesEvent() { }
        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("BrokerPercentage")]
        public float BrokerPercentage { get; internal set; }

        
    }
}