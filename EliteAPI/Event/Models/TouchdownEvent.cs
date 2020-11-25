
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class TouchdownEvent : EventBase
    {
        internal TouchdownEvent() { }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; private set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; private set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; private set; }
    }

    public partial class TouchdownEvent
    {
        public static TouchdownEvent FromJson(string json) => JsonConvert.DeserializeObject<TouchdownEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<TouchdownEvent> TouchdownEvent;
        internal void InvokeTouchdownEvent(TouchdownEvent arg) => TouchdownEvent?.Invoke(this, arg);
    }
}
