
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class WingAddEvent : EventBase
    {
        internal WingAddEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }
    }

    public partial class WingAddEvent
    {
        public static WingAddEvent FromJson(string json) => JsonConvert.DeserializeObject<WingAddEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<WingAddEvent> WingAddEvent;
        internal void InvokeWingAddEvent(WingAddEvent arg) => WingAddEvent?.Invoke(this, arg);
    }
}
