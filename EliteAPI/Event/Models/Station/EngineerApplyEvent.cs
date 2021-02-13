using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class EngineerApplyEvent : EventBase
    {
        internal EngineerApplyEvent() { }

        [JsonProperty("Engineer")]
        public string Engineer { get; private set; }

        [JsonProperty("Blueprint")]
        public string Blueprint { get; private set; }

        [JsonProperty("Level")]
        public long Level { get; private set; }
    }

    public partial class EngineerApplyEvent
    {
        public static EngineerApplyEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<EngineerApplyEvent>(json);
        }
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