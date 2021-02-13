using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class ModuleSellRemoteEvent : EventBase
    {
        internal ModuleSellRemoteEvent() { }

        [JsonProperty("StorageSlot")]
        public string StorageSlot { get; private set; }

        [JsonProperty("SellItem")]
        public string SellItem { get; private set; }

        [JsonProperty("SellItem_Localised")]
        public string SellItemLocalised { get; private set; }

        [JsonProperty("ServerId")]
        public string ServerId { get; private set; }

        [JsonProperty("SellPrice")]
        public long SellPrice { get; private set; }

        [JsonProperty("Ship")]
        public string Ship { get; private set; }

        [JsonProperty("ShipID")]
        public string ShipId { get; private set; }
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