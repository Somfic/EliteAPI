using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class ScoopingChangedEvent : StatusEventBase<bool>
    {
        internal ScoopingChangedEvent() { }
    }
}