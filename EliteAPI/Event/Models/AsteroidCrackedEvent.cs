
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class AsteroidCrackedEvent : EventBase
    {
        internal AsteroidCrackedEvent() { }

        [JsonProperty("Body")]
        public string Body { get; private set; }
    }

    public partial class AsteroidCrackedEvent
    {
        public static AsteroidCrackedEvent FromJson(string json) => JsonConvert.DeserializeObject<AsteroidCrackedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<AsteroidCrackedEvent> AsteroidCrackedEvent;
        internal void InvokeAsteroidCrackedEvent(AsteroidCrackedEvent arg) => AsteroidCrackedEvent?.Invoke(this, arg);
    }
}
