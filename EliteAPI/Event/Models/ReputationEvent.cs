using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class ReputationEvent : EventBase
    {
        internal ReputationEvent() { }

        [JsonProperty("Empire")]
        public double Empire { get; private set; }

        [JsonProperty("Federation")]
        public double Federation { get; private set; }

        [JsonProperty("Independent")]
        public double Independent { get; private set; }

        [JsonProperty("Alliance")]
        public double Alliance { get; private set; }
    }

    public partial class ReputationEvent
    {
        public static ReputationEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ReputationEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ReputationEvent> ReputationEvent;

        internal void InvokeReputationEvent(ReputationEvent arg)
        {
            ReputationEvent?.Invoke(this, arg);
        }
    }
}