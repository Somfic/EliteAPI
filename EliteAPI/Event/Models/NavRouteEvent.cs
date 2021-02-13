using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
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