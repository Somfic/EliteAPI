using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PayLegacyFinesInfo : EventBase
    {
        internal static PayLegacyFinesInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePayLegacyFinesEvent(JsonConvert.DeserializeObject<PayLegacyFinesInfo>(json, JsonSettings.Settings));

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }
        [JsonProperty("BrokerPercentage")]
        public double BrokerPercentage { get; internal set; }
    }
}
