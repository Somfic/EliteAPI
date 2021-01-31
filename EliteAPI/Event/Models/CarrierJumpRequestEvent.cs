using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class CarrierJumpRequestEvent : EventBase
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

    public partial class CarrierJumpRequestEvent
    {
        public static CarrierJumpRequestEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CarrierJumpRequestEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CarrierJumpRequestEvent> CarrierJumpRequestEvent;

        internal void InvokeCarrierJumpRequestEvent(CarrierJumpRequestEvent arg)
        {
            CarrierJumpRequestEvent?.Invoke(this, arg);
        }
    }
}