
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ModuleBuyEvent : EventBase
    {
        internal ModuleBuyEvent() { }

        [JsonProperty("Slot")]
        public string Slot { get; private set; }

        [JsonProperty("BuyItem")]
        public string BuyItem { get; private set; }

        [JsonProperty("BuyItem_Localised")]
        public string BuyItemLocalised { get; private set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; private set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; private set; }

        [JsonProperty("Ship")]
        public string Ship { get; private set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; private set; }
    }

    public partial class ModuleBuyEvent
    {
        public static ModuleBuyEvent FromJson(string json) => JsonConvert.DeserializeObject<ModuleBuyEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ModuleBuyEvent> ModuleBuyEvent;
        internal void InvokeModuleBuyEvent(ModuleBuyEvent arg) => ModuleBuyEvent?.Invoke(this, arg);
    }
}
