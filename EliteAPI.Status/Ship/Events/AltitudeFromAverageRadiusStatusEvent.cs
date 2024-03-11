using EliteAPI.Abstractions.Status;

namespace EliteAPI.Status.Ship.Events;

public readonly struct AltitudeFromAverageRadiusStatusEvent : IStatusEvent<bool>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "AltitudeFromAverageRadius";
    
    public bool Value { get; init; }
}