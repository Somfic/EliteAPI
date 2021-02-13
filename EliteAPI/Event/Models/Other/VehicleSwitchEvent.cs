using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class VehicleSwitchEvent : EventBase
    {
        internal VehicleSwitchEvent() { }

        [JsonProperty("To")]
        public string To { get; private set; }
    }

    public partial class VehicleSwitchEvent
    {
        public static VehicleSwitchEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<VehicleSwitchEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<VehicleSwitchEvent> VehicleSwitchEvent;

        internal void InvokeVehicleSwitchEvent(VehicleSwitchEvent arg)
        {
            VehicleSwitchEvent?.Invoke(this, arg);
        }
    }
}