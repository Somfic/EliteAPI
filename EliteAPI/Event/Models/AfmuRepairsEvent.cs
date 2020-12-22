using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class AfmuRepairsEvent : EventBase
    {
        internal AfmuRepairsEvent()
        {
        }

        [JsonProperty("Module")] public string Module { get; private set; }

        [JsonProperty("Module_Localised")] public string ModuleLocalised { get; private set; }

        [JsonProperty("FullyRepaired")] public bool FullyRepaired { get; private set; }

        [JsonProperty("Health")] public double Health { get; private set; }
    }

    public partial class AfmuRepairsEvent
    {
        public static AfmuRepairsEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<AfmuRepairsEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<AfmuRepairsEvent> AfmuRepairsEvent;

        internal void InvokeAfmuRepairsEvent(AfmuRepairsEvent arg)
        {
            AfmuRepairsEvent?.Invoke(this, arg);
        }
    }
}