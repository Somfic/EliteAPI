using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class FsdTargetEvent : EventBase
    {
        internal FsdTargetEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; private set; }

        [JsonProperty("StarClass")]
        public string StarClass { get; private set; }
        
        [JsonProperty("RemainingJumpsInRoute")]
        public int RemainingJumpsInRoute { get; private set; }
    }

    public partial class FsdTargetEvent
    {
        public static FsdTargetEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FsdTargetEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<FsdTargetEvent> FsdTargetEvent;

        internal void InvokeFsdTargetEvent(FsdTargetEvent arg)
        {
            FsdTargetEvent?.Invoke(this, arg);
        }
    }
}