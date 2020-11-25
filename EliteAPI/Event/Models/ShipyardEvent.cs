
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ShipyardEvent : EventBase
    {
        internal ShipyardEvent() { }

        [JsonProperty("MarketID")]
        public long MarketId { get; private set; }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }
    }

    public partial class ShipyardEvent
    {
        public static ShipyardEvent FromJson(string json) => JsonConvert.DeserializeObject<ShipyardEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ShipyardEvent> ShipyardEvent;
        internal void InvokeShipyardEvent(ShipyardEvent arg) => ShipyardEvent?.Invoke(this, arg);
    }
}
