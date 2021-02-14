using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class AsteroidCrackedEvent : EventBase<AsteroidCrackedEvent>
    {
        internal AsteroidCrackedEvent() { }

        [JsonProperty("Body")]
        public string Body { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<AsteroidCrackedEvent> AsteroidCrackedEvent;

    }
}