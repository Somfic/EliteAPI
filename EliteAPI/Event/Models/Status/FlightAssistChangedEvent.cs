using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class FlightAssistChangedEvent : StatusEventBase<bool>
    {
        internal FlightAssistChangedEvent() { }
    }
}