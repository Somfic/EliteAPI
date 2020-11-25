
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class RefuelAllEvent : EventBase
    {
        internal RefuelAllEvent() { }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }

        [JsonProperty("Amount")]
        public double Amount { get; private set; }
    }

    public partial class RefuelAllEvent
    {
        public static RefuelAllEvent FromJson(string json) => JsonConvert.DeserializeObject<RefuelAllEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<RefuelAllEvent> RefuelAllEvent;
        internal void InvokeRefuelAllEvent(RefuelAllEvent arg) => RefuelAllEvent?.Invoke(this, arg);
    }
}
