using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class PowerplayVoucherEvent : EventBase<PowerplayVoucherEvent>
    {
        internal PowerplayVoucherEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }

        [JsonProperty("Systems")]
        public IReadOnlyList<string> Systems { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplayVoucherEvent> PowerplayVoucherEvent;

        internal void InvokePowerplayVoucherEvent(PowerplayVoucherEvent arg)
        {
            PowerplayVoucherEvent?.Invoke(this, arg);
        }
    }
}