using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class EndCrewSessionEvent : EventBase<EndCrewSessionEvent>
    {
        internal EndCrewSessionEvent() { }

        [JsonProperty("OnCrime")]
        public bool OnCrime { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<EndCrewSessionEvent> EndCrewSessionEvent;

    }
}