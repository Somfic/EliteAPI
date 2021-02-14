using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SellShipOnRebuyEvent : EventBase<SellShipOnRebuyEvent>
    {
        internal SellShipOnRebuyEvent() { }

        [JsonProperty("ShipType")]
        public string ShipType { get; private set; }

        [JsonProperty("System")]
        public string System { get; private set; }

        [JsonProperty("SellShipId")]
        public string SellShipId { get; private set; }

        [JsonProperty("SellShipPrice")]
        public long SellShipPrice { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SellShipOnRebuyEvent> SellShipOnRebuyEvent;

    }
}