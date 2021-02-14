using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class WingInviteEvent : EventBase<WingInviteEvent>
    {
        internal WingInviteEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<WingInviteEvent> WingInviteEvent;

        internal void InvokeWingInviteEvent(WingInviteEvent arg)
        {
            WingInviteEvent?.Invoke(this, arg);
        }
    }
}