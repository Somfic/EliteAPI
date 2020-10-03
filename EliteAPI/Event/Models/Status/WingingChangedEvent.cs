using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class WingingChangedEvent : StatusEventBase<bool>
    {
        internal WingingChangedEvent() { }
    }
}