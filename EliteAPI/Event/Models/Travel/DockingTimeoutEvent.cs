using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class DockingTimeoutEvent : EventBase
    {
        internal DockingTimeoutEvent() { }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }
    }

    public partial class DockingTimeoutEvent
    {
        public static DockingTimeoutEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DockingTimeoutEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DockingTimeoutEvent> DockingTimeoutEvent;

        internal void InvokeDockingTimeoutEvent(DockingTimeoutEvent arg)
        {
            DockingTimeoutEvent?.Invoke(this, arg);
        }
    }
}