using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CarrierCrewServicesEvent : EventBase<CarrierCrewServicesEvent>
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

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CarrierCrewServicesEvent> CarrierCrewServicesEvent;

    }
}