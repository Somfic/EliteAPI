
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ModuleSellRemoteEvent : EventBase
    {
        internal ModuleSellRemoteEvent() { }

        [JsonProperty("StorageSlot")]
        public long StorageSlot { get; private set; }

        [JsonProperty("SellItem")]
        public string SellItem { get; private set; }

        [JsonProperty("SellItem_Localised")]
        public string SellItemLocalised { get; private set; }

        [JsonProperty("ServerId")]
        public long ServerId { get; private set; }

        [JsonProperty("SellPrice")]
        public long SellPrice { get; private set; }

        [JsonProperty("Ship")]
        public string Ship { get; private set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; private set; }
    }

    public partial class ModuleSellRemoteEvent
    {
        public static ModuleSellRemoteEvent FromJson(string json) => JsonConvert.DeserializeObject<ModuleSellRemoteEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ModuleSellRemoteEvent> ModuleSellRemoteEvent;
        internal void InvokeModuleSellRemoteEvent(ModuleSellRemoteEvent arg) => ModuleSellRemoteEvent?.Invoke(this, arg);
    }
}
