using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CarrierDockingPermissionEvent : EventBase<CarrierDockingPermissionEvent>
    {
        internal CarrierDockingPermissionEvent() { }

        [JsonProperty("CarrierID")]
        public string CarrierId { get; private set; }

        [JsonProperty("DockingAccess")]
        public string DockingAccess { get; private set; }

        [JsonProperty("AllowNotorious")]
        public bool AllowsNotorious { get; private set; }
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