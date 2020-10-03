using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class InInterdictionChangedEvent : StatusEventBase<bool>
    {
        internal InInterdictionChangedEvent() { }
    }
}