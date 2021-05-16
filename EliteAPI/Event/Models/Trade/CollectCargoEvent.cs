using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CollectCargoEvent : EventBase<CollectCargoEvent>
    {
        internal CollectCargoEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; private set; }

        [JsonProperty("Stolen")]
        public bool IsStolen { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CollectCargoEvent> CollectCargoEvent;

        internal void InvokeCollectCargoEvent(CollectCargoEvent arg)
        {
            CollectCargoEvent?.Invoke(this, arg);
        }
    }
}