using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class InMothershipChangedEvent : StatusEventBase<bool>
    {
        internal InMothershipChangedEvent() { }
    }
}