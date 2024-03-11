using EliteAPI.Abstractions.Status;

namespace EliteAPI.Status.Ship.Events;

public readonly struct WingingStatusEvent : IStatusEvent<bool>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Winging";
    
    public bool Value { get; init; }
}