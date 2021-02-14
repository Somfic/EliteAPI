using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class RefuelPartialEvent : EventBase<RefuelPartialEvent>
    {
        internal RefuelPartialEvent() { }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }

        [JsonProperty("Amount")]
        public double Amount { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<RefuelPartialEvent> RefuelPartialEvent;

        internal void InvokeRefuelPartialEvent(RefuelPartialEvent arg)
        {
            RefuelPartialEvent?.Invoke(this, arg);
        }
    }
}