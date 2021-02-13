using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class MarketBuyEvent : EventBase
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