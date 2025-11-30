namespace EliteAPI.Events;

/// <summary>
/// Provides context about how an event is being processed.
/// </summary>
public class EventContext
{
    /// <summary>
    /// True if this event is being replayed from the current journal session (catchup mode).
    /// False if this is a new event being processed in real-time.
    /// </summary>
    public bool DuringCatchup { get; set; }

    /// <summary>
    /// Creates a new EventContext for real-time event processing.
    /// </summary>
    public EventContext() : this(false) { }

    /// <summary>
    /// Creates a new EventContext with the specified catchup state.
    /// </summary>
    public EventContext(bool duringCatchup)
    {
        DuringCatchup = duringCatchup;
    }
}
