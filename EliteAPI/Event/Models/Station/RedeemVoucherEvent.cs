using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
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