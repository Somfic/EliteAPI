using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class LowFuelChangedEvent : StatusEventBase<bool>
    {
        internal LowFuelChangedEvent() { }
    }
}