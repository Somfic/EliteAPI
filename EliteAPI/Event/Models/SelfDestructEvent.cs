
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class SelfDestructEvent : EventBase
    {
        internal SelfDestructEvent() { }

        [JsonProperty("event")]
        public string Event { get; private set; }
    }

    public partial class SelfDestructEvent
    {
        public static SelfDestructEvent FromJson(string json) => JsonConvert.DeserializeObject<SelfDestructEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<SelfDestructEvent> SelfDestructEvent;
        internal void InvokeSelfDestructEvent(SelfDestructEvent arg) => SelfDestructEvent?.Invoke(this, arg);
    }
}
