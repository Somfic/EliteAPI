
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ShipyardSwapEvent : EventBase
    {
        internal ShipyardSwapEvent() { }

        [JsonProperty("ShipType")]
        public string ShipType { get; private set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; private set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; private set; }

        [JsonProperty("StoreOldShip")]
        public string StoreOldShip { get; private set; }

        [JsonProperty("StoreShipID")]
        public long StoreShipId { get; private set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; private set; }
    }

    public partial class ShipyardSwapEvent
    {
        public static ShipyardSwapEvent FromJson(string json) => JsonConvert.DeserializeObject<ShipyardSwapEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ShipyardSwapEvent> ShipyardSwapEvent;
        internal void InvokeShipyardSwapEvent(ShipyardSwapEvent arg) => ShipyardSwapEvent?.Invoke(this, arg);
    }
}
