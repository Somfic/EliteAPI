using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class NavRouteEvent : EventBase
    {
        internal NavRouteEvent() { }
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
        [Obsolete("Use IEliteDangerousAPI.NavRoute.OnChange instead")]
        public event EventHandler<NavRouteEvent> NavRouteEvent;

        internal void InvokeNavRouteEvent(NavRouteEvent arg)
        {
            NavRouteEvent?.Invoke(this, arg);
        }
    }
}