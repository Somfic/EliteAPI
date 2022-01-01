using EliteAPI.Abstractions.Readers;
using Newtonsoft.Json;

namespace EliteAPI.Abstractions.Events;

/// <summary>Base interface for all events.</summary>
public interface IEvent
{
    /// <summary>The timestamp of the event.</summary>
    [JsonProperty("timestamp", Order = -3)]
    DateTime Timestamp { get; }

    /// <summary>The name of the event.</summary>
    [JsonProperty("event", Order = -2)]
    string Event { get; }
}