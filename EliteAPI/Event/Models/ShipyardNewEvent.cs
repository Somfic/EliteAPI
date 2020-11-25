
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ShipyardNewEvent : EventBase
    {
        internal ShipyardNewEvent() { }

        [JsonProperty("ShipType")]
        public string ShipType { get; private set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; private set; }

        [JsonProperty("NewShipID")]
        public long NewShipId { get; private set; }
    }

    public partial class ShipyardNewEvent
    {
        public static ShipyardNewEvent FromJson(string json) => JsonConvert.DeserializeObject<ShipyardNewEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ShipyardNewEvent> ShipyardNewEvent;
        internal void InvokeShipyardNewEvent(ShipyardNewEvent arg) => ShipyardNewEvent?.Invoke(this, arg);
    }
}
