using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ModuleSellEvent : EventBase<ModuleSellEvent>
    {
        internal ModuleSellEvent() { }

        [JsonProperty("MarketID")]
        public string MarketId { get; private set; }

        [JsonProperty("Slot")]
        public string Slot { get; private set; }

        [JsonProperty("SellItem")]
        public string SellItem { get; private set; }

        [JsonProperty("SellItem_Localised")]
        public string SellItemLocalised { get; private set; }

        [JsonProperty("SellPrice")]
        public long SellPrice { get; private set; }

        [JsonProperty("Ship")]
        public string Ship { get; private set; }

        [JsonProperty("ShipID")]
        public string ShipId { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ModuleSellEvent> ModuleSellEvent;

    }
}