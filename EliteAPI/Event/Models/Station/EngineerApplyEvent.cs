using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class EngineerApplyEvent : EventBase<EngineerApplyEvent>
    {
        internal EngineerApplyEvent() { }

        [JsonProperty("Engineer")]
        public string Engineer { get; private set; }

        [JsonProperty("Blueprint")]
        public string Blueprint { get; private set; }

        [JsonProperty("Level")]
        public long Level { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<EngineerApplyEvent> EngineerApplyEvent;

        internal void InvokeEngineerApplyEvent(EngineerApplyEvent arg)
        {
            EngineerApplyEvent?.Invoke(this, arg);
        }
    }
}