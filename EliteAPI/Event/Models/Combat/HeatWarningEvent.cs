using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class HeatWarningEvent : EventBase<HeatWarningEvent>
    {
        internal HeatWarningEvent() { }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<HeatWarningEvent> HeatWarningEvent;

        internal void InvokeHeatWarningEvent(HeatWarningEvent arg)
        {
            HeatWarningEvent?.Invoke(this, arg);
        }
    }
}