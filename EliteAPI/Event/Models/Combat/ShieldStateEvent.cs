using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ShieldStateEvent : EventBase<ShieldStateEvent>
    {
        internal ShieldStateEvent() { }

        [JsonProperty("ShieldsUp")]
        public bool IsShieldsUp { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ShieldStateEvent> ShieldStateEvent;

        internal void InvokeShieldStateEvent(ShieldStateEvent arg)
        {
            ShieldStateEvent?.Invoke(this, arg);
        }
    }
}