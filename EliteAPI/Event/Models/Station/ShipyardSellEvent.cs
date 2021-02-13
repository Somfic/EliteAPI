using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class ShipyardSellEvent : EventBase
    {
        internal ShipyardSellEvent() { }

        [JsonProperty("ShipType")]
        public string ShipType { get; private set; }

        [JsonProperty("SellShipID")]
        public string SellShipId { get; private set; }

        [JsonProperty("ShipPrice")]
        public long ShipPrice { get; private set; }

        [JsonProperty("System")]
        public string System { get; private set; }
    }

    public partial class ShipyardSellEvent
    {
        public static ShipyardSellEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ShipyardSellEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ShipyardSellEvent> ShipyardSellEvent;

        internal void InvokeShipyardSellEvent(ShipyardSellEvent arg)
        {
            ShipyardSellEvent?.Invoke(this, arg);
        }
    }
}