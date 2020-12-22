using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class SupercruiseEntryEvent : EventBase
    {
        internal SupercruiseEntryEvent()
        {
        }

        [JsonProperty("StarSystem")] public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")] public long SystemAddress { get; private set; }
    }

    public partial class SupercruiseEntryEvent
    {
        public static SupercruiseEntryEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SupercruiseEntryEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SupercruiseEntryEvent> SupercruiseEntryEvent;

        internal void InvokeSupercruiseEntryEvent(SupercruiseEntryEvent arg)
        {
            SupercruiseEntryEvent?.Invoke(this, arg);
        }
    }
}