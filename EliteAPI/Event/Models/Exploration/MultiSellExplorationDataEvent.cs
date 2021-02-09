using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class MultiSellExplorationDataEvent : EventBase
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

    public class Discovered
    {
        internal Discovered() { }

        [JsonProperty("SystemName")]
        public string SystemName { get; private set; }

        [JsonProperty("NumBodies")]
        public long NumBodies { get; private set; }
    }

    public partial class MultiSellExplorationDataEvent
    {
        public static MultiSellExplorationDataEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MultiSellExplorationDataEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MultiSellExplorationDataEvent> MultiSellExplorationDataEvent;

        internal void InvokeMultiSellExplorationDataEvent(MultiSellExplorationDataEvent arg)
        {
            MultiSellExplorationDataEvent?.Invoke(this, arg);
        }
    }
}