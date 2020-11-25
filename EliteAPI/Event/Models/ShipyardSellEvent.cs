
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ShipyardSellEvent : EventBase
    {
        internal ShipyardSellEvent() { }

        [JsonProperty("ShipType")]
        public string ShipType { get; private set; }

        [JsonProperty("SellShipID")]
        public long SellShipId { get; private set; }

        [JsonProperty("ShipPrice")]
        public long ShipPrice { get; private set; }

        [JsonProperty("System")]
        public string System { get; private set; }
    }

    public partial class ShipyardSellEvent
    {
        public static ShipyardSellEvent FromJson(string json) => JsonConvert.DeserializeObject<ShipyardSellEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ShipyardSellEvent> ShipyardSellEvent;
        internal void InvokeShipyardSellEvent(ShipyardSellEvent arg) => ShipyardSellEvent?.Invoke(this, arg);
    }
}
