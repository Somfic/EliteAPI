
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class SaaSignalsFoundEvent : EventBase
    {
        internal SaaSignalsFoundEvent() { }

        [JsonProperty("BodyName")]
        public string BodyName { get; private set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; private set; }

        [JsonProperty("Signals")]
        public IReadOnlyList<Signal> Signals { get; private set; }
    }

    public partial class Signal
    {
        internal Signal() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }

        [JsonProperty("Type_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string TypeLocalised { get; private set; }
    }

    public partial class SaaSignalsFoundEvent
    {
        public static SaaSignalsFoundEvent FromJson(string json) => JsonConvert.DeserializeObject<SaaSignalsFoundEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<SaaSignalsFoundEvent> SaaSignalsFoundEvent;
        internal void InvokeSaaSignalsFoundEvent(SaaSignalsFoundEvent arg) => SaaSignalsFoundEvent?.Invoke(this, arg);
    }
}
