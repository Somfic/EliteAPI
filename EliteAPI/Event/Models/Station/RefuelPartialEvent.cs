using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class RefuelPartialEvent : EventBase
    {
        internal RefuelPartialEvent() { }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }

        [JsonProperty("Amount")]
        public double Amount { get; private set; }
    }

    public partial class RefuelPartialEvent
    {
        public static RefuelPartialEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RefuelPartialEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<RefuelPartialEvent> RefuelPartialEvent;

        internal void InvokeRefuelPartialEvent(RefuelPartialEvent arg)
        {
            RefuelPartialEvent?.Invoke(this, arg);
        }
    }
}