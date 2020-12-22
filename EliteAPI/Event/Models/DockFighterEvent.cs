using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class DockFighterEvent : EventBase
    {
        internal DockFighterEvent()
        {
        }

        [JsonProperty("ID")] public long Id { get; private set; }
    }

    public partial class DockFighterEvent
    {
        public static DockFighterEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DockFighterEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DockFighterEvent> DockFighterEvent;

        internal void InvokeDockFighterEvent(DockFighterEvent arg)
        {
            DockFighterEvent?.Invoke(this, arg);
        }
    }
}