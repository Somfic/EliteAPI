using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SrvDestroyedEvent : EventBase<SrvDestroyedEvent>
    {
        internal SrvDestroyedEvent() { }        
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SrvDestroyedEvent> SrvDestroyedEvent;

    }
}