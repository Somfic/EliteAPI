using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CarrierJumpRequestEvent : EventBase<CarrierJumpRequestEvent>
    {
        internal CarrierJumpRequestEvent() { }

        [JsonProperty("CarrierID")]
        public string CarrierId { get; private set; }

        [JsonProperty("SystemName")]
        public string SystemName { get; private set; }

        [JsonProperty("Body")]
        public string Body { get; private set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }

        [JsonProperty("BodyID")]
        public string BodyId { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CarrierJumpRequestEvent> CarrierJumpRequestEvent;

    }
}