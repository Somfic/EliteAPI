
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class FssSignalDiscoveredEvent : EventBase
    {
        internal FssSignalDiscoveredEvent() { }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; private set; }

        [JsonProperty("SignalName")]
        public string SignalName { get; private set; }
    }

    public partial class FssSignalDiscoveredEvent
    {
        public static FssSignalDiscoveredEvent FromJson(string json) => JsonConvert.DeserializeObject<FssSignalDiscoveredEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<FssSignalDiscoveredEvent> FssSignalDiscoveredEvent;
        internal void InvokeFssSignalDiscoveredEvent(FssSignalDiscoveredEvent arg) => FssSignalDiscoveredEvent?.Invoke(this, arg);
    }
}
