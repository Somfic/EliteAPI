using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class JetConeDamageEvent : EventBase<JetConeDamageEvent>
    {
        internal JetConeDamageEvent() { }

        [JsonProperty("Module")]
        public string Module { get; private set; }

        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<JetConeDamageEvent> JetConeDamageEvent;

        internal void InvokeJetConeDamageEvent(JetConeDamageEvent arg)
        {
            JetConeDamageEvent?.Invoke(this, arg);
        }
    }
}