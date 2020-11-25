
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class FssDiscoveryScanEvent : EventBase
    {
        internal FssDiscoveryScanEvent() { }

        [JsonProperty("Progress")]
        public double Progress { get; private set; }

        [JsonProperty("BodyCount")]
        public long BodyCount { get; private set; }

        [JsonProperty("NonBodyCount")]
        public long NonBodyCount { get; private set; }
    }

    public partial class FssDiscoveryScanEvent
    {
        public static FssDiscoveryScanEvent FromJson(string json) => JsonConvert.DeserializeObject<FssDiscoveryScanEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<FssDiscoveryScanEvent> FssDiscoveryScanEvent;
        internal void InvokeFssDiscoveryScanEvent(FssDiscoveryScanEvent arg) => FssDiscoveryScanEvent?.Invoke(this, arg);
    }
}
