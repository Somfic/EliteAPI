using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class PayFinesEvent : EventBase<PayFinesEvent>
    {
        internal PayFinesEvent() { }

        [JsonProperty("Amount")]
        public long Amount { get; private set; }

        [JsonProperty("AllFines")]
        public bool IsAllFines { get; private set; }

        [JsonProperty("Faction")]
        public string Faction { get; private set; }

        [JsonProperty("ShipID")]
        public string ShipId { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PayFinesEvent> PayFinesEvent;

        internal void InvokePayFinesEvent(PayFinesEvent arg)
        {
            PayFinesEvent?.Invoke(this, arg);
        }
    }
}