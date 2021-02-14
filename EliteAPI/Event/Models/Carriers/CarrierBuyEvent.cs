using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CarrierBuyEvent : EventBase<CarrierBuyEvent>
    {
        internal CarrierBuyEvent() { }

        [JsonProperty("BoughtAtMarket")]
        public string MarketId { get; private set; }

        [JsonProperty("CarrierID")]
        public string CarrierId { get; private set; }

        [JsonProperty("Location")]
        public string StarSystem { get; private set; }

        [JsonProperty("Price")]
        public long Price { get; private set; }

        [JsonProperty("Variant")]
        public string Variant { get; private set; }

        [JsonProperty("Callsign")]
        public string Callsign { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CarrierBuyEvent> CarrierBuyEvent;

    }
}