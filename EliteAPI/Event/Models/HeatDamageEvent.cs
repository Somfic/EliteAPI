
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class HeatDamageEvent : EventBase
    {
        internal HeatDamageEvent() { }

        [JsonProperty("event")]
        public string Event { get; private set; }
    }

    public partial class HeatDamageEvent
    {
        public static HeatDamageEvent FromJson(string json) => JsonConvert.DeserializeObject<HeatDamageEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<HeatDamageEvent> HeatDamageEvent;
        internal void InvokeHeatDamageEvent(HeatDamageEvent arg) => HeatDamageEvent?.Invoke(this, arg);
    }
}
