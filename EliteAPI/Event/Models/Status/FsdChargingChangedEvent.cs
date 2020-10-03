using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class FsdChargingChangedEvent : StatusEventBase<bool>
    {
        internal FsdChargingChangedEvent() { }
    }
}