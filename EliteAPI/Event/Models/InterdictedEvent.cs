using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class InterdictedEvent : EventBase
    {
        internal InterdictedEvent()
        {
        }

        [JsonProperty("Submitted")] public bool Submitted { get; private set; }

        [JsonProperty("Interdictor")] public string Interdictor { get; private set; }

        [JsonProperty("IsPlayer")] public bool IsPlayer { get; private set; }

        [JsonProperty("Faction")] public string Faction { get; private set; }
    }

    public partial class InterdictedEvent
    {
        public static InterdictedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<InterdictedEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<InterdictedEvent> InterdictedEvent;

        internal void InvokeInterdictedEvent(InterdictedEvent arg)
        {
            InterdictedEvent?.Invoke(this, arg);
        }
    }
}