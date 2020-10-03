using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class InFighterChangedEvent : StatusEventBase<bool>
    {
        internal InFighterChangedEvent() { }
    }
}