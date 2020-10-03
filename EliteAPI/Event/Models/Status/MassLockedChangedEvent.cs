using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class MassLockedChangedEvent : StatusEventBase<bool>
    {
        internal MassLockedChangedEvent() { }
    }
}