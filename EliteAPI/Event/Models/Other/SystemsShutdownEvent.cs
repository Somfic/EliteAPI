using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SystemsShutdownEvent : EventBase<SystemsShutdownEvent>
    {
        internal SystemsShutdownEvent() { }

        [JsonProperty("event")]
        public string Event { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SystemsShutdownEvent> SystemsShutdownEvent;

        internal void InvokeSystemsShutdownEvent(SystemsShutdownEvent arg)
        {
            SystemsShutdownEvent?.Invoke(this, arg);
        }
    }
}