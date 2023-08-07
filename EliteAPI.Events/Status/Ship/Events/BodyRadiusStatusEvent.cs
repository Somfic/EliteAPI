using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct BodyRadiusStatusEvent : IStatusEvent<double>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "BodyRadius";
    
    public double Value { get; init; }
}