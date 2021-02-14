using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class NavRouteEvent : EventBase<NavRouteEvent>
    {
        internal NavRouteEvent() { }
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