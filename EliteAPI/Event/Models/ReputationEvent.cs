
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ReputationEvent : EventBase
    {
        internal ReputationEvent() { }

        [JsonProperty("Empire")]
        public double Empire { get; private set; }

        [JsonProperty("Federation")]
        public double Federation { get; private set; }

        [JsonProperty("Alliance")]
        public double Alliance { get; private set; }
    }

    public partial class ReputationEvent
    {
        public static ReputationEvent FromJson(string json) => JsonConvert.DeserializeObject<ReputationEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ReputationEvent> ReputationEvent;
        internal void InvokeReputationEvent(ReputationEvent arg) => ReputationEvent?.Invoke(this, arg);
    }
}
