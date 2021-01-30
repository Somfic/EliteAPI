using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{


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
        public static CarrierDepositFuelEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CarrierDepositFuelEvent>(json);
        }
    }


}

namespace EliteAPI.Event.Handler
{

    public partial class EventHandler
    {
        public event EventHandler<CarrierDepositFuelEvent> CarrierDepositFuelEvent;
        internal void InvokeCarrierDepositFuelEvent(CarrierDepositFuelEvent arg)
        {
            CarrierDepositFuelEvent?.Invoke(this, arg);
        }
    }
}