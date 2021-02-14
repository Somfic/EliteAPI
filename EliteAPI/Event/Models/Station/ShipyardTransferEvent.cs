using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ShipyardTransferEvent : EventBase<ShipyardTransferEvent>
    {
        internal ShipyardTransferEvent() { }

        [JsonProperty("ShipType")]
        public string ShipType { get; private set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; private set; }

        [JsonProperty("ShipID")]
        public string ShipId { get; private set; }

        [JsonProperty("System")]
        public string System { get; private set; }

        [JsonProperty("ShipMarketID")]
        public string ShipMarketId { get; private set; }

        [JsonProperty("Distance")]
        public double Distance { get; private set; }
    
        [JsonProperty("TransferPrice")]
        public long TransferPrice { get; private set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; private set; }

        [JsonProperty("MarketID")]
        public string MarketId { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ShipyardTransferEvent> ShipyardTransferEvent;

    }
}