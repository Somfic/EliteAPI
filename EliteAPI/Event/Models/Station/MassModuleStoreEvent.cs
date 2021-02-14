using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class MassModuleStoreEvent : EventBase<MassModuleStoreEvent>
    {
        internal MassModuleStoreEvent() { }

        [JsonProperty("MarketID")]
        public string MarketId { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public string ShipId { get; internal set; }

        [JsonProperty("Items")]
        public IReadOnlyList<Item> Items { get; internal set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MassModuleStoreEvent> MassModuleStoreEvent;

        internal void InvokeMassModuleStoreEvent(MassModuleStoreEvent arg)
        {
            MassModuleStoreEvent?.Invoke(this, arg);
        }
    }
}