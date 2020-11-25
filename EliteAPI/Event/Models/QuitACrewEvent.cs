
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class QuitACrewEvent : EventBase
    {
        internal QuitACrewEvent() { }

        [JsonProperty("Captain")]
        public string Captain { get; private set; }
    }

    public partial class QuitACrewEvent
    {
        public static QuitACrewEvent FromJson(string json) => JsonConvert.DeserializeObject<QuitACrewEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<QuitACrewEvent> QuitACrewEvent;
        internal void InvokeQuitACrewEvent(QuitACrewEvent arg) => QuitACrewEvent?.Invoke(this, arg);
    }
}
