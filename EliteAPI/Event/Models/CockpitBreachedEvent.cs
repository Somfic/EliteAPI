
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CockpitBreachedEvent : EventBase
    {
        internal CockpitBreachedEvent() { }

        [JsonProperty("event")]
        public string Event { get; private set; }
    }

    public partial class CockpitBreachedEvent
    {
        public static CockpitBreachedEvent FromJson(string json) => JsonConvert.DeserializeObject<CockpitBreachedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CockpitBreachedEvent> CockpitBreachedEvent;
        internal void InvokeCockpitBreachedEvent(CockpitBreachedEvent arg) => CockpitBreachedEvent?.Invoke(this, arg);
    }
}
