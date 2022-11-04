using EliteAPI.Abstractions.Bindings.Models;
using EliteAPI.Abstractions.Events;

namespace EliteAPI.Events;

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