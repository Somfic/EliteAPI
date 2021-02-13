using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class ModuleSwapEvent : EventBase
    {
        internal ModuleSwapEvent() { }

        [JsonProperty("MarketID")]
        public string MarketId { get; private set; }

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
        public string ShipId { get; private set; }
    }

    public partial class ModuleSwapEvent
    {
        public static ModuleSwapEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ModuleSwapEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ModuleSwapEvent> ModuleSwapEvent;

        internal void InvokeModuleSwapEvent(ModuleSwapEvent arg)
        {
            ModuleSwapEvent?.Invoke(this, arg);
        }
    }
}