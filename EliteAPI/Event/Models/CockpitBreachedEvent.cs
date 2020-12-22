using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class CockpitBreachedEvent : EventBase
    {
        internal CockpitBreachedEvent()
        {
        }

        [JsonProperty("event")] public string Event { get; private set; }
    }

    public partial class CockpitBreachedEvent
    {
        public static CockpitBreachedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CockpitBreachedEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CockpitBreachedEvent> CockpitBreachedEvent;

        internal void InvokeCockpitBreachedEvent(CockpitBreachedEvent arg)
        {
            CockpitBreachedEvent?.Invoke(this, arg);
        }
    }
}