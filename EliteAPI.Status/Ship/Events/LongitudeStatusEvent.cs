using EliteAPI.Abstractions.Status;

namespace EliteAPI.Status.Ship.Events;

public readonly struct LongitudeStatusEvent : IStatusEvent<double>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Longitude";
    
    public double Value { get; init; }
}