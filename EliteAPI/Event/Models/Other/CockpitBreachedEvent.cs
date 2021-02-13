using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class CockpitBreachedEvent : EventBase
    {
        internal CockpitBreachedEvent() { }
    }

    public partial class CockpitBreachedEvent
    {
        public static CockpitBreachedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CockpitBreachedEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CockpitBreachedEvent> CockpitBreachedEvent;

        internal void InvokeCockpitBreachedEvent(CockpitBreachedEvent arg)
        {
            CockpitBreachedEvent?.Invoke(this, arg);
        }
    }
}