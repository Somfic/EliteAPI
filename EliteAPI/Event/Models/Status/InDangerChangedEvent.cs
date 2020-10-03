using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class InDangerChangedEvent : StatusEventBase<bool>
    {
        internal InDangerChangedEvent() { }
    }
}