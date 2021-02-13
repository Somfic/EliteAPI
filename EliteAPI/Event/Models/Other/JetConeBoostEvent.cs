using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class JetConeBoostEvent : EventBase
    {
        internal JetConeBoostEvent() { }

        [JsonProperty("BoostValue")]
        public double BoostValue { get; private set; }
    }

    public partial class JetConeBoostEvent
    {
        public static JetConeBoostEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<JetConeBoostEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<JetConeBoostEvent> JetConeBoostEvent;

        internal void InvokeJetConeBoostEvent(JetConeBoostEvent arg)
        {
            JetConeBoostEvent?.Invoke(this, arg);
        }
    }
}