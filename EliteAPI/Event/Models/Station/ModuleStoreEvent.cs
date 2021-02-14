using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ModuleStoreEvent : EventBase<ModuleStoreEvent>
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

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ModuleStoreEvent> ModuleStoreEvent;

    }
}