using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct LongitudeStatusEvent : IStatusEvent<float>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Longitude";
    
    public float Value { get; init; }
}