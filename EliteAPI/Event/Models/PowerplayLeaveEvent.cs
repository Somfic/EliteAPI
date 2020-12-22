using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class PowerplayLeaveEvent : EventBase
    {
        internal PowerplayLeaveEvent()
        {
        }

        [JsonProperty("Power")] public string Power { get; private set; }
    }

    public partial class PowerplayLeaveEvent
    {
        public static PowerplayLeaveEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayLeaveEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplayLeaveEvent> PowerplayLeaveEvent;

        internal void InvokePowerplayLeaveEvent(PowerplayLeaveEvent arg)
        {
            PowerplayLeaveEvent?.Invoke(this, arg);
        }
    }
}