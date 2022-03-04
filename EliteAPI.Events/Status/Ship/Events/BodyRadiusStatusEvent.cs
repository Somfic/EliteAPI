using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct BodyRadiusStatusEvent : IStatusEvent<float>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "BodyRadius";
    
    public float Value { get; init; }
}