using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    internal class ShieldsChangedEvent : StatusEventBase<bool>
    {
        internal ShieldsChangedEvent() { }
    }
}