using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct CargoStatusEvent : IStatusEvent<long>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Cargo";
    
    public long Value { get; init; }
}