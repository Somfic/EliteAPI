
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class SupercruiseEntryEvent : EventBase
    {
        internal SupercruiseEntryEvent() { }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; private set; }
    }

    public partial class SupercruiseEntryEvent
    {
        public static SupercruiseEntryEvent FromJson(string json) => JsonConvert.DeserializeObject<SupercruiseEntryEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<SupercruiseEntryEvent> SupercruiseEntryEvent;
        internal void InvokeSupercruiseEntryEvent(SupercruiseEntryEvent arg) => SupercruiseEntryEvent?.Invoke(this, arg);
    }
}
