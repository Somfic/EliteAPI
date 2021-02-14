using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class DockFighterEvent : EventBase<DockFighterEvent>
    {
        internal DockFighterEvent() { }

        [JsonProperty("ID")]
        public string Id { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DockFighterEvent> DockFighterEvent;

        internal void InvokeDockFighterEvent(DockFighterEvent arg)
        {
            DockFighterEvent?.Invoke(this, arg);
        }
    }
}