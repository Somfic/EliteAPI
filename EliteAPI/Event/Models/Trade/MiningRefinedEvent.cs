using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class MiningRefinedEvent : EventBase<MiningRefinedEvent>
    {
        internal MiningRefinedEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MiningRefinedEvent> MiningRefinedEvent;

        internal void InvokeMiningRefinedEvent(MiningRefinedEvent arg)
        {
            MiningRefinedEvent?.Invoke(this, arg);
        }
    }
}