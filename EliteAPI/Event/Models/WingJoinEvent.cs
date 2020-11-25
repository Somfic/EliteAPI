
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class WingJoinEvent : EventBase
    {
        internal WingJoinEvent() { }

        [JsonProperty("Others")]
        public IReadOnlyList<string> Others { get; private set; }
    }

    public partial class WingJoinEvent
    {
        public static WingJoinEvent FromJson(string json) => JsonConvert.DeserializeObject<WingJoinEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<WingJoinEvent> WingJoinEvent;
        internal void InvokeWingJoinEvent(WingJoinEvent arg) => WingJoinEvent?.Invoke(this, arg);
    }
}
