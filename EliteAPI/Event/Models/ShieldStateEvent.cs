using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class ShieldStateEvent : EventBase
    {
        internal ShieldStateEvent()
        {
        }

        [JsonProperty("ShieldsUp")] public bool ShieldsUp { get; private set; }
    }

    public partial class ShieldStateEvent
    {
        public static ShieldStateEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ShieldStateEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ShieldStateEvent> ShieldStateEvent;

        internal void InvokeShieldStateEvent(ShieldStateEvent arg)
        {
            ShieldStateEvent?.Invoke(this, arg);
        }
    }
}