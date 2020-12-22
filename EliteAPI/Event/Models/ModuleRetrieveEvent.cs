using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class ModuleRetrieveEvent : EventBase
    {
        internal ModuleRetrieveEvent()
        {
        }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }

        [JsonProperty("Slot")] public string Slot { get; private set; }

        [JsonProperty("RetrievedItem")] public string RetrievedItem { get; private set; }

        [JsonProperty("RetrievedItem_Localised")]
        public string RetrievedItemLocalised { get; private set; }

        [JsonProperty("Ship")] public string Ship { get; private set; }

        [JsonProperty("ShipID")] public long ShipId { get; private set; }

        [JsonProperty("Hot")] public bool Hot { get; private set; }
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