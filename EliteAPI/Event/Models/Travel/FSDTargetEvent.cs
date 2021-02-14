using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class FsdTargetEvent : EventBase<FsdTargetEvent>
    {
        internal FsdTargetEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }

        [JsonProperty("StarClass")]
        public string StarClass { get; private set; }

        [JsonProperty("RemainingJumpsInRoute")]
        public int RemainingJumpsInRoute { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<FsdTargetEvent> FsdTargetEvent;

        internal void InvokeFsdTargetEvent(FsdTargetEvent arg)
        {
            FsdTargetEvent?.Invoke(this, arg);
        }
    }
}