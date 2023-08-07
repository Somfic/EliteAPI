using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct GravityStatusEvent : IStatusEvent<double>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Gravity";
    
    public double Value { get; init; }
}