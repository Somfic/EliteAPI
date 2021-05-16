using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class InterdictionEvent : EventBase<InterdictionEvent>
    {
        internal InterdictionEvent() { }

        [JsonProperty("Success")]
        public bool IsSuccess { get; private set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; private set; }

        [JsonProperty("Faction")]
        public string Faction { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<InterdictionEvent> InterdictionEvent;

        internal void InvokeInterdictionEvent(InterdictionEvent arg)
        {
            InterdictionEvent?.Invoke(this, arg);
        }
    }
}