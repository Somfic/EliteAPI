
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class InterdictedEvent : EventBase
    {
        internal InterdictedEvent() { }

        [JsonProperty("Submitted")]
        public bool Submitted { get; private set; }

        [JsonProperty("Interdictor")]
        public string Interdictor { get; private set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; private set; }

        [JsonProperty("Faction")]
        public string Faction { get; private set; }
    }

    public partial class InterdictedEvent
    {
        public static InterdictedEvent FromJson(string json) => JsonConvert.DeserializeObject<InterdictedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<InterdictedEvent> InterdictedEvent;
        internal void InvokeInterdictedEvent(InterdictedEvent arg) => InterdictedEvent?.Invoke(this, arg);
    }
}
