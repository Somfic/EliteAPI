
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class InterdictionEvent : EventBase
    {
        internal InterdictionEvent() { }

        [JsonProperty("Success")]
        public bool Success { get; private set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; private set; }

        [JsonProperty("Faction")]
        public string Faction { get; private set; }
    }

    public partial class InterdictionEvent
    {
        public static InterdictionEvent FromJson(string json) => JsonConvert.DeserializeObject<InterdictionEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<InterdictionEvent> InterdictionEvent;
        internal void InvokeInterdictionEvent(InterdictionEvent arg) => InterdictionEvent?.Invoke(this, arg);
    }
}
