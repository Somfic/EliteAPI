using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class OverheatingChangedEvent : StatusEventBase<bool>
    {
        internal OverheatingChangedEvent() { }
    }
}