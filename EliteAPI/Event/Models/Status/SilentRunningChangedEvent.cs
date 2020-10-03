using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class SilentRunningChangedEvent : StatusEventBase<bool>
    {
        internal SilentRunningChangedEvent() { }
    }
}