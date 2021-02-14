using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ModuleInfoEvent : EventBase<ModuleInfoEvent>
    {
        internal ModuleInfoEvent() { }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ModuleInfoEvent> ModuleInfoEvent;

        internal void InvokeModuleInfoEvent(ModuleInfoEvent arg)
        {
            ModuleInfoEvent?.Invoke(this, arg);
        }
    }
}