
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class DockingGrantedEvent : EventBase
    {
        internal DockingGrantedEvent() { }

        [JsonProperty("LandingPad")]
        public long LandingPad { get; private set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; private set; }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StationType")]
        public string StationType { get; private set; }
    }

    public partial class DockingGrantedEvent
    {
        public static DockingGrantedEvent FromJson(string json) => JsonConvert.DeserializeObject<DockingGrantedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<DockingGrantedEvent> DockingGrantedEvent;
        internal void InvokeDockingGrantedEvent(DockingGrantedEvent arg) => DockingGrantedEvent?.Invoke(this, arg);
    }
}
