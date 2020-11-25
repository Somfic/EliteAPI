
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class EjectCargoEvent : EventBase
    {
        internal EjectCargoEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }

        [JsonProperty("Abandoned")]
        public bool Abandoned { get; private set; }
    }

    public partial class EjectCargoEvent
    {
        public static EjectCargoEvent FromJson(string json) => JsonConvert.DeserializeObject<EjectCargoEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<EjectCargoEvent> EjectCargoEvent;
        internal void InvokeEjectCargoEvent(EjectCargoEvent arg) => EjectCargoEvent?.Invoke(this, arg);
    }
}
