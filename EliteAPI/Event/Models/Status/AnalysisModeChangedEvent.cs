using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class AnalysisModeChangedEvent : StatusEventBase<bool>
    {
        internal AnalysisModeChangedEvent() { }
    }
}