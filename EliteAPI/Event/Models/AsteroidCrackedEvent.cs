using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class AsteroidCrackedEvent : EventBase
    {
        internal AsteroidCrackedEvent() { }

        [JsonProperty("Body")]
        public string Body { get; private set; }
    }

    public partial class AsteroidCrackedEvent
    {
        public static AsteroidCrackedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<AsteroidCrackedEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<AsteroidCrackedEvent> AsteroidCrackedEvent;

        internal void InvokeAsteroidCrackedEvent(AsteroidCrackedEvent arg)
        {
            AsteroidCrackedEvent?.Invoke(this, arg);
        }
    }
}