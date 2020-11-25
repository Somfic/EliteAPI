
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ShieldStateEvent : EventBase
    {
        internal ShieldStateEvent() { }

        [JsonProperty("ShieldsUp")]
        public bool ShieldsUp { get; private set; }
    }

    public partial class ShieldStateEvent
    {
        public static ShieldStateEvent FromJson(string json) => JsonConvert.DeserializeObject<ShieldStateEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ShieldStateEvent> ShieldStateEvent;
        internal void InvokeShieldStateEvent(ShieldStateEvent arg) => ShieldStateEvent?.Invoke(this, arg);
    }
}
