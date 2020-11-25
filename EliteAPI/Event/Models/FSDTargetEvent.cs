
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class FsdTargetEvent : EventBase
    {
        internal FsdTargetEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; private set; }

        [JsonProperty("StarClass")]
        public string StarClass { get; private set; }
    }

    public partial class FsdTargetEvent
    {
        public static FsdTargetEvent FromJson(string json) => JsonConvert.DeserializeObject<FsdTargetEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<FsdTargetEvent> FsdTargetEvent;
        internal void InvokeFsdTargetEvent(FsdTargetEvent arg) => FsdTargetEvent?.Invoke(this, arg);
    }
}
