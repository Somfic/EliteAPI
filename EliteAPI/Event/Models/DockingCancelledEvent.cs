using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class DockingCancelledEvent : EventBase
    {
        internal DockingCancelledEvent()
        {
        }

        [JsonProperty("StationName")] public string StationName { get; private set; }
    }

    public partial class DockingCancelledEvent
    {
        public static DockingCancelledEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DockingCancelledEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DockingCancelledEvent> DockingCancelledEvent;

        internal void InvokeDockingCancelledEvent(DockingCancelledEvent arg)
        {
            DockingCancelledEvent?.Invoke(this, arg);
        }
    }
}