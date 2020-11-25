
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class VehicleSwitchEvent : EventBase
    {
        internal VehicleSwitchEvent() { }

        [JsonProperty("event")]
        public string Event { get; private set; }
    }

    public partial class VehicleSwitchEvent
    {
        public static VehicleSwitchEvent FromJson(string json) => JsonConvert.DeserializeObject<VehicleSwitchEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<VehicleSwitchEvent> VehicleSwitchEvent;
        internal void InvokeVehicleSwitchEvent(VehicleSwitchEvent arg) => VehicleSwitchEvent?.Invoke(this, arg);
    }
}
