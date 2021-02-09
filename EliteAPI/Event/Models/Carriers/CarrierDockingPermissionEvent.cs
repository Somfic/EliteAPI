using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class CarrierDockingPermissionEvent : EventBase
    {
        internal CarrierDockingPermissionEvent() { }

        [JsonProperty("CarrierID")]
        public string CarrierId { get; private set; }

        [JsonProperty("DockingAccess")]
        public string DockingAccess { get; private set; }
        
        [JsonProperty("AllowNotorious")]
        public bool AllowNotorious { get; private set; }
    }

    public partial class CarrierDockingPermissionEvent
    {
        public static CarrierDockingPermissionEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CarrierDockingPermissionEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CarrierDockingPermissionEvent> CarrierDockingPermissionEvent;

        internal void InvokeCarrierDockingPermissionEvent(CarrierDockingPermissionEvent arg)
        {
            CarrierDockingPermissionEvent?.Invoke(this, arg);
        }
    }
}