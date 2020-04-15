using EliteAPI.Events;

namespace EliteAPI.Status
{
    public abstract class StatusBase : EventBase
    {
        internal abstract StatusBase Default { get; }
    }
}