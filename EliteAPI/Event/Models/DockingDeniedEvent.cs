
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class DockingDeniedEvent : EventBase
    {
        internal DockingDeniedEvent() { }

        [JsonProperty("Reason")]
        public string Reason { get; private set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; private set; }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StationType")]
        public string StationType { get; private set; }
    }

    public partial class DockingDeniedEvent
    {
        public static DockingDeniedEvent FromJson(string json) => JsonConvert.DeserializeObject<DockingDeniedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<DockingDeniedEvent> DockingDeniedEvent;
        internal void InvokeDockingDeniedEvent(DockingDeniedEvent arg) => DockingDeniedEvent?.Invoke(this, arg);
    }
}
