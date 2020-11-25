
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class DockingRequestedEvent : EventBase
    {
        internal DockingRequestedEvent() { }

        [JsonProperty("MarketID")]
        public long MarketId { get; private set; }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StationType")]
        public string StationType { get; private set; }
    }

    public partial class DockingRequestedEvent
    {
        public static DockingRequestedEvent FromJson(string json) => JsonConvert.DeserializeObject<DockingRequestedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<DockingRequestedEvent> DockingRequestedEvent;
        internal void InvokeDockingRequestedEvent(DockingRequestedEvent arg) => DockingRequestedEvent?.Invoke(this, arg);
    }
}
