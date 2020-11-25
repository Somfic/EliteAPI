
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ResurrectEvent : EventBase
    {
        internal ResurrectEvent() { }

        [JsonProperty("Option")]
        public string Option { get; private set; }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }

        [JsonProperty("Bankrupt")]
        public bool Bankrupt { get; private set; }
    }

    public partial class ResurrectEvent
    {
        public static ResurrectEvent FromJson(string json) => JsonConvert.DeserializeObject<ResurrectEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ResurrectEvent> ResurrectEvent;
        internal void InvokeResurrectEvent(ResurrectEvent arg) => ResurrectEvent?.Invoke(this, arg);
    }
}
