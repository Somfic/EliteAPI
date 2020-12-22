using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class WingAddEvent : EventBase
    {
        internal WingAddEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }
    }

    public partial class WingAddEvent
    {
        public static WingAddEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<WingAddEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<WingAddEvent> WingAddEvent;

        internal void InvokeWingAddEvent(WingAddEvent arg)
        {
            WingAddEvent?.Invoke(this, arg);
        }
    }
}