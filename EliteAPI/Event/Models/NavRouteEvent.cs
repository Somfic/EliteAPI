
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class NavRouteEvent : EventBase
    {
        internal NavRouteEvent() { }

        [JsonProperty("event")]
        public string Event { get; private set; }
    }

    public partial class NavRouteEvent
    {
        public static NavRouteEvent FromJson(string json) => JsonConvert.DeserializeObject<NavRouteEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<NavRouteEvent> NavRouteEvent;
        internal void InvokeNavRouteEvent(NavRouteEvent arg) => NavRouteEvent?.Invoke(this, arg);
    }
}
