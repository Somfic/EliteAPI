using System;

namespace EliteAPI.Events;

public interface IEvent
{
    public string Event { get; }
    public DateTime Timestamp { get; }
}
