using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class QuitACrewEvent : EventBase<QuitACrewEvent>
    {
        internal QuitACrewEvent() { }

        [JsonProperty("Captain")]
        public string Captain { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<QuitACrewEvent> QuitACrewEvent;

    }
}