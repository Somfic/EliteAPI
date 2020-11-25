
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class WingLeaveEvent : EventBase
    {
        internal WingLeaveEvent() { }

        [JsonProperty("event")]
        public string Event { get; private set; }
    }

    public partial class WingLeaveEvent
    {
        public static WingLeaveEvent FromJson(string json) => JsonConvert.DeserializeObject<WingLeaveEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<WingLeaveEvent> WingLeaveEvent;
        internal void InvokeWingLeaveEvent(WingLeaveEvent arg) => WingLeaveEvent?.Invoke(this, arg);
    }
}
