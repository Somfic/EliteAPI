using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class ModuleSellRemoteEvent : EventBase
    {
        internal ModuleSellRemoteEvent()
        {
        }

        [JsonProperty("StorageSlot")] public long StorageSlot { get; private set; }

        [JsonProperty("SellItem")] public string SellItem { get; private set; }

        [JsonProperty("SellItem_Localised")] public string SellItemLocalised { get; private set; }

        [JsonProperty("ServerId")] public long ServerId { get; private set; }

        [JsonProperty("SellPrice")] public long SellPrice { get; private set; }

        [JsonProperty("Ship")] public string Ship { get; private set; }

        [JsonProperty("ShipID")] public long ShipId { get; private set; }
    }

    public partial class ModuleSellRemoteEvent
    {
        public static ModuleSellRemoteEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ModuleSellRemoteEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ModuleSellRemoteEvent> ModuleSellRemoteEvent;

        internal void InvokeModuleSellRemoteEvent(ModuleSellRemoteEvent arg)
        {
            ModuleSellRemoteEvent?.Invoke(this, arg);
        }
    }
}