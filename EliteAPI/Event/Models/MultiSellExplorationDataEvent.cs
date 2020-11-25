
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


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

    public partial class Discovered
    {
        internal Discovered() { }

        [JsonProperty("SystemName")]
        public string SystemName { get; private set; }

        [JsonProperty("NumBodies")]
        public long NumBodies { get; private set; }
    }

    public partial class MultiSellExplorationDataEvent
    {
        public static MultiSellExplorationDataEvent FromJson(string json) => JsonConvert.DeserializeObject<MultiSellExplorationDataEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<MultiSellExplorationDataEvent> MultiSellExplorationDataEvent;
        internal void InvokeMultiSellExplorationDataEvent(MultiSellExplorationDataEvent arg) => MultiSellExplorationDataEvent?.Invoke(this, arg);
    }
}
