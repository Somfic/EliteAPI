namespace EliteAPI.Abstractions.Events;

public readonly struct EventContext
{
    /// <summary>
    /// Whether the event was raised while the API was catching up with the game session.
    /// </summary>
    public bool IsRaisedDuringCatchup { get; init; }
    
    /// <summary>
    /// Whether the event is implemented in the API.
    /// </summary>
    
    public bool IsImplemented { get; init; }
    
    /// <summary>
    /// The source of the event.
    /// </summary>
    public FileInfo Source { get; init; }
}