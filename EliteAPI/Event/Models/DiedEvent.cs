
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class DiedEvent : EventBase
    {
        internal DiedEvent() { }

        [JsonProperty("event")]
        public string Event { get; private set; }
    }

    public partial class DiedEvent
    {
        public static DiedEvent FromJson(string json) => JsonConvert.DeserializeObject<DiedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<DiedEvent> DiedEvent;
        internal void InvokeDiedEvent(DiedEvent arg) => DiedEvent?.Invoke(this, arg);
    }
}
