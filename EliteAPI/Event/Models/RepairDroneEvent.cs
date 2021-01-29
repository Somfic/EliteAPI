using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class RepairDroneEvent : EventBase
    {
        internal RepairDroneEvent() { }

        [JsonProperty("HullRepaired")]
        public double HullRepaired { get; private set; }
    }

    public partial class RepairDroneEvent
    {
        public static RepairDroneEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RepairDroneEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<RepairDroneEvent> RepairDroneEvent;

        internal void InvokeRepairDroneEvent(RepairDroneEvent arg)
        {
            RepairDroneEvent?.Invoke(this, arg);
        }
    }
}