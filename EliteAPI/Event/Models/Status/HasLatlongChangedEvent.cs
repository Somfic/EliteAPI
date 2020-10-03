using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class HasLatlongChangedEvent : StatusEventBase<bool>
    {
        internal HasLatlongChangedEvent() { }
    }
}