using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
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
        public string ShipId { get; private set; }
    }

    public partial class PayFinesEvent
    {
        public static PayFinesEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PayFinesEvent>(json);
        }
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