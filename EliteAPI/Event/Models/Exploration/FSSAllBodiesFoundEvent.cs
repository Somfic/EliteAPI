using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class FssAllBodiesFoundEvent : EventBase<FssAllBodiesFoundEvent>
    {
        internal FssAllBodiesFoundEvent() { }

        [JsonProperty("SystemName")]
        public string SystemName { get; private set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<FssAllBodiesFoundEvent> FssAllBodiesFoundEvent;

        internal void InvokeFssAllBodiesFoundEvent(FssAllBodiesFoundEvent arg)
        {
            FssAllBodiesFoundEvent?.Invoke(this, arg);
        }
    }
}