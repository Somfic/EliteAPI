using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class NavRouteEvent : EventBase
    {
        internal NavRouteEvent()
        {
        }

        [JsonProperty("event")] public string Event { get; private set; }
    }

    public partial class NavRouteEvent
    {
        public static NavRouteEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<NavRouteEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<NavRouteEvent> NavRouteEvent;

        internal void InvokeNavRouteEvent(NavRouteEvent arg)
        {
            NavRouteEvent?.Invoke(this, arg);
        }
    }
}