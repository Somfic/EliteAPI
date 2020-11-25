
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class BuyExplorationDataEvent : EventBase
    {
        internal BuyExplorationDataEvent() { }

        [JsonProperty("System")]
        public string System { get; private set; }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }
    }

    public partial class BuyExplorationDataEvent
    {
        public static BuyExplorationDataEvent FromJson(string json) => JsonConvert.DeserializeObject<BuyExplorationDataEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<BuyExplorationDataEvent> BuyExplorationDataEvent;
        internal void InvokeBuyExplorationDataEvent(BuyExplorationDataEvent arg) => BuyExplorationDataEvent?.Invoke(this, arg);
    }
}
