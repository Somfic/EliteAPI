using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class ModuleInfoEvent : EventBase
    {
        internal ModuleInfoEvent()
        {
        }

        [JsonProperty("event")] public string Event { get; private set; }
    }

    public partial class ModuleInfoEvent
    {
        public static ModuleInfoEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ModuleInfoEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ModuleInfoEvent> ModuleInfoEvent;

        internal void InvokeModuleInfoEvent(ModuleInfoEvent arg)
        {
            ModuleInfoEvent?.Invoke(this, arg);
        }
    }
}