using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class ShipyardEvent : EventBase
    {
        internal ShipyardEvent() { }

        [JsonProperty("MarketID")]
        public string MarketId { get; private set; }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }
    }

    public partial class ShipyardEvent
    {
        public static ShipyardEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ShipyardEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ShipyardEvent> ShipyardEvent;

        internal void InvokeShipyardEvent(ShipyardEvent arg)
        {
            ShipyardEvent?.Invoke(this, arg);
        }
    }
}