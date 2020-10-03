using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class HardpointsChangedEvent : StatusEventBase<bool>
    {
        internal HardpointsChangedEvent() { }
    }
}