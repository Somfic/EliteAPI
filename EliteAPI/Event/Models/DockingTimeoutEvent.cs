
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class DockingTimeoutEvent : EventBase
    {
        internal DockingTimeoutEvent() { }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }
    }

    public partial class DockingTimeoutEvent
    {
        public static DockingTimeoutEvent FromJson(string json) => JsonConvert.DeserializeObject<DockingTimeoutEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<DockingTimeoutEvent> DockingTimeoutEvent;
        internal void InvokeDockingTimeoutEvent(DockingTimeoutEvent arg) => DockingTimeoutEvent?.Invoke(this, arg);
    }
}
