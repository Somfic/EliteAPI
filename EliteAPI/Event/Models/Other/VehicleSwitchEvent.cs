using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class VehicleSwitchEvent : EventBase<VehicleSwitchEvent>
    {
        internal VehicleSwitchEvent() { }

        [JsonProperty("To")]
        public string To { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<VehicleSwitchEvent> VehicleSwitchEvent;

    }
}