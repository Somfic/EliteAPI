using System;

namespace EliteAPI.Events;

public interface IEvent
{
    public string Name { get; }
    public DateTime Timestamp { get; }
}
