using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
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
        public static MarketBuyEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MarketBuyEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MarketBuyEvent> MarketBuyEvent;

        internal void InvokeMarketBuyEvent(MarketBuyEvent arg)
        {
            MarketBuyEvent?.Invoke(this, arg);
        }
    }
}