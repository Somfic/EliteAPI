using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class BackPackEvent : EventBase<BackPackEvent>
    {
        internal BackPackEvent() { }

        //No values for this event
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<BackPackEvent> BackPackEvent;

        internal void InvokeBackPackEvent(BackPackEvent arg)
        {
            BackPackEvent?.Invoke(this, arg);
        }
    }
}