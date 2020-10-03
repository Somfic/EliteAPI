using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class SrvHandbreakChangedEvent : StatusEventBase<bool>
    {
        internal SrvHandbreakChangedEvent() { }
    }
}