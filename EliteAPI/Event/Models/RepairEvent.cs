using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class RepairEvent : EventBase
    {
        internal RepairEvent()
        {
        }

        [JsonProperty("Item")] public string Item { get; private set; }

        [JsonProperty("Cost")] public long Cost { get; private set; }
    }

    public partial class RepairEvent
    {
        public static RepairEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RepairEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<RepairEvent> RepairEvent;

        internal void InvokeRepairEvent(RepairEvent arg)
        {
            RepairEvent?.Invoke(this, arg);
        }
    }
}