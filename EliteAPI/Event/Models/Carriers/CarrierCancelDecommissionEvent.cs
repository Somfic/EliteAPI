using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CarrierCancelDecommissionEvent : EventBase<CarrierCancelDecommissionEvent>
    {
        internal CarrierCancelDecommissionEvent() { }

        [JsonProperty("CarrierID")]
        public string CarrierId { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CarrierCancelDecommissionEvent> CarrierCancelDecommissionEvent;

    }
}