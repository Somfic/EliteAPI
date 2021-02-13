using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class ShipyardSwapEvent : EventBase
    {
        internal ShipyardSwapEvent() { }

        [JsonProperty("ShipType")]
        public string ShipType { get; private set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; private set; }

        [JsonProperty("ShipID")]
        public string ShipId { get; private set; }

        [JsonProperty("StoreOldShip")]
        public string StoreOldShip { get; private set; }

        [JsonProperty("StoreShipID")]
        public string StoreShipId { get; private set; }

        [JsonProperty("MarketID")]
        public string MarketId { get; private set; }
    }

    public partial class ShipyardSwapEvent
    {
        public static ShipyardSwapEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ShipyardSwapEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ShipyardSwapEvent> ShipyardSwapEvent;

        internal void InvokeShipyardSwapEvent(ShipyardSwapEvent arg)
        {
            ShipyardSwapEvent?.Invoke(this, arg);
        }
    }
}