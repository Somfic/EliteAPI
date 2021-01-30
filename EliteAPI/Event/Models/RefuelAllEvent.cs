using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class RefuelAllEvent : EventBase
    {
        internal RefuelAllEvent() { }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }

        [JsonProperty("Amount")]
        public double Amount { get; private set; }
    }

    public partial class RefuelAllEvent
    {
        public static RefuelAllEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RefuelAllEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<RefuelAllEvent> RefuelAllEvent;

        internal void InvokeRefuelAllEvent(RefuelAllEvent arg)
        {
            RefuelAllEvent?.Invoke(this, arg);
        }
    }
}