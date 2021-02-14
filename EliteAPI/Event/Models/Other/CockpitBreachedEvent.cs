using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CockpitBreachedEvent : EventBase<CockpitBreachedEvent>
    {
        internal CockpitBreachedEvent() { }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CockpitBreachedEvent> CockpitBreachedEvent;

    }
}