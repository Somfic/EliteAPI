
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class PayLegacyFinesEvent : EventBase
    {
        internal PayLegacyFinesEvent() { }

        [JsonProperty("Amount")]
        public long Amount { get; private set; }

        [JsonProperty("BrokerPercentage")]
        public double BrokerPercentage { get; private set; }
    }

    public partial class PayLegacyFinesEvent
    {
        public static PayLegacyFinesEvent FromJson(string json) => JsonConvert.DeserializeObject<PayLegacyFinesEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<PayLegacyFinesEvent> PayLegacyFinesEvent;
        internal void InvokePayLegacyFinesEvent(PayLegacyFinesEvent arg) => PayLegacyFinesEvent?.Invoke(this, arg);
    }
}
