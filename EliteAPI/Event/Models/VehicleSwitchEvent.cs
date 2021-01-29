using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
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