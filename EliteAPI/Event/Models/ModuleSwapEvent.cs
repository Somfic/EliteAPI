
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ModuleSwapEvent : EventBase
    {
        internal ModuleSwapEvent() { }

        [JsonProperty("MarketID")]
        public long MarketId { get; private set; }

        [JsonProperty("FromSlot")]
        public string FromSlot { get; private set; }

        [JsonProperty("ToSlot")]
        public string ToSlot { get; private set; }

        [JsonProperty("FromItem")]
        public string FromItem { get; private set; }

        [JsonProperty("FromItem_Localised")]
        public string FromItemLocalised { get; private set; }

        [JsonProperty("ToItem")]
        public string ToItem { get; private set; }

        [JsonProperty("ToItem_Localised")]
        public string ToItemLocalised { get; private set; }

        [JsonProperty("Ship")]
        public string Ship { get; private set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; private set; }
    }

    public partial class ModuleSwapEvent
    {
        public static ModuleSwapEvent FromJson(string json) => JsonConvert.DeserializeObject<ModuleSwapEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ModuleSwapEvent> ModuleSwapEvent;
        internal void InvokeModuleSwapEvent(ModuleSwapEvent arg) => ModuleSwapEvent?.Invoke(this, arg);
    }
}
