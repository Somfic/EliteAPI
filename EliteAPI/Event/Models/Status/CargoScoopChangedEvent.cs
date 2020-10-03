using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class CargoScoopChangedEvent : StatusEventBase<bool>
    {
        internal CargoScoopChangedEvent() { }
    }
}