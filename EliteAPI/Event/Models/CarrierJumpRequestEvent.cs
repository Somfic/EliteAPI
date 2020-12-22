using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class CarrierJumpRequestEvent : EventBase
    {
        internal CarrierJumpRequestEvent()
        {
        }

        [JsonProperty("CarrierID")] public long CarrierId { get; private set; }

        [JsonProperty("SystemName")] public string SystemName { get; private set; }

        [JsonProperty("Body")] public string Body { get; private set; }

        [JsonProperty("SystemAddress")] public long SystemAddress { get; private set; }

        [JsonProperty("BodyID")] public long BodyId { get; private set; }
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