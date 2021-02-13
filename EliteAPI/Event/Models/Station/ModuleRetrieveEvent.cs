using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class ModuleRetrieveEvent : EventBase
    {
        internal ModuleRetrieveEvent() { }

        [JsonProperty("MarketID")]
        public string MarketId { get; private set; }

        [JsonProperty("Slot")]
        public string Slot { get; private set; }

        [JsonProperty("RetrievedItem")]
        public string RetrievedItem { get; private set; }

        [JsonProperty("RetrievedItem_Localised")]
        public string RetrievedItemLocalised { get; private set; }

        [JsonProperty("Ship")]
        public string Ship { get; private set; }

        [JsonProperty("ShipID")]
        public string ShipId { get; private set; }

        [JsonProperty("Hot")]
        public bool Hot { get; private set; }
    }

    public partial class ModuleRetrieveEvent
    {
        public static ModuleRetrieveEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ModuleRetrieveEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ModuleRetrieveEvent> ModuleRetrieveEvent;

        internal void InvokeModuleRetrieveEvent(ModuleRetrieveEvent arg)
        {
            ModuleRetrieveEvent?.Invoke(this, arg);
        }
    }
}