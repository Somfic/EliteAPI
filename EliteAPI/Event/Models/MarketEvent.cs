
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class MarketEvent : EventBase
    {
        internal MarketEvent() { }

        [JsonProperty("MarketID")]
        public long MarketId { get; private set; }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }
    }

    public partial class MarketEvent
    {
        public static MarketEvent FromJson(string json) => JsonConvert.DeserializeObject<MarketEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<MarketEvent> MarketEvent;
        internal void InvokeMarketEvent(MarketEvent arg) => MarketEvent?.Invoke(this, arg);
    }
}
