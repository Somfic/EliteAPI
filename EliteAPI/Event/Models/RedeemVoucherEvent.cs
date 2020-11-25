
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class RedeemVoucherEvent : EventBase
    {
        internal RedeemVoucherEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Amount")]
        public long Amount { get; private set; }

        [JsonProperty("Faction")]
        public string Faction { get; private set; }
    }

    public partial class RedeemVoucherEvent
    {
        public static RedeemVoucherEvent FromJson(string json) => JsonConvert.DeserializeObject<RedeemVoucherEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<RedeemVoucherEvent> RedeemVoucherEvent;
        internal void InvokeRedeemVoucherEvent(RedeemVoucherEvent arg) => RedeemVoucherEvent?.Invoke(this, arg);
    }
}
