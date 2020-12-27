using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class MiningRefinedEvent : EventBase
    {
        internal MiningRefinedEvent()
        {
        }

        [JsonProperty("Type")] public string Type { get; private set; }

        [JsonProperty("Type_Localised")] public string TypeLocalised { get; private set; }
    }

    public partial class MiningRefinedEvent
    {
        public static MiningRefinedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MiningRefinedEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MiningRefinedEvent> MiningRefinedEvent;

        internal void InvokeMiningRefinedEvent(MiningRefinedEvent arg)
        {
            MiningRefinedEvent?.Invoke(this, arg);
        }
    }
}