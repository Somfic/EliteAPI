using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class AfmuRepairsEvent : EventBase<AfmuRepairsEvent>
    {
        internal AfmuRepairsEvent() { }

        [JsonProperty("Module")]
        public string Module { get; private set; }

        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; private set; }

        [JsonProperty("FullyRepaired")]
        public bool FullyRepaired { get; private set; }

        [JsonProperty("Health")]
        public double Health { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<AfmuRepairsEvent> AfmuRepairsEvent;

        internal void InvokeAfmuRepairsEvent(AfmuRepairsEvent arg)
        {
            AfmuRepairsEvent?.Invoke(this, arg);
        }
    }
}