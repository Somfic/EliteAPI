using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SynthesisEvent : EventBase<SynthesisEvent>
    {
        internal SynthesisEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Materials")]
        public IReadOnlyList<MaterialInfo> Materials { get; private set; }
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class MaterialInfo
    {
        internal MaterialInfo() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SynthesisEvent> SynthesisEvent;

    }
}