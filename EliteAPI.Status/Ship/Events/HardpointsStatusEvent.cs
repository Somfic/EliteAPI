using EliteAPI.Abstractions.Status;

namespace EliteAPI.Status.Ship.Events;

public readonly struct HardpointsStatusEvent : IStatusEvent<bool>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Hardpoints";
    
    public bool Value { get; init; }
}