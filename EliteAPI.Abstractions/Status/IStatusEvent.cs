using EliteAPI.Abstractions.Events;

namespace EliteAPI.Abstractions.Status;

public interface IStatusEvent : IEvent
{
    
}

public interface IStatusEvent<out T> : IStatusEvent
{
    T Value { get; }
}