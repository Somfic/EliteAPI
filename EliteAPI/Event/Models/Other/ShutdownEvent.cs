using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class ShutdownEvent : EventBase
    {
        internal ShutdownEvent() { }

        [JsonProperty("event")]
        public string Event { get; private set; }
    }

    public partial class ShutdownEvent
    {
        public static ShutdownEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ShutdownEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ShutdownEvent> ShutdownEvent;

        internal void InvokeShutdownEvent(ShutdownEvent arg)
        {
            ShutdownEvent?.Invoke(this, arg);
        }
    }
}