using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class PvpKillEvent : EventBase
    {
        internal PvpKillEvent()
        {
        }

        [JsonProperty("Victim")] public string Victim { get; private set; }

        [JsonProperty("CombatRank")] public long CombatRank { get; private set; }
    }

    public partial class PvpKillEvent
    {
        public static PvpKillEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PvpKillEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PvpKillEvent> PvpKillEvent;

        internal void InvokePvpKillEvent(PvpKillEvent arg)
        {
            PvpKillEvent?.Invoke(this, arg);
        }
    }
}