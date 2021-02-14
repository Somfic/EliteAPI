using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class RepairEvent : EventBase<RepairEvent>
    {
        internal RepairEvent() { }

        [JsonProperty("Item")]
        public string Item { get; private set; }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<RepairEvent> RepairEvent;

        internal void InvokeRepairEvent(RepairEvent arg)
        {
            RepairEvent?.Invoke(this, arg);
        }
    }
}