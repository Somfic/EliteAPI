
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class RepairAllEvent : EventBase
    {
        internal RepairAllEvent() { }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }
    }

    public partial class RepairAllEvent
    {
        public static RepairAllEvent FromJson(string json) => JsonConvert.DeserializeObject<RepairAllEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<RepairAllEvent> RepairAllEvent;
        internal void InvokeRepairAllEvent(RepairAllEvent arg) => RepairAllEvent?.Invoke(this, arg);
    }
}
