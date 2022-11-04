using EliteAPI.Abstractions.Events;
using EliteAPI.Bindings;

namespace EliteAPI.Abstractions.Bindings;

public readonly struct BindingsEvent : IEvent
{
    public BindingsEvent(IReadOnlyCollection<Binding> bindings)
    {
        Timestamp = DateTime.Now;
        Event = "Bindings";
        Bindings = bindings;
    }
    
    public DateTime Timestamp { get; }
    public string Event { get; }

    public IReadOnlyCollection<Binding> Bindings { get; }
}