
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class SellExplorationDataEvent : EventBase
    {
        internal SellExplorationDataEvent() { }

        [JsonProperty("Systems")]
        public IReadOnlyList<string> Systems { get; private set; }

        [JsonProperty("Discovered")]
        public IReadOnlyList<object> Discovered { get; private set; }

        [JsonProperty("BaseValue")]
        public long BaseValue { get; private set; }

        [JsonProperty("Bonus")]
        public long Bonus { get; private set; }
    }

    public partial class SellExplorationDataEvent
    {
        public static SellExplorationDataEvent FromJson(string json) => JsonConvert.DeserializeObject<SellExplorationDataEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<SellExplorationDataEvent> SellExplorationDataEvent;
        internal void InvokeSellExplorationDataEvent(SellExplorationDataEvent arg) => SellExplorationDataEvent?.Invoke(this, arg);
    }
}
