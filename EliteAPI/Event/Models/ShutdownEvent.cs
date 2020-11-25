
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ShutdownEvent : EventBase
    {
        internal ShutdownEvent() { }

        [JsonProperty("event")]
        public string Event { get; private set; }
    }

    public partial class ShutdownEvent
    {
        public static ShutdownEvent FromJson(string json) => JsonConvert.DeserializeObject<ShutdownEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ShutdownEvent> ShutdownEvent;
        internal void InvokeShutdownEvent(ShutdownEvent arg) => ShutdownEvent?.Invoke(this, arg);
    }
}
