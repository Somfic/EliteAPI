namespace EliteAPI.Abstractions.Events;

/// <summary>Helper for converting between JSON and events.</summary>
public interface IEventUtilities
{
    /// <summary>Generates the JSON from the provided event.</summary>
    /// <param name="event">The event</param>
    string ToJson<T>(T @event) where T : IEvent;

    /// <summary>Generates the event from the provided JSON string.</summary>
    /// <param name="json">The JSON string</param>
    T FromJson<T>(string json) where T : IEvent;
}