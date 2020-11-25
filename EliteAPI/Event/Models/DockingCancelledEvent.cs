
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class DockingCancelledEvent : EventBase
    {
        internal DockingCancelledEvent() { }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }
    }

    public partial class DockingCancelledEvent
    {
        public static DockingCancelledEvent FromJson(string json) => JsonConvert.DeserializeObject<DockingCancelledEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<DockingCancelledEvent> DockingCancelledEvent;
        internal void InvokeDockingCancelledEvent(DockingCancelledEvent arg) => DockingCancelledEvent?.Invoke(this, arg);
    }
}
