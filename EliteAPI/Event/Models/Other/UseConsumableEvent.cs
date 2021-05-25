using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class UseConsumableEvent : EventBase<UseConsumableEvent>
    {
        internal UseConsumableEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; private set; }

        [JsonProperty("Type")]
        public string Type { get; private set; }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<UseConsumableEvent> UseConsumableEvent;

        internal void InvokeUseConsumableEvent(UseConsumableEvent arg)
        {
            UseConsumableEvent?.Invoke(this, arg);
        }
    }
}