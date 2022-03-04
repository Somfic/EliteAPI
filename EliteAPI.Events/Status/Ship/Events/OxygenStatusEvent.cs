using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct OxygenStatusEvent : IStatusEvent<float>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Oxygen";
    
    public float Value { get; init; }
}