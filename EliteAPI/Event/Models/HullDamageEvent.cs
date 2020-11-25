
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class HullDamageEvent : EventBase
    {
        internal HullDamageEvent() { }

        [JsonProperty("Health")]
        public double Health { get; private set; }

        [JsonProperty("PlayerPilot")]
        public bool PlayerPilot { get; private set; }

        [JsonProperty("Fighter")]
        public bool Fighter { get; private set; }
    }

    public partial class HullDamageEvent
    {
        public static HullDamageEvent FromJson(string json) => JsonConvert.DeserializeObject<HullDamageEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<HullDamageEvent> HullDamageEvent;
        internal void InvokeHullDamageEvent(HullDamageEvent arg) => HullDamageEvent?.Invoke(this, arg);
    }
}
