
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class SynthesisEvent : EventBase
    {
        internal SynthesisEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Materials")]
        public IReadOnlyList<Material> Materials { get; private set; }
    }

    public partial class Material
    {
        internal Material() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }
    }

    public partial class SynthesisEvent
    {
        public static SynthesisEvent FromJson(string json) => JsonConvert.DeserializeObject<SynthesisEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<SynthesisEvent> SynthesisEvent;
        internal void InvokeSynthesisEvent(SynthesisEvent arg) => SynthesisEvent?.Invoke(this, arg);
    }
}
