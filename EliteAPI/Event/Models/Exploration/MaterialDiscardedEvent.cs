using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class MaterialDiscardedEvent : EventBase<MaterialDiscardedEvent>
    {
        internal MaterialDiscardedEvent() { }

        [JsonProperty("Category")]
        public string Category { get; private set; }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MaterialDiscardedEvent> MaterialDiscardedEvent;

        internal void InvokeMaterialDiscardedEvent(MaterialDiscardedEvent arg)
        {
            MaterialDiscardedEvent?.Invoke(this, arg);
        }
    }
}