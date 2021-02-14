using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class RedeemVoucherEvent : EventBase<RedeemVoucherEvent>
    {
        internal RedeemVoucherEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Amount")]
        public long Amount { get; private set; }

        [JsonProperty("Faction")]
        public string Faction { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<RedeemVoucherEvent> RedeemVoucherEvent;

    }
}