
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CarrierDepositFuelEvent : EventBase
    {
        internal CarrierDepositFuelEvent() { }

        [JsonProperty("CarrierID")]
        public long CarrierId { get; private set; }

        [JsonProperty("Amount")]
        public long Amount { get; private set; }

        [JsonProperty("Total")]
        public long Total { get; private set; }
    }

    public partial class CarrierDepositFuelEvent
    {
        public static CarrierDepositFuelEvent FromJson(string json) => JsonConvert.DeserializeObject<CarrierDepositFuelEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CarrierDepositFuelEvent> CarrierDepositFuelEvent;
        internal void InvokeCarrierDepositFuelEvent(CarrierDepositFuelEvent arg) => CarrierDepositFuelEvent?.Invoke(this, arg);
    }
}
