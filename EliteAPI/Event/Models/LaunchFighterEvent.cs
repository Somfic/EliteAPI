using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class LaunchFighterEvent : EventBase
    {
        internal LaunchFighterEvent()
        {
        }

        [JsonProperty("Loadout")] public string Loadout { get; private set; }

        [JsonProperty("ID")] public long Id { get; private set; }

        [JsonProperty("PlayerControlled")] public bool PlayerControlled { get; private set; }
    }

    public partial class LaunchFighterEvent
    {
        public static LaunchFighterEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LaunchFighterEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<LaunchFighterEvent> LaunchFighterEvent;

        internal void InvokeLaunchFighterEvent(LaunchFighterEvent arg)
        {
            LaunchFighterEvent?.Invoke(this, arg);
        }
    }
}