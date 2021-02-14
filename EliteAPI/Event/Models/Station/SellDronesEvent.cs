using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SellDronesEvent : EventBase<SellDronesEvent>
    {
        internal SellDronesEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }

        [JsonProperty("SellPrice")]
        public long SellPrice { get; private set; }

        [JsonProperty("TotalSale")]
        public long TotalSale { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SellDronesEvent> SellDronesEvent;

    }
}