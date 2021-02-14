using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class DiedEvent : EventBase<DiedEvent>
    {
        internal DiedEvent() { }

        [JsonProperty("KillerName")]
        public string KillerName { get; private set; }
        
        [JsonProperty("KillerShip")]
        public string KillerShip { get; private set; }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DiedEvent> DiedEvent;
    }
}