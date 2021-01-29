using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{


    public partial class CarrierJumpCancelledEvent : EventBase
    {
        internal CarrierJumpCancelledEvent() { }

        [JsonProperty("CarrierID")]
        public long CarrierId { get; private set; }
    }

    public partial class CarrierJumpCancelledEvent
    {
        public static CarrierJumpCancelledEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CarrierJumpCancelledEvent>(json);
        }
    }


}

namespace EliteAPI.Event.Handler
{

    public partial class EventHandler
    {
        public event EventHandler<CarrierJumpCancelledEvent> CarrierJumpCancelledEvent;
        internal void InvokeCarrierJumpCancelledEvent(CarrierJumpCancelledEvent arg)
        {
            CarrierJumpCancelledEvent?.Invoke(this, arg);
        }
    }
}