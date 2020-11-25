using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class InterdictionEvent : EventBase
    {
        internal InterdictionEvent()
        {
        }

        [JsonProperty("Success")] public bool Success { get; private set; }

        [JsonProperty("IsPlayer")] public bool IsPlayer { get; private set; }

        [JsonProperty("Faction")] public string Faction { get; private set; }
    }

    public partial class InterdictionEvent
    {
        public static InterdictionEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<InterdictionEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<InterdictionEvent> InterdictionEvent;

        internal void InvokeInterdictionEvent(InterdictionEvent arg)
        {
            InterdictionEvent?.Invoke(this, arg);
        }
    }
}