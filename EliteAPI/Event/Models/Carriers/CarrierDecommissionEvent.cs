using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class CarrierDecommissionEvent : EventBase
    {
        internal CarrierDecommissionEvent() { }

        [JsonProperty("CarrierID")]
        public string CarrierId { get; private set; }

        [JsonProperty("ScrapRefund")]
        public long Refund { get; private set; }
        
        [JsonProperty("ScrapTime")]
        public long ScramTime { get; private set; }
    }

    public partial class CarrierDecommissionEvent
    {
        public static CarrierDecommissionEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CarrierDecommissionEvent>(json);
        }
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