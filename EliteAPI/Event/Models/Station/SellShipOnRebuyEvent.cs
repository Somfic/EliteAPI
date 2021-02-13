using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class SellShipOnRebuyEvent : EventBase
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

    public partial class SellShipOnRebuyEvent
    {
        public static SellShipOnRebuyEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SellShipOnRebuyEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SellShipOnRebuyEvent> SellShipOnRebuyEvent;

        internal void InvokeSellShipOnRebuyEvent(SellShipOnRebuyEvent arg)
        {
            SellShipOnRebuyEvent?.Invoke(this, arg);
        }
    }
}