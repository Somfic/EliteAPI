using System;
using EliteAPI.Abstractions.Status;

namespace EliteAPI;

internal class EmptyStatusEvent : IStatusEvent
{
    public DateTime Timestamp { get; init; }

    public string Event { get; init; }

    public object Value { get; init; }
}