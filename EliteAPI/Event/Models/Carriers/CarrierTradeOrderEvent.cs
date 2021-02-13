using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class CarrierTradeOrderEvent : EventBase
    {
        internal CarrierTradeOrderEvent() { }

        [JsonProperty("CarrierID")]
        public string CarrierId { get; private set; }

        [JsonProperty("BlackMarket")]
        public bool BlackMarket { get; private set; }

        [JsonProperty("Commodity")]
        public string Commodity { get; private set; }
        
        [JsonProperty("Commodity_Localised")]
        public string CommodityLocalised { get; private set; }

        [JsonProperty("PurchaseOrder")]
        public int PurchaseOrder { get; private set; }
        
        [JsonProperty("SaleOrder")]
        public int SaleOrder { get; private set; }
        
        [JsonProperty("CancelTrade")]
        public bool CancelTrade { get; private set; }

        [JsonProperty("Price")]
        public long Price { get; private set; }
    }

    public partial class CarrierTradeOrderEvent
    {
        public static CarrierTradeOrderEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CarrierTradeOrderEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CarrierTradeOrderEvent> CarrierTradeOrderEvent;

        internal void InvokeCarrierTradeOrderEvent(CarrierTradeOrderEvent arg)
        {
            CarrierTradeOrderEvent?.Invoke(this, arg);
        }
    }
}