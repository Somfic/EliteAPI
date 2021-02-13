using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class ShipyardTransferEvent : EventBase
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

    public partial class ShipyardTransferEvent
    {
        public static ShipyardTransferEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ShipyardTransferEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ShipyardTransferEvent> ShipyardTransferEvent;

        internal void InvokeShipyardTransferEvent(ShipyardTransferEvent arg)
        {
            ShipyardTransferEvent?.Invoke(this, arg);
        }
    }
}