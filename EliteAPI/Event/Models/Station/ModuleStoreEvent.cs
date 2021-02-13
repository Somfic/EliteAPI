using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class ModuleStoreEvent : EventBase
    {
        internal ModuleStoreEvent() { }

        [JsonProperty("Slot")]
        public string Slot { get; private set; }

        [JsonProperty("StoredItem")]
        public string StoredItem { get; private set; }

        [JsonProperty("StoredItem_Localised")]
        public string StoredItemLocalised { get; private set; }

        [JsonProperty("Ship")]
        public string Ship { get; private set; }

        [JsonProperty("ShipID")]
        public string ShipId { get; private set; }

        [JsonProperty("EngineerModifications")]
        public string EngineerModifications { get; private set; }
    }

    public partial class ModuleStoreEvent
    {
        public static ModuleStoreEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ModuleStoreEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ModuleStoreEvent> ModuleStoreEvent;

        internal void InvokeModuleStoreEvent(ModuleStoreEvent arg)
        {
            ModuleStoreEvent?.Invoke(this, arg);
        }
    }
}