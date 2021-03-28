using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class RedeemVoucherEvent : EventBase
    {
        internal RedeemVoucherEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Amount")]
        public long TotalAmount { get; private set; }

        [JsonProperty("Factions", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<FactionInfo> Factions { get; private set; }

        [JsonProperty("BrokerPercentage", NullValueHandling = NullValueHandling.Ignore)]
        public double BrokerPercentage { get; private set; }
    }

    public class FactionInfo
    {
        internal FactionInfo() { }

        [JsonProperty("Faction")]
        public string Name { get; private set; }

        [JsonProperty("Amount")]
        public long Amount { get; private set; }
    }

    public partial class RedeemVoucherEvent
    {
        public static RedeemVoucherEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RedeemVoucherEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<RedeemVoucherEvent> RedeemVoucherEvent;

        internal void InvokeRedeemVoucherEvent(RedeemVoucherEvent arg)
        {
            RedeemVoucherEvent?.Invoke(this, arg);
        }
    }
}