using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct CargoStatusEvent : IStatusEvent<int>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Cargo";
    
    public int Value { get; init; }
}