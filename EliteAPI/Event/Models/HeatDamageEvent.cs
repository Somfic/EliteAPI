using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class HeatDamageEvent : EventBase
    {
        internal HeatDamageEvent()
        {
        }

        [JsonProperty("event")] public string Event { get; private set; }
    }

    public partial class HeatDamageEvent
    {
        public static HeatDamageEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<HeatDamageEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<HeatDamageEvent> HeatDamageEvent;

        internal void InvokeHeatDamageEvent(HeatDamageEvent arg)
        {
            HeatDamageEvent?.Invoke(this, arg);
        }
    }
}