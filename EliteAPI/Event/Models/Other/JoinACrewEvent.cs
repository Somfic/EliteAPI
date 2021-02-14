using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class JoinACrewEvent : EventBase<JoinACrewEvent>
    {
        internal JoinACrewEvent() { }

        [JsonProperty("Captain")]
        public string Captain { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<JoinACrewEvent> JoinACrewEvent;

    }
}