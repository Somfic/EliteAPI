
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class PassengersEvent : EventBase
    {
        internal PassengersEvent() { }

        [JsonProperty("Manifest")]
        public IReadOnlyList<Manifest> Manifest { get; private set; }
    }

    public partial class Manifest
    {
        internal Manifest() { }

        [JsonProperty("MissionID")]
        public long MissionId { get; private set; }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("VIP")]
        public bool Vip { get; private set; }

        [JsonProperty("Wanted")]
        public bool Wanted { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }
    }

    public partial class PassengersEvent
    {
        public static PassengersEvent FromJson(string json) => JsonConvert.DeserializeObject<PassengersEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<PassengersEvent> PassengersEvent;
        internal void InvokePassengersEvent(PassengersEvent arg) => PassengersEvent?.Invoke(this, arg);
    }
}
