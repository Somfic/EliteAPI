using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CarrierDecommissionEvent : EventBase<CarrierDecommissionEvent>
    {
        internal CarrierDecommissionEvent() { }

        [JsonProperty("CarrierID")]
        public string CarrierId { get; private set; }

        [JsonProperty("ScrapRefund")]
        public long Refund { get; private set; }

        [JsonProperty("ScrapTime")]
        public long ScramTime { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CarrierDecommissionEvent> CarrierDecommissionEvent;

        internal void InvokeCarrierDecommissionEvent(CarrierDecommissionEvent arg)
        {
            CarrierDecommissionEvent?.Invoke(this, arg);
        }
    }
}