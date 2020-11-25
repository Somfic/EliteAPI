
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class MiningRefinedEvent : EventBase
    {
        internal MiningRefinedEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; private set; }
    }

    public partial class MiningRefinedEvent
    {
        public static MiningRefinedEvent FromJson(string json) => JsonConvert.DeserializeObject<MiningRefinedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<MiningRefinedEvent> MiningRefinedEvent;
        internal void InvokeMiningRefinedEvent(MiningRefinedEvent arg) => MiningRefinedEvent?.Invoke(this, arg);
    }
}
