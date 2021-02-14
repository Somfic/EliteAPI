using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SaaSignalsFoundEvent : EventBase<SaaSignalsFoundEvent>
    {
        internal SaaSignalsFoundEvent() { }

        [JsonProperty("BodyName")]
        public string BodyName { get; private set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }

        [JsonProperty("BodyID")]
        public string BodyId { get; private set; }

        [JsonProperty("Signals")]
        public IReadOnlyList<Signal> Signals { get; private set; }
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class Signal
    {
        internal Signal() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }

        [JsonProperty("Type_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string TypeLocalised { get; private set; }
    }



}

namespace EliteAPI.Event.Handler
{

    public partial class EventHandler
    {
        public event EventHandler<SaaSignalsFoundEvent> SaaSignalsFoundEvent;
    }
}