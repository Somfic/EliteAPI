
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class AfmuRepairsEvent : EventBase
    {
        internal AfmuRepairsEvent() { }

        [JsonProperty("Module")]
        public string Module { get; private set; }

        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; private set; }

        [JsonProperty("FullyRepaired")]
        public bool FullyRepaired { get; private set; }

        [JsonProperty("Health")]
        public double Health { get; private set; }
    }

    public partial class AfmuRepairsEvent
    {
        public static AfmuRepairsEvent FromJson(string json) => JsonConvert.DeserializeObject<AfmuRepairsEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<AfmuRepairsEvent> AfmuRepairsEvent;
        internal void InvokeAfmuRepairsEvent(AfmuRepairsEvent arg) => AfmuRepairsEvent?.Invoke(this, arg);
    }
}
