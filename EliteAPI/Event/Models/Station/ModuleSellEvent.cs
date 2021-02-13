using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class ModuleSellEvent : EventBase
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

    public partial class ModuleSellEvent
    {
        public static ModuleSellEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ModuleSellEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ModuleSellEvent> ModuleSellEvent;

        internal void InvokeModuleSellEvent(ModuleSellEvent arg)
        {
            ModuleSellEvent?.Invoke(this, arg);
        }
    }
}