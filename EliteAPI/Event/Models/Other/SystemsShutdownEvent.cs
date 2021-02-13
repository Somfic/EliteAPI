using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class SystemsShutdownEvent : EventBase
    {
        internal SystemsShutdownEvent() { }

        [JsonProperty("event")]
        public string Event { get; private set; }
    }

    public partial class SystemsShutdownEvent
    {
        public static SystemsShutdownEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SystemsShutdownEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SystemsShutdownEvent> SystemsShutdownEvent;

        internal void InvokeSystemsShutdownEvent(SystemsShutdownEvent arg)
        {
            SystemsShutdownEvent?.Invoke(this, arg);
        }
    }
}