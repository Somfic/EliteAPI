using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class MarketBuyEvent : EventBase<MarketBuyEvent>
    {
        internal MarketBuyEvent() { }

        [JsonProperty("MarketID")]
        public string MarketId { get; private set; }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; private set; }

        [JsonProperty("TotalCost")]
        public long TotalCost { get; private set; }
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