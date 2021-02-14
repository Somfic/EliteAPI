using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ShipyardBuyEvent : EventBase<ShipyardBuyEvent>
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
        public string StoreShipId { get; private set; }

        [JsonProperty("MarketID")]
        public string MarketId { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ShipyardBuyEvent> ShipyardBuyEvent;

        internal void InvokeShipyardBuyEvent(ShipyardBuyEvent arg)
        {
            ShipyardBuyEvent?.Invoke(this, arg);
        }
    }
}