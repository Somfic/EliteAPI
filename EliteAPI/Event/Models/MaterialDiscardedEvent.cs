
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class MaterialDiscardedEvent : EventBase
    {
        internal MaterialDiscardedEvent() { }

        [JsonProperty("Category")]
        public string Category { get; private set; }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }
    }

    public partial class MaterialDiscardedEvent
    {
        public static MaterialDiscardedEvent FromJson(string json) => JsonConvert.DeserializeObject<MaterialDiscardedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<MaterialDiscardedEvent> MaterialDiscardedEvent;
        internal void InvokeMaterialDiscardedEvent(MaterialDiscardedEvent arg) => MaterialDiscardedEvent?.Invoke(this, arg);
    }
}
