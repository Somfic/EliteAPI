using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class CarrierCancelDecommissionEvent : EventBase
    {
        internal CarrierCancelDecommissionEvent() { }

        [JsonProperty("CarrierID")]
        public string CarrierId { get; private set; }
    }

    public partial class CarrierCancelDecommissionEvent
    {
        public static CarrierCancelDecommissionEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CarrierCancelDecommissionEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CarrierCancelDecommissionEvent> CarrierCancelDecommissionEvent;

        internal void InvokeCarrierCancelDecommissionEvent(CarrierCancelDecommissionEvent arg)
        {
            CarrierCancelDecommissionEvent?.Invoke(this, arg);
        }
    }
}