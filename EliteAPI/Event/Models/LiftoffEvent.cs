using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
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
        public static LiftoffEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LiftoffEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<LiftoffEvent> LiftoffEvent;

        internal void InvokeLiftoffEvent(LiftoffEvent arg)
        {
            LiftoffEvent?.Invoke(this, arg);
        }
    }
}