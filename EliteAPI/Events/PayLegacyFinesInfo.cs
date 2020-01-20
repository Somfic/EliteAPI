using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PayLegacyFinesInfo : IEvent
    {
        internal static PayLegacyFinesInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePayLegacyFinesEvent(JsonConvert.DeserializeObject<PayLegacyFinesInfo>(json, EliteAPI.Events.PayLegacyFinesConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Amount")]
        public long Amount { get; internal set; }
        [JsonProperty("BrokerPercentage")]
        public double BrokerPercentage { get; internal set; }
    }
}
