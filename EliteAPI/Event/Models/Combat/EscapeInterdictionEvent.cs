using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class EscapeInterdictionEvent : EventBase<EscapeInterdictionEvent>
    {
        internal EscapeInterdictionEvent() { }

        [JsonProperty("Interdictor")]
        public string Interdictor { get; private set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<EscapeInterdictionEvent> EscapeInterdictionEvent;

    }
}