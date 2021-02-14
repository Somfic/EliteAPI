using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SellExplorationDataEvent : EventBase<SellExplorationDataEvent>
    {
        internal SellExplorationDataEvent() { }

        [JsonProperty("Systems")]
        public IReadOnlyList<string> Systems { get; private set; }

        [JsonProperty("Discovered")]
        public IReadOnlyList<string> Discovered { get; private set; }

        [JsonProperty("BaseValue")]
        public long BaseValue { get; private set; }

        [JsonProperty("Bonus")]
        public long Bonus { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SellExplorationDataEvent> SellExplorationDataEvent;

    }
}