using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class LandedChangedEvent : StatusEventBase<bool>
    {
        internal LandedChangedEvent() { }
    }
}