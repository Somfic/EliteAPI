using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class GearChangedEvent : StatusEventBase<bool>
    {
        internal GearChangedEvent() { }
    }
}