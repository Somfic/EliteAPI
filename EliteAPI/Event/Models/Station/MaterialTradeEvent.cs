using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class MaterialTradeEvent : EventBase<MaterialTradeEvent>
    {
        internal MaterialTradeEvent() { }

        [JsonProperty("MarketID")]
        public string MarketId { get; private set; }

        [JsonProperty("TraderType")]
        public string TraderType { get; private set; }

        [JsonProperty("Paid")]
        public Paid Paid { get; private set; }

        [JsonProperty("Received")]
        public Paid Received { get; private set; }
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class Paid
    {
        internal Paid() { }

        [JsonProperty("Material")]
        public string Material { get; private set; }

        [JsonProperty("Material_Localised")]
        public string MaterialLocalised { get; private set; }

        [JsonProperty("Category")]
        public string Category { get; private set; }

        [JsonProperty("Quantity")]
        public long Quantity { get; private set; }
    }


}

namespace EliteAPI.Event.Handler
{

    public partial class EventHandler
    {
        public event EventHandler<MaterialTradeEvent> MaterialTradeEvent;
        
        internal void InvokeMaterialTradeEvent(MaterialTradeEvent arg)
        {
            MaterialTradeEvent?.Invoke(this, arg);
        }
    }
}