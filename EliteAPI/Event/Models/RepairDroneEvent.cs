
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class RepairDroneEvent : EventBase
    {
        internal RepairDroneEvent() { }

        [JsonProperty("HullRepaired")]
        public double HullRepaired { get; private set; }
    }

    public partial class RepairDroneEvent
    {
        public static RepairDroneEvent FromJson(string json) => JsonConvert.DeserializeObject<RepairDroneEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<RepairDroneEvent> RepairDroneEvent;
        internal void InvokeRepairDroneEvent(RepairDroneEvent arg) => RepairDroneEvent?.Invoke(this, arg);
    }
}
