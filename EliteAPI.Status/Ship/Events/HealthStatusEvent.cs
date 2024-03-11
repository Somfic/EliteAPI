using EliteAPI.Abstractions.Status;

namespace EliteAPI.Status.Ship.Events;

public readonly struct HealthStatusEvent : IStatusEvent<double>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Health";
    
    public double Value { get; init; }
}