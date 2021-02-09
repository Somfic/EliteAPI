using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class CarrierCrewServicesEvent : EventBase
    {
        internal CarrierCrewServicesEvent() { }

        [JsonProperty("CarrierID")]
        public string CarrierId { get; private set; }

        [JsonProperty("Operation")]
        public string Operation { get; private set; }

        [JsonProperty("CrewRole")]
        public string CrewRole { get; private set; }

        [JsonProperty("CrewName")]
        public string CrewName { get; private set; }
    }

    public partial class CarrierCrewServicesEvent
    {
        public static CarrierCrewServicesEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CarrierCrewServicesEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CarrierCrewServicesEvent> CarrierCrewServicesEvent;

        internal void InvokeCarrierCrewServicesEvent(CarrierCrewServicesEvent arg)
        {
            CarrierCrewServicesEvent?.Invoke(this, arg);
        }
    }
}