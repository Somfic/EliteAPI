
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class RepairEvent : EventBase
    {
        internal RepairEvent() { }

        [JsonProperty("Item")]
        public string Item { get; private set; }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }
    }

    public partial class RepairEvent
    {
        public static RepairEvent FromJson(string json) => JsonConvert.DeserializeObject<RepairEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<RepairEvent> RepairEvent;
        internal void InvokeRepairEvent(RepairEvent arg) => RepairEvent?.Invoke(this, arg);
    }
}
