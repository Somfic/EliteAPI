
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class JoinACrewEvent : EventBase
    {
        internal JoinACrewEvent() { }

        [JsonProperty("Captain")]
        public string Captain { get; private set; }
    }

    public partial class JoinACrewEvent
    {
        public static JoinACrewEvent FromJson(string json) => JsonConvert.DeserializeObject<JoinACrewEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<JoinACrewEvent> JoinACrewEvent;
        internal void InvokeJoinACrewEvent(JoinACrewEvent arg) => JoinACrewEvent?.Invoke(this, arg);
    }
}
