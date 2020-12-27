
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CarrierJumpCancelledEvent : EventBase
    {
        internal CarrierJumpCancelledEvent() { }

        [JsonProperty("CarrierID")]
        public long CarrierId { get; private set; }
    }

    public partial class CarrierJumpCancelledEvent
    {
        public static CarrierJumpCancelledEvent FromJson(string json) => JsonConvert.DeserializeObject<CarrierJumpCancelledEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CarrierJumpCancelledEvent> CarrierJumpCancelledEvent;
        internal void InvokeCarrierJumpCancelledEvent(CarrierJumpCancelledEvent arg) => CarrierJumpCancelledEvent?.Invoke(this, arg);
    }
}
