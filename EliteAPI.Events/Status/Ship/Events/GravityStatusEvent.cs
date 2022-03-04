using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct GravityStatusEvent : IStatusEvent<float>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Gravity";
    
    public float Value { get; init; }
}