using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class RepairAllEvent : EventBase
    {
        internal RepairAllEvent() { }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }
    }

    public partial class RepairAllEvent
    {
        public static RepairAllEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RepairAllEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<RepairAllEvent> RepairAllEvent;

        internal void InvokeRepairAllEvent(RepairAllEvent arg)
        {
            RepairAllEvent?.Invoke(this, arg);
        }
    }
}