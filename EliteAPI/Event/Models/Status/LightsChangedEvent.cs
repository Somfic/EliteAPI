using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class LightsChangedEvent : StatusEventBase<bool>
    {
        internal LightsChangedEvent() { }
    }
}