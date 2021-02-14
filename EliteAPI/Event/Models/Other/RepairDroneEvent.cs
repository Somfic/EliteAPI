using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class RepairDroneEvent : EventBase<RepairDroneEvent>
    {
        internal RepairDroneEvent() { }

        [JsonProperty("HullRepaired")]
        public double HullRepaired { get; private set; }
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