
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class DockSrvEvent : EventBase
    {
        internal DockSrvEvent() { }

        [JsonProperty("ID")]
        public long Id { get; private set; }
    }

    public partial class DockSrvEvent
    {
        public static DockSrvEvent FromJson(string json) => JsonConvert.DeserializeObject<DockSrvEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<DockSrvEvent> DockSrvEvent;
        internal void InvokeDockSrvEvent(DockSrvEvent arg) => DockSrvEvent?.Invoke(this, arg);
    }
}
