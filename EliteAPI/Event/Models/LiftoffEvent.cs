
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class LiftoffEvent : EventBase
    {
        internal LiftoffEvent() { }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; private set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; private set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; private set; }
    }

    public partial class LiftoffEvent
    {
        public static LiftoffEvent FromJson(string json) => JsonConvert.DeserializeObject<LiftoffEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<LiftoffEvent> LiftoffEvent;
        internal void InvokeLiftoffEvent(LiftoffEvent arg) => LiftoffEvent?.Invoke(this, arg);
    }
}
