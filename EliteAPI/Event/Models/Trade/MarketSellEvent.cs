using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class MarketSellEvent : EventBase
    {
        internal MarketSellEvent() { }

        [JsonProperty("MarketID")]
        public string MarketId { get; private set; }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }

        [JsonProperty("SellPrice")]
        public long SellPrice { get; private set; }

        [JsonProperty("TotalSale")]
        public long TotalSale { get; private set; }

        [JsonProperty("AvgPricePaid")]
        public long AvgPricePaid { get; private set; }

        [JsonProperty("IllegalGoods")]
        public bool HasIllegalGoods { get; private set; }

        [JsonProperty("StolenGoods")]
        public bool HasStolenGoods { get; private set; }

        [JsonProperty("BlackMarket")]
        public bool IsBlackMarket { get; private set; }
    }

    public partial class MarketSellEvent
    {
        public static MarketSellEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MarketSellEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MarketSellEvent> MarketSellEvent;

        internal void InvokeMarketSellEvent(MarketSellEvent arg)
        {
            MarketSellEvent?.Invoke(this, arg);
        }
    }
}