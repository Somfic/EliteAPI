
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class SystemsShutdownEvent : EventBase
    {
        internal SystemsShutdownEvent() { }

        [JsonProperty("event")]
        public string Event { get; private set; }
    }

    public partial class SystemsShutdownEvent
    {
        public static SystemsShutdownEvent FromJson(string json) => JsonConvert.DeserializeObject<SystemsShutdownEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<SystemsShutdownEvent> SystemsShutdownEvent;
        internal void InvokeSystemsShutdownEvent(SystemsShutdownEvent arg) => SystemsShutdownEvent?.Invoke(this, arg);
    }
}
