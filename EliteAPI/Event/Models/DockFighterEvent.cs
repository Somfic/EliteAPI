
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class DockFighterEvent : EventBase
    {
        internal DockFighterEvent() { }

        [JsonProperty("ID")]
        public long Id { get; private set; }
    }

    public partial class DockFighterEvent
    {
        public static DockFighterEvent FromJson(string json) => JsonConvert.DeserializeObject<DockFighterEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<DockFighterEvent> DockFighterEvent;
        internal void InvokeDockFighterEvent(DockFighterEvent arg) => DockFighterEvent?.Invoke(this, arg);
    }
}
