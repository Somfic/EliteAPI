using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{


    public partial class MaterialTradeEvent : EventBase
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

    public partial class MaterialTradeEvent
    {
        public static MaterialTradeEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MaterialTradeEvent>(json);
        }
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