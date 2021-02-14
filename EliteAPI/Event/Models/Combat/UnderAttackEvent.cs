using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class UnderAttackEvent : EventBase<UnderAttackEvent>
    {
        internal UnderAttackEvent() { }

        [JsonProperty("Target")]
        public string Target { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<UnderAttackEvent> UnderAttackEvent;

        internal void InvokeUnderAttackEvent(UnderAttackEvent arg)
        {
            UnderAttackEvent?.Invoke(this, arg);
        }
    }
}