using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct LowOxygenStatusEvent : IStatusEvent<bool>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "LowOxygen";
    
    public bool Value { get; init; }
}