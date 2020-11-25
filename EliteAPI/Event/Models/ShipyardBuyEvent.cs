
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ShipyardBuyEvent : EventBase
    {
        internal ShipyardBuyEvent() { }

        [JsonProperty("ShipType")]
        public string ShipType { get; private set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; private set; }

        [JsonProperty("ShipPrice")]
        public long ShipPrice { get; private set; }

        [JsonProperty("StoreOldShip")]
        public string StoreOldShip { get; private set; }

        [JsonProperty("StoreShipID")]
        public long StoreShipId { get; private set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; private set; }
    }

    public partial class ShipyardBuyEvent
    {
        public static ShipyardBuyEvent FromJson(string json) => JsonConvert.DeserializeObject<ShipyardBuyEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ShipyardBuyEvent> ShipyardBuyEvent;
        internal void InvokeShipyardBuyEvent(ShipyardBuyEvent arg) => ShipyardBuyEvent?.Invoke(this, arg);
    }
}
