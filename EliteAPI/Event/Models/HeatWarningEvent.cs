
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class HeatWarningEvent : EventBase
    {
        internal HeatWarningEvent() { }

        [JsonProperty("event")]
        public string Event { get; private set; }
    }

    public partial class HeatWarningEvent
    {
        public static HeatWarningEvent FromJson(string json) => JsonConvert.DeserializeObject<HeatWarningEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<HeatWarningEvent> HeatWarningEvent;
        internal void InvokeHeatWarningEvent(HeatWarningEvent arg) => HeatWarningEvent?.Invoke(this, arg);
    }
}
