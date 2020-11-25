
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ShipyardTransferEvent : EventBase
    {
        internal ShipyardTransferEvent() { }

        [JsonProperty("ShipType")]
        public string ShipType { get; private set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; private set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; private set; }

        [JsonProperty("System")]
        public string System { get; private set; }

        [JsonProperty("ShipMarketID")]
        public long ShipMarketId { get; private set; }

        [JsonProperty("Distance")]
        public double Distance { get; private set; }

        [JsonProperty("TransferPrice")]
        public long TransferPrice { get; private set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; private set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; private set; }
    }

    public partial class ShipyardTransferEvent
    {
        public static ShipyardTransferEvent FromJson(string json) => JsonConvert.DeserializeObject<ShipyardTransferEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ShipyardTransferEvent> ShipyardTransferEvent;
        internal void InvokeShipyardTransferEvent(ShipyardTransferEvent arg) => ShipyardTransferEvent?.Invoke(this, arg);
    }
}
