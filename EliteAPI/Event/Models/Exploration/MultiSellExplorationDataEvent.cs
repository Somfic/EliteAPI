using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class MultiSellExplorationDataEvent : EventBase<MultiSellExplorationDataEvent>
    {
        internal MultiSellExplorationDataEvent() { }

        [JsonProperty("Discovered")]
        public IReadOnlyList<Discovered> Discovered { get; private set; }

        [JsonProperty("BaseValue")]
        public long BaseValue { get; private set; }

        [JsonProperty("Bonus")]
        public long Bonus { get; private set; }

        [JsonProperty("TotalEarnings")]
        public long TotalEarnings { get; private set; }
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class Discovered
    {
        internal Discovered() { }

        [JsonProperty("SystemName")]
        public string SystemName { get; private set; }

        [JsonProperty("NumBodies")]
        public long NumBodies { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MultiSellExplorationDataEvent> MultiSellExplorationDataEvent;

    }
}