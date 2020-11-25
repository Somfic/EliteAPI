
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class MarketBuyEvent : EventBase
    {
        internal MarketBuyEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; private set; }

        [JsonProperty("TotalCost")]
        public long TotalCost { get; private set; }
    }

    public partial class MarketBuyEvent
    {
        public static MarketBuyEvent FromJson(string json) => JsonConvert.DeserializeObject<MarketBuyEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<MarketBuyEvent> MarketBuyEvent;
        internal void InvokeMarketBuyEvent(MarketBuyEvent arg) => MarketBuyEvent?.Invoke(this, arg);
    }
}
