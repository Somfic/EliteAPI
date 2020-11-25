
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


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
        public static EscapeInterdictionEvent FromJson(string json) => JsonConvert.DeserializeObject<EscapeInterdictionEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<EscapeInterdictionEvent> EscapeInterdictionEvent;
        internal void InvokeEscapeInterdictionEvent(EscapeInterdictionEvent arg) => EscapeInterdictionEvent?.Invoke(this, arg);
    }
}
