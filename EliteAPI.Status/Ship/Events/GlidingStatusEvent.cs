using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public  readonly struct GlidingStatusEvent : IStatusEvent<bool>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Gliding";
    
    public bool Value { get; init; }
}