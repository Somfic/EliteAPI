
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class PayFinesEvent : EventBase
    {
        internal PayFinesEvent() { }

        [JsonProperty("Amount")]
        public long Amount { get; private set; }

        [JsonProperty("AllFines")]
        public bool AllFines { get; private set; }

        [JsonProperty("Faction")]
        public string Faction { get; private set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; private set; }
    }

    public partial class PayFinesEvent
    {
        public static PayFinesEvent FromJson(string json) => JsonConvert.DeserializeObject<PayFinesEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<PayFinesEvent> PayFinesEvent;
        internal void InvokePayFinesEvent(PayFinesEvent arg) => PayFinesEvent?.Invoke(this, arg);
    }
}
