using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class EscapeInterdictionEvent : EventBase
    {
        internal EscapeInterdictionEvent() { }

        [JsonProperty("Interdictor")]
        public string Interdictor { get; private set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; private set; }
    }

    public partial class EscapeInterdictionEvent
    {
        public static EscapeInterdictionEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<EscapeInterdictionEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<EscapeInterdictionEvent> EscapeInterdictionEvent;

        internal void InvokeEscapeInterdictionEvent(EscapeInterdictionEvent arg)
        {
            EscapeInterdictionEvent?.Invoke(this, arg);
        }
    }
}