
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class MaterialDiscoveredEvent : EventBase
    {
        internal MaterialDiscoveredEvent() { }

        [JsonProperty("Category")]
        public string Category { get; private set; }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("DiscoveryNumber")]
        public long DiscoveryNumber { get; private set; }
    }

    public partial class MaterialDiscoveredEvent
    {
        public static MaterialDiscoveredEvent FromJson(string json) => JsonConvert.DeserializeObject<MaterialDiscoveredEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<MaterialDiscoveredEvent> MaterialDiscoveredEvent;
        internal void InvokeMaterialDiscoveredEvent(MaterialDiscoveredEvent arg) => MaterialDiscoveredEvent?.Invoke(this, arg);
    }
}
