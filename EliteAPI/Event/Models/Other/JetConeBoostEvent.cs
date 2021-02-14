using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class JetConeBoostEvent : EventBase<JetConeBoostEvent>
    {
        internal JetConeBoostEvent() { }

        [JsonProperty("BoostValue")]
        public double BoostValue { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<JetConeBoostEvent> JetConeBoostEvent;

    }
}