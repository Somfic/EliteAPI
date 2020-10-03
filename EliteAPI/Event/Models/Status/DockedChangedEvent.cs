using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models.Status
{
    public class DockedChangedEvent : StatusEventBase<bool>
    {
        internal DockedChangedEvent() { }
    }
}
