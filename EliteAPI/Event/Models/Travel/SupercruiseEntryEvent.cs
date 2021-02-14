using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SupercruiseEntryEvent : EventBase<SupercruiseEntryEvent>
    {
        internal SupercruiseEntryEvent() { }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SupercruiseEntryEvent> SupercruiseEntryEvent;

        internal void InvokeSupercruiseEntryEvent(SupercruiseEntryEvent arg)
        {
            SupercruiseEntryEvent?.Invoke(this, arg);
        }
    }
}